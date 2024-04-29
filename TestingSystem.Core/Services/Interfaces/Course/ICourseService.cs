using TestingSystem.Data.Common;
using TestingSystem.Data.Models.Course;

namespace TestingSystem.Core.Services.Interfaces.Course
{
    public interface ICourseService
    {
        Task<CourseInfoDto> GetCourseByIdAsync(Guid id);
        Task<PaginatedResponseModel<CourseInfoDto>> GetListCourseAsync(SearchingCourseRequest request);
        Task InsertCourseAsync(Guid courseId, CourseInsertDto model);
        Task UpdateCourseAsync(Guid courseId, CourseUpdateDto model);
        Task InsertTranslationAsync(Guid courseId, CourseInsertOrUpdateTranslationDto model);
        Task DeleteCourse(Guid courseId);
        Task DeleteTranslationsByCourseIdAsync(Guid courseId);
        Task<IEnumerable<CourseInsertOrUpdateTranslationDto>> GetCourseTranslationsByCourseIdAsync(Guid courseId);
        Task<IEnumerable<CourseInsertOrUpdateTranslationDto>> GetListByLanguageCode(string languageCode);
        Task<IEnumerable<CourseInsertOrUpdateTranslationDto>> GetListByCourseId(Guid courseId, string languageCode);

        Task InsertTeacherAsync(Guid teacherId, CourseTeacherInsertDto model);
        Task UpdateTeacherAsync(Guid teacherId, CourseTeacherUpdateModel model);
        Task DeleteTeacherAsync(Guid teacherId);
        Task<IEnumerable<CourseTeacherListModel>> GetListTeacherByCourseIdAsync(Guid courseId);
        Task<CourseTeacherSingleModel> GetCourseTeacherByIdAsync(Guid teacherId);
        Task InsertTeacherTranslationAsync(Guid courseTeacherId, CourseTeacherTranslationDto model);
        Task DeleteTeacherTranslationAsync(Guid courseTeacherId);
        Task<IEnumerable<CourseTeacherTranslationDto>> GetCourseTeacherTranslationByIdAsync(Guid courseTeacherId);
        Task<IEnumerable<CourseTeacherTranslationDto>> GetListTeacherByLanguageCode(string languageCode);
        Task<IEnumerable<CourseTeacherTranslationDto>> GetListByCourseTeacherId(Guid teacherId, string languageCode);

        Task<IEnumerable<CourseDetailsDto>> GetCourseDetailsByCourseIdAsync(Guid courseId, string languageCode);
        Task InsertDetailTranslationAsync(Guid courseDetailId, CourseDetailTranslationDto model);
        Task DeleteDetailTranslationsByCourseIdAsync(Guid courseDetailId);
        Task<IEnumerable<CourseDetailTranslationDto>> GetCourseDetailTranslationsByCourseDetailIdAsync(Guid courseDetailId);
        Task<IEnumerable<CourseDetailTranslationDto>> GetListDetailTranslationByLanguageCode(string languageCode);
        Task<IEnumerable<CourseDetailTranslationDto>> GetListDetailTranslationByCourseId(Guid courseId, string languageCode);
    }
}
