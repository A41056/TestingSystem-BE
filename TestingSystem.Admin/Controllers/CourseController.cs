using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces.Course;
using TestingSystem.Data.Common;
using TestingSystem.Data.Models.Course;

namespace TestingSystem.Admin.Controllers
{
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseInfoDto>> GetCourseById(Guid id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetListCourseAsync([FromQuery]SearchingCourseRequest request)
        {
            var course = await _courseService.GetListCourseAsync(request);
            return Ok(course);
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpPost]
        public async Task<IActionResult> InsertCourse(CourseInsertDto model)
        {
            var courseId = Guid.NewGuid();
            await _courseService.InsertCourseAsync(Guid.NewGuid(), model);
            return Ok();
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpPut("{courseId}")]
        public async Task<IActionResult> UpdateCourse(Guid courseId, CourseUpdateDto model)
        {
            await _courseService.UpdateCourseAsync(courseId, model);
            return Ok();
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpPost("{courseId}/translations")]
        public async Task<IActionResult> InsertCourseTranslation(Guid courseId,CourseInsertOrUpdateTranslationDto model)
        {
            await _courseService.InsertTranslationAsync(courseId, model);
            return Ok();
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpDelete("{courseId}/translations")]
        public async Task<IActionResult> DeleteCourseTranslations(Guid courseId)
        {
            await _courseService.DeleteTranslationsByCourseIdAsync(courseId);
            return Ok();
        }

        [HttpGet("{courseId}/translations")]
        public async Task<ActionResult<IEnumerable<CourseInsertOrUpdateTranslationDto>>> GetCourseTranslations(Guid courseId)
        {
            var translations = await _courseService.GetCourseTranslationsByCourseIdAsync(courseId);
            return Ok(translations);
        }

        [HttpGet("translations/{languageCode}")]
        public async Task<ActionResult<IEnumerable<CourseInsertOrUpdateTranslationDto>>> GetCourseTranslationsByLanguage(string languageCode)
        {
            var translations = await _courseService.GetListByLanguageCode(languageCode);
            return Ok(translations);
        }

        [HttpGet("{courseId}/translations/{languageCode}")]
        public async Task<ActionResult<IEnumerable<CourseInsertOrUpdateTranslationDto>>> GetCourseTranslationsByCourseAndLanguage(Guid courseId, string languageCode)
        {
            var translations = await _courseService.GetListByCourseId(courseId, languageCode);
            return Ok(translations);
        }

        [HttpGet("{courseId}/teachers")]
        public async Task<ActionResult<IEnumerable<CourseTeacherListModel>>> GetCourseTeachers(Guid courseId)
        {
            var teachers = await _courseService.GetListTeacherByCourseIdAsync(courseId);
            return Ok(teachers);
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpPost("{teacherId}")]
        public async Task<IActionResult> InsertTeacher(Guid teacherId, CourseTeacherInsertDto model)
        {
            await _courseService.InsertTeacherAsync(teacherId, model);
            return Ok();
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpPut("teacher/{teacherId}")]
        public async Task<IActionResult> UpdateTeacher(Guid teacherId, CourseTeacherUpdateModel model)
        {
            await _courseService.UpdateTeacherAsync(teacherId, model);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{courseId}")]
        public async Task<IActionResult> DeleteCourse(Guid courseId)
        {
            await _courseService.DeleteCourse(courseId);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{teacherId}")]
        public async Task<IActionResult> DeleteTeacher(Guid teacherId)
        {
            await _courseService.DeleteTeacherAsync(teacherId);
            return Ok();
        }

        [HttpGet("teachers/{teacherId}")]
        public async Task<ActionResult<CourseTeacherSingleModel>> GetCourseTeacherById(Guid teacherId)
        {
            var teacher = await _courseService.GetCourseTeacherByIdAsync(teacherId);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpPost("teachers/{teacherId}/translations")]
        public async Task<IActionResult> InsertTeacherTranslation(Guid teacherId, CourseTeacherTranslationDto model)
        {
            await _courseService.InsertTeacherTranslationAsync(teacherId, model);
            return Ok();
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpDelete("teachers/{teacherId}/translations")]
        public async Task<IActionResult> DeleteTeacherTranslations(Guid teacherId)
        {
            await _courseService.DeleteTeacherTranslationAsync(teacherId);
            return Ok();
        }

        [HttpGet("teachers/{teacherId}/translations")]
        public async Task<ActionResult<IEnumerable<CourseTeacherTranslationDto>>> GetTeacherTranslations(Guid teacherId)
        {
            var translations = await _courseService.GetCourseTeacherTranslationByIdAsync(teacherId);
            return Ok(translations);
        }

        [HttpGet("teachers/translations/{languageCode}")]
        public async Task<ActionResult<IEnumerable<CourseTeacherTranslationDto>>> GetTeacherTranslationsByLanguage(string languageCode)
        {
            var translations = await _courseService.GetListTeacherByLanguageCode(languageCode);
            return Ok(translations);
        }

        [HttpGet("teachers/{teacherId}/translations/{languageCode}")]
        public async Task<ActionResult<IEnumerable<CourseTeacherTranslationDto>>> GetTeacherTranslationsByTeacherAndLanguage(Guid teacherId, string languageCode)
        {
            var translations = await _courseService.GetListByCourseTeacherId(teacherId, languageCode);
            return Ok(translations);
        }

        [HttpGet("{courseId}/details")]
        public async Task<ActionResult<IEnumerable<CourseDetailsDto>>> GetCourseDetails(Guid courseId, string languageCode)
        {
            var details = await _courseService.GetCourseDetailsByCourseIdAsync(courseId, languageCode);
            return Ok(details);
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpPost("{courseDetailId}/details/translations")]
        public async Task<IActionResult> InsertCourseDetailTranslation(Guid courseDetailId, CourseDetailTranslationDto model)
        {
            await _courseService.InsertDetailTranslationAsync(courseDetailId, model);
            return Ok();
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpDelete("{courseDetailId}/details/translations")]
        public async Task<IActionResult> DeleteCourseDetailTranslations(Guid courseDetailId)
        {
            await _courseService.DeleteDetailTranslationsByCourseIdAsync(courseDetailId);
            return Ok();
        }

        [HttpGet("{courseDetailId}/details/translations")]
        public async Task<ActionResult<IEnumerable<CourseDetailTranslationDto>>> GetCourseDetailTranslations(Guid courseDetailId)
        {
            var translations = await _courseService.GetCourseDetailTranslationsByCourseDetailIdAsync(courseDetailId);
            return Ok(translations);
        }

        [HttpGet("details/translations/{languageCode}")]
        public async Task<ActionResult<IEnumerable<CourseDetailTranslationDto>>> GetCourseDetailTranslationsByLanguage(string languageCode)
        {
            var translations = await _courseService.GetListDetailTranslationByLanguageCode(languageCode);
            return Ok(translations);
        }

        [HttpGet("{courseId}/details/translations/{languageCode}")]
        public async Task<ActionResult<IEnumerable<CourseDetailTranslationDto>>> GetCourseDetailTranslationsByCourseAndLanguage(Guid courseId, string languageCode)
        {
            var translations = await _courseService.GetListDetailTranslationByCourseId(courseId, languageCode);
            return Ok(translations);
        }
    }
}
