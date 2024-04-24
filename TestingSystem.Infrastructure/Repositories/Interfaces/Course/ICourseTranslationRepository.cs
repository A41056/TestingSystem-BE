using TestingSystem.Data.Models.Category;
using TestingSystem.Data.Models.Course;

namespace TestingSystem.Infrastructure.Repositories.Interfaces.Course
{
    public interface ICourseTranslationRepository : IBaseRepository<Data.Entities.Course.CourseTranslation>
    {
        Task InsertTranslationAsync(Guid courseId, CourseInsertOrUpdateTranslationDto model);

        Task DeleteTranslationsByCourseIdAsync(Guid courseId);

        Task<IEnumerable<CourseInsertOrUpdateTranslationDto>> GetCourseTranslationsByCourseIdAsync(Guid courseId);
        Task<IEnumerable<CourseInsertOrUpdateTranslationDto>> GetListByLanguageCode(string languageCode);
        Task<IEnumerable<CourseInsertOrUpdateTranslationDto>> GetListByCourseId(Guid courseId, string languageCode);
    }
}
