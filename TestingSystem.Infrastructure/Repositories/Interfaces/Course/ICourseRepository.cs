using TestingSystem.Data.Common;
using TestingSystem.Data.Models.Course;

namespace TestingSystem.Infrastructure.Repositories.Interfaces.Course
{
    public interface ICourseRepository : IBaseRepository<Data.Entities.Course.Course>
    {
        Task<CourseInfoDto> GetCourseByIdAsync(Guid id);
        Task<PaginatedResponseModel<CourseInfoDto>> GetListCourseAsync(SearchingCourseRequest request);
        Task InsertAsync(Guid courseId, CourseInsertDto model);
        Task UpdateAsync(Guid courseId, CourseUpdateDto model);
        Task DeleteAsync(Guid courseId);
    }
}
