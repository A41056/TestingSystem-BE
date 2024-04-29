using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;
using TestingSystem.Data.Common;
using TestingSystem.Data.Db;
using TestingSystem.Data.Models.Course;
using TestingSystem.Infrastructure.Repositories.Interfaces;
using TestingSystem.Infrastructure.Repositories.Interfaces.Course;

namespace TestingSystem.Infrastructure.Repositories.Implements.Course
{
    public class CourseRepository : BaseRepository<Data.Entities.Course.Course>, ICourseRepository
    {
        private readonly ICourseDetailRepository _courseDetailRepository;
        private readonly ILanguageTagRepository _languageTagRepository;
        private readonly ICourseTeacherRepository _courseTeacherRepository;
        private readonly IUserRepository _userRepository;

        public CourseRepository(TestingSystemDbContext dbContext,
            ILanguageTagRepository languageTagRepository,
            ICourseDetailRepository courseDetailRepository,
            ICourseTeacherRepository courseTeacherRepository,
            IUserRepository userRepository) : base(dbContext)
        {
            _courseDetailRepository = courseDetailRepository;
            _languageTagRepository = languageTagRepository;
            _courseTeacherRepository = courseTeacherRepository;
            _userRepository = userRepository;
        }

        public async Task DeleteAsync(Guid courseId)
        {
            var course = await DbSet.FirstOrDefaultAsync(c => c.Id == courseId);

            if (course != null)
            {
                course.Deleted = true;
                await SaveChangeAsync();
            }    
        }

        public async Task<CourseInfoDto> GetCourseByIdAsync(Guid id)
        {
            var course = await DbSet.FirstOrDefaultAsync(c => c.Id == id && !c.Deleted.GetValueOrDefault());

            return new CourseInfoDto()
            {
                Id = course.Id,
                Status = course.Status,
                CategoryId = course.CategoryId,
                Created = course.Created,
                Modified = course.Modified,
                NameNonAscii = course.NameNonAscii,
                IsHot = course.IsHot.GetValueOrDefault(),
                CourseImageUrl = course.CourseImageUrl
            };
        }

        public async Task<PaginatedResponseModel<CourseInfoDto>> GetListCourseAsync(SearchingCourseRequest request)
        {
            string languageCode = request.LanguageCode;

            if (string.IsNullOrEmpty(languageCode))
            {
                var language = await _languageTagRepository.GetDefault();
                languageCode = language.Code;
            }
            var data = new List<CourseInfoDto>();

            Expression<Func<Data.Entities.Course.Course, bool>> filter = course =>
                (request.NameNonAscii == null || course.NameNonAscii.Contains(request.NameNonAscii)) &&
                (request.CategoryId == null || course.CategoryId == request.CategoryId) &&
                (string.IsNullOrEmpty(request.Keyword) || course.FullTextSearch.Contains(request.Keyword));

            Func<IQueryable<Data.Entities.Course.Course>, IOrderedQueryable<Data.Entities.Course.Course>> orderBy = query => query.OrderBy(x => x.Created);

            var paginationSet = await GetPaginatedDataByRequest(request, filter, orderBy,
                includes: new Expression<Func<Data.Entities.Course.Course, object>>[]
                {
                    c => c.CourseTranslations.Where(ct => ct.LanguageCode == languageCode)
                }
                );

            //var filteredCourses = paginationSet.Data.Where(course =>course.CourseTranslations.Any(translation => translation.LanguageCode == languageCode));

            foreach (var item in paginationSet.Data)
            {
                if (!item.Deleted.GetValueOrDefault())
                {
                    data.Add(new CourseInfoDto()
                    {
                        Id = item.Id,
                        CategoryId = item.CategoryId,
                        AuthorId = item.AuthorId,
                        Status = item.Status,
                        NameNonAscii = item.NameNonAscii,
                        IsHot = item.IsHot,
                        Tags = item.Tags,
                        CourseImageUrl = item.CourseImageUrl,
                        Created = item.Created,
                        Modified = item.Modified,
                    });
                }
            }

            var mappedPaginationSet = new PaginatedResponseModel<CourseInfoDto>(data, paginationSet.TotalRecords, paginationSet.PageNum, paginationSet.PageSize);

            return mappedPaginationSet;
        }

        public async Task InsertAsync(Guid courseId, CourseInsertDto model)
        {
            var course = new Data.Entities.Course.Course()
            {
                Id = courseId,
                AuthorId = model.AuthorId,
                Status = 1,
                CategoryId = model.CategoryId,
                NameNonAscii = model.NameNonAscii,
                IsHot = model.IsHot,
                Tags = JsonConvert.SerializeObject(model.Tags),
                FullTextSearch = model.NameNonAscii,
                CourseImageUrl = model.CourseImageUrl
            };

            await DbSet.AddAsync(course);

            await SaveChangeAsync();

            var user = await _userRepository.GetUser(model.AuthorId.GetValueOrDefault());

            model.CourseTeacherInsertDto.AvatarUrl = user.AvatarUrl;
            model.CourseTeacherInsertDto.CourseId = courseId;
            model.CourseTeacherInsertDto.TeacherId = model.AuthorId;

            await _courseTeacherRepository.InsertAsync(model.CourseTeacherInsertDto.TeacherId.GetValueOrDefault(), model.CourseTeacherInsertDto);
        }

        public async Task UpdateAsync(Guid courseId, CourseUpdateDto model)
        {
            var course = await DbSet.FirstOrDefaultAsync(c => c.Id == courseId);

            if (course != null)
            {
                course.NameNonAscii = model.NameNonAscii;
                course.CourseImageUrl = model.CourseImageUrl;
                course.Modified = DateTime.UtcNow;

                await SaveChangeAsync();
            }
        }
    }
}
