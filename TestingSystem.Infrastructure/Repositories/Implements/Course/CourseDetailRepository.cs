using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Db;
using TestingSystem.Data.Models.Course;
using TestingSystem.Infrastructure.Repositories.Interfaces.Course;

namespace TestingSystem.Infrastructure.Repositories.Implements.Course
{
    public class CourseDetailRepository : BaseRepository<Data.Entities.Course.CourseDetail>, ICourseDetailRepository
    {
        public CourseDetailRepository(TestingSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<CourseDetailsDto>> GetCourseDetailsByCourseIdAsync(Guid courseId, string languageCode)
        {
            var courseDetails = await DbSet
                .Where(cd => cd.CourseId == courseId)
                .OrderBy(cd => cd.SortOrder)
                .Select(cd => new CourseDetailsDto
                {
                    TabName = cd.CourseDetailTranslations
                        .FirstOrDefault(cdt => cdt.LanguageCode == languageCode)!.TabName,
                    CourseId = cd.CourseId,
                    Title = cd.CourseDetailTranslations
                        .FirstOrDefault(cdt => cdt.LanguageCode == languageCode)!.Title,
                    SortOrder = cd.SortOrder.GetValueOrDefault(),
                    Content = cd.CourseDetailTranslations
                        .FirstOrDefault(cdt => cdt.LanguageCode == languageCode)!.Content
                })
                .ToListAsync();

            return courseDetails;
        }
    }
}
