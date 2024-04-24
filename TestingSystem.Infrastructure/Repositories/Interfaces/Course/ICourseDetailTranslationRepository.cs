using TestingSystem.Data.Models.Course;

namespace TestingSystem.Infrastructure.Repositories.Interfaces.Course
{
    public interface ICourseDetailTranslationRepository : IBaseRepository<Data.Entities.Course.CourseDetailTranslation>
    {
        Task InsertTranslationAsync(Guid courseDetailId, CourseDetailTranslationDto model);

        Task DeleteTranslationsByCourseIdAsync(Guid courseDetailId);

        Task<IEnumerable<CourseDetailTranslationDto>> GetCourseDetailTranslationsByCourseDetailIdAsync(Guid courseDetailId);
        Task<IEnumerable<CourseDetailTranslationDto>> GetListByLanguageCode(string languageCode);
        Task<IEnumerable<CourseDetailTranslationDto>> GetListByCourseId(Guid courseId, string languageCode);
    }
}
