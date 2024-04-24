using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Data.Models.Course;

namespace TestingSystem.Infrastructure.Repositories.Interfaces.Course
{
    public interface ICourseTeacherRepository : IBaseRepository<Data.Entities.Course.CourseTeacher>
    {
        Task InsertAsync(Guid teacherId, CourseTeacherDto model);

        Task UpdateAsync(Guid teacherId, CourseTeacherUpdateModel model);

        Task DeleteAsync(Guid teacherId);

        Task<IEnumerable<CourseTeacherListModel>> GetListByCourseIdAsync(Guid courseId);
        Task<CourseTeacherSingleModel> GetCourseTeacherByIdAsync(Guid teacherId);

    }
}
