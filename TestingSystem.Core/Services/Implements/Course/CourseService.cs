using TestingSystem.Core.Services.Interfaces.Course;
using TestingSystem.Data.Common;
using TestingSystem.Data.Models.Course;
using TestingSystem.Infrastructure.Repositories.Interfaces.Course;

namespace TestingSystem.Core.Services.Implements.Course
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseTranslationRepository _courseTranslationRepository;
        private readonly ICourseDetailRepository _courseDetailRepository;
        private readonly ICourseDetailTranslationRepository _courseDetailTranslationRepository;
        private readonly ICourseTeacherRepository _courseTeacherRepository;
        private readonly ICourseTeacherTranslationRepository _courseTeacherTranslationRepository;

        public CourseService(ICourseRepository courseRepository,
            ICourseTranslationRepository courseTranslationRepository,
            ICourseDetailRepository courseDetailRepository,
            ICourseDetailTranslationRepository courseDetailTranslationRepository,
            ICourseTeacherRepository courseTeacherRepository,
            ICourseTeacherTranslationRepository courseTeacherTranslationRepository)
        {
            _courseRepository = courseRepository;
            _courseTranslationRepository = courseTranslationRepository;
            _courseDetailRepository = courseDetailRepository;
            _courseDetailTranslationRepository = courseDetailTranslationRepository;
            _courseTeacherRepository = courseTeacherRepository;
            _courseTeacherTranslationRepository = courseTeacherTranslationRepository;
        }

        public async Task DeleteDetailTranslationsByCourseIdAsync(Guid courseDetailId)
        {
            await _courseDetailTranslationRepository.DeleteTranslationsByCourseIdAsync(courseDetailId);
        }

        public async Task DeleteTeacherAsync(Guid teacherId)
        {
            await _courseTeacherRepository.DeleteAsync(teacherId);
        }

        public async Task DeleteTeacherTranslationAsync(Guid courseTeacherId)
        {
            await _courseTeacherTranslationRepository.DeleteAsync(courseTeacherId);
        }

        public async Task DeleteTranslationsByCourseIdAsync(Guid courseId)
        {
            await _courseTranslationRepository.DeleteTranslationsByCourseIdAsync(courseId);
        }

        public Task<CourseInfoDto> GetCourseByIdAsync(Guid id)
        {
            return _courseRepository.GetCourseByIdAsync(id);
        }

        public Task<IEnumerable<CourseDetailsDto>> GetCourseDetailsByCourseIdAsync(Guid courseId, string languageCode)
        {
            return _courseDetailRepository.GetCourseDetailsByCourseIdAsync(courseId, languageCode);
        }

        public Task<IEnumerable<CourseDetailTranslationDto>> GetCourseDetailTranslationsByCourseDetailIdAsync(Guid courseDetailId)
        {
            return _courseDetailTranslationRepository.GetCourseDetailTranslationsByCourseDetailIdAsync(courseDetailId);
        }

        public Task<CourseTeacherSingleModel> GetCourseTeacherByIdAsync(Guid teacherId)
        {
            return _courseTeacherRepository.GetCourseTeacherByIdAsync(teacherId);
        }

        public Task<IEnumerable<CourseTeacherTranslationDto>> GetCourseTeacherTranslationByIdAsync(Guid courseTeacherId)
        {
            return _courseTeacherTranslationRepository.GetCourseTeacherTranslationByIdAsync(courseTeacherId);
        }

        public Task<IEnumerable<CourseInsertOrUpdateTranslationDto>> GetCourseTranslationsByCourseIdAsync(Guid courseId)
        {
            return _courseTranslationRepository.GetCourseTranslationsByCourseIdAsync(courseId);
        }

        public async Task<IEnumerable<CourseInsertOrUpdateTranslationDto>> GetListByCourseId(Guid courseId, string languageCode)
        {
            return await _courseTranslationRepository.GetListByCourseId(courseId, languageCode);
        }

        public async Task<IEnumerable<CourseTeacherTranslationDto>> GetListByCourseTeacherId(Guid teacherId, string languageCode)
        {
            return await _courseTeacherTranslationRepository.GetListByCourseTeacherId(teacherId, languageCode);
        }

        public async Task<IEnumerable<CourseInsertOrUpdateTranslationDto>> GetListByLanguageCode(string languageCode)
        {
            return await _courseTranslationRepository.GetListByLanguageCode(languageCode);
        }

        public Task<PaginatedResponseModel<CourseInfoDto>> GetListCourseAsync(SearchingCourseRequest request)
        {
            return _courseRepository.GetListCourseAsync(request);
        }

        public async Task<IEnumerable<CourseDetailTranslationDto>> GetListDetailTranslationByCourseId(Guid courseId, string languageCode)
        {
            return await _courseDetailTranslationRepository.GetListByCourseId(courseId, languageCode);
        }

        public async Task<IEnumerable<CourseDetailTranslationDto>> GetListDetailTranslationByLanguageCode(string languageCode)
        {
            return await _courseDetailTranslationRepository.GetListByLanguageCode(languageCode);
        }

        public Task<IEnumerable<CourseTeacherListModel>> GetListTeacherByCourseIdAsync(Guid courseId)
        {
            return _courseTeacherRepository.GetListByCourseIdAsync(courseId);
        }

        public Task<IEnumerable<CourseTeacherTranslationDto>> GetListTeacherByLanguageCode(string languageCode)
        {
            throw new NotImplementedException();
        }

        public async Task InsertCourseAsync(Guid courseId, CourseInsertDto model)
        {
            await _courseRepository.InsertAsync(courseId, model);
        }

        public async Task InsertDetailTranslationAsync(Guid courseDetailId, CourseDetailTranslationDto model)
        {
            await _courseDetailTranslationRepository.InsertTranslationAsync(courseDetailId, model);
        }

        public async Task InsertTeacherAsync(Guid teacherId, CourseTeacherInsertDto model)
        {
            await _courseTeacherRepository.InsertAsync(teacherId, model);
        }

        public async Task InsertTeacherTranslationAsync(Guid courseTeacherId, CourseTeacherTranslationDto model)
        {
            await _courseTeacherTranslationRepository.InsertTranslationAsync(courseTeacherId, model);
        }

        public async Task InsertTranslationAsync(Guid courseId, CourseInsertOrUpdateTranslationDto model)
        {
            await _courseTranslationRepository.InsertTranslationAsync(courseId, model);
        }

        public async Task UpdateCourseAsync(Guid courseId, CourseInfoDto model)
        {
            await _courseRepository.UpdateAsync(courseId, model);
        }

        public async Task UpdateTeacherAsync(Guid teacherId, CourseTeacherUpdateModel model)
        {
            await _courseTeacherRepository.UpdateAsync(teacherId, model);
        }
    }
}
