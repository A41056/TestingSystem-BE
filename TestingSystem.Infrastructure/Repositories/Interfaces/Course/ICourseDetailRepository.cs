using TestingSystem.Data.Models.Course;

namespace TestingSystem.Infrastructure.Repositories.Interfaces.Course
{
    public interface ICourseDetailRepository : IBaseRepository<Data.Entities.Course.CourseDetail>
    {
        Task<IEnumerable<CourseDetailsDto>> GetCourseDetailsByCourseIdAsync(Guid courseId, string languageCode);

        //Task<IEnumerable<CourseCurriculumModel>> GetCourseCurriculumByCourseIdAsync(Guid courseId);
    }
}
