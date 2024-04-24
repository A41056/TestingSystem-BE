using TestingSystem.Data.Models.Course;

namespace TestingSystem.Infrastructure.Repositories.Interfaces.Course
{
    public interface ICourseTeacherTranslationRepository : IBaseRepository<Data.Entities.Course.CourseTeacherTranslation>
    {
        Task InsertTranslationAsync(Guid courseTeacherId, CourseTeacherTranslationDto model);

        Task DeleteAsync(Guid courseTeacherId);

        Task<IEnumerable<CourseTeacherTranslationDto>> GetCourseTeacherTranslationByIdAsync(Guid courseTeacherId);
        Task<IEnumerable<CourseTeacherTranslationDto>> GetListByLanguageCode(string languageCode);
        Task<IEnumerable<CourseTeacherTranslationDto>> GetListByCourseTeacherId(Guid teacherId, string languageCode);
    }
}
