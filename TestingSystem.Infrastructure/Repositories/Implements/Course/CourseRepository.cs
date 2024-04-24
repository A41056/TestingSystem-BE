using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;
using TestingSystem.Data.Common;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities.Course;
using TestingSystem.Data.Models.Course;
using TestingSystem.Infrastructure.Repositories.Interfaces;
using TestingSystem.Infrastructure.Repositories.Interfaces.Course;

namespace TestingSystem.Infrastructure.Repositories.Implements.Course
{
    public class CourseRepository : BaseRepository<Data.Entities.Course.Course>, ICourseRepository
    {
        private readonly ICourseDetailRepository _courseDetailRepository;
        private readonly ILanguageTagRepository _languageTagRepository;

        public CourseRepository(TestingSystemDbContext dbContext, ILanguageTagRepository languageTagRepository, ICourseDetailRepository courseDetailRepository) : base(dbContext)
        {
            _courseDetailRepository = courseDetailRepository;
            _languageTagRepository = languageTagRepository;
        }

        public async Task DeleteAsync(Guid courseId)
        {
            var course = await DbSet.FirstOrDefaultAsync(c => c.Id == courseId);

            if (course != null)
                await Delete(course);
        }

        public async Task<CourseInfoDto> GetCourseByIdAsync(Guid id)
        {
            var course = await DbSet.FirstOrDefaultAsync(c => c.Id == id);

            return new CourseInfoDto()
            {
                Id = course.Id,
                Status = course.Status,
                CategoryId = course.CategoryId,
                Created = course.Created,
                Modified = course.Modified,
                NameNonAscii = course.NameNonAscii,
                ProductType = (short)course.ProductType,
                IsHot = course.IsHot.GetValueOrDefault(),
            };
        }

        public async Task<PaginatedResponseModel<CourseInfoDto>> GetListCourseAsync(SearchingCourseRequest request)
        {
            var defaultLanguageCode = await _languageTagRepository.GetDefault();
            var data = new List<CourseInfoDto>();

            Expression<Func<Data.Entities.Course.Course, bool>> filter = course =>
                (request.NameNonAscii == null || course.NameNonAscii.Contains(request.NameNonAscii)) &&
                (request.CategoryId == null || course.CategoryId == request.CategoryId) &&
                (string.IsNullOrEmpty(request.Keyword) || course.FullTextSearch.Contains(request.Keyword));

            Func<IQueryable<Data.Entities.Course.Course>, IOrderedQueryable<Data.Entities.Course.Course>> orderBy = query => query.OrderBy(x => x.Created);

            var paginationSet = await GetPaginatedDataByRequest(request, filter, orderBy,
                c => c.CourseTranslations.Where(ct => ct.LanguageCode == defaultLanguageCode.Code && ct.CourseId == c.Id));

            foreach (var item in paginationSet.Data)
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
                    ProductType = item.ProductType,
                    CourseImageUrl = item.CourseImageUrl,
                    FullTextSearch = item.FullTextSearch,
                    Created = item.Created,
                    Modified = item.Modified,
                });
            }

            var mappedPaginationSet = new PaginatedResponseModel<CourseInfoDto>(data, paginationSet.TotalRecords, paginationSet.PageNum, paginationSet.PageSize);

            return mappedPaginationSet;
        }

        public async Task InsertAsync(Guid courseId, CourseInfoDto model)
        {
            var course = new Data.Entities.Course.Course()
            {
                Id = courseId,
                Status = model.Status,
                CategoryId = model.CategoryId,
                NameNonAscii = model.NameNonAscii,
                FullTextSearch = model.FullTextSearch,
                ProductType = (short)model.ProductType,
                IsHot = model.IsHot,
                Tags = JsonConvert.SerializeObject(model.Tags)
            };

            await DbSet.AddAsync(course);

            await SaveChangeAsync();
        }

        public async Task UpdateAsync(Guid courseId, CourseInfoDto model)
        {
            var course = await DbSet.FirstOrDefaultAsync(c => c.Id == courseId);

            if (course != null)
            {
                course.CategoryId = model.CategoryId;
                course.AuthorId = model.AuthorId;
                course.Status = model.Status;
                course.NameNonAscii = model.NameNonAscii;
                course.IsHot = model.IsHot;
                course.Tags = model.Tags;
                course.ProductType = model.ProductType;
                course.CourseImageUrl = model.CourseImageUrl;
                course.FullTextSearch = model.FullTextSearch;
                course.Modified = DateTime.UtcNow;

                await SaveChangeAsync();
            }
        }
    }
}
