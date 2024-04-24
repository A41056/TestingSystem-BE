using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities.Course;
using TestingSystem.Data.Models.Course;
using TestingSystem.Infrastructure.Repositories.Interfaces.Course;

namespace TestingSystem.Infrastructure.Repositories.Implements.Course
{
    public class CourseDetailTranslationRepository : BaseRepository<Data.Entities.Course.CourseDetailTranslation>, ICourseDetailTranslationRepository
    {
        public CourseDetailTranslationRepository(TestingSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task DeleteTranslationsByCourseIdAsync(Guid courseDetailId)
        {
            var cpt = await DbSet.FirstOrDefaultAsync(cp => cp.CourseDetailId == courseDetailId);

            await Delete(cpt);
        }

        public async Task<IEnumerable<CourseDetailTranslationDto>> GetCourseDetailTranslationsByCourseDetailIdAsync(Guid courseDetailId)
        {
            var result = new List<CourseDetailTranslationDto>();
            var ctts = await DbSet.Where(ctt => ctt.CourseDetailId == courseDetailId).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new CourseDetailTranslationDto()
                {
                    LanguageCode = item.LanguageCode,
                    CourseDetailId = item.CourseDetailId,
                    TabName = item.TabName,
                    Title = item.Title,
                    Content = item.Content,
                });
            }

            return result;
        }

        public async Task<IEnumerable<CourseDetailTranslationDto>> GetListByCourseId(Guid courseId, string languageCode)
        {
            var result = new List<CourseDetailTranslationDto>();
            var ctts = await DbSet.Where(ctt => ctt.CourseDetailId == courseId && ctt.LanguageCode == languageCode).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new CourseDetailTranslationDto()
                {
                    LanguageCode = item.LanguageCode,
                    CourseDetailId = item.CourseDetailId,
                    TabName = item.TabName,
                    Title = item.Title,
                    Content = item.Content,
                });
            }

            return result;
        }

        public async Task<IEnumerable<CourseDetailTranslationDto>> GetListByLanguageCode(string languageCode)
        {
            var result = new List<CourseDetailTranslationDto>();
            var ctts = await DbSet.Where(ctt => ctt.LanguageCode == languageCode).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new CourseDetailTranslationDto()
                {
                    LanguageCode = item.LanguageCode,
                    CourseDetailId = item.CourseDetailId,
                    TabName = item.TabName,
                    Title = item.Title,
                    Content = item.Content,
                });
            }

            return result;
        }

        public async Task InsertTranslationAsync(Guid courseDetailId, CourseDetailTranslationDto model)
        {
            var courseDetailTrans = new CourseDetailTranslation()
            {
                LanguageCode = model.LanguageCode,
                CourseDetailId = courseDetailId,
                TabName = model.TabName,
                Title = model.Title,
                Content = model.Content
            };

            await DbSet.AddAsync(courseDetailTrans);
            await SaveChangeAsync();
        }
    }
}
