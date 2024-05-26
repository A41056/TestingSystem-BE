using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Models.Exam;

namespace TestingSystem.Admin.Controllers
{
    public class ExamController : BaseController
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [Authorize (Roles = "Admin, Teacher")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateExam(CreateOrUpdateExamRequest request)
        {
            var exam = await _examService.CreateExam(request);
            return Ok();
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAnswer(Guid id)
        {
            var result = await _examService.DeleteAnswer(id);
            return Ok(result); // Or you can return appropriate response based on the result
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var exam = await _examService.GetById(id);
            if (exam == null)
            {
                return NotFound(); // Or any appropriate response
            }
            return Ok(exam);
        }

        [HttpGet("lesson/{lessonId}")]
        public async Task<IActionResult> GetByLessonId(Guid lessonId)
        {
            var exam = await _examService.GetByLessonId(lessonId);
            if (exam == null)
            {
                return NotFound(); // Or any appropriate response
            }
            return Ok(exam);
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetExamDetail(Guid id)
        {
            try
            {
                var paginatedResponse = await _examService.GetDetail(id);
                return Ok(paginatedResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] SearchingExamRequest request)
        {
            try
            {
                var paginatedResponse = await _examService.GetList(request);
                return Ok(paginatedResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateExam(ExamDto request)
        {
            var exam = await _examService.UpdateExam(request);
            return Ok(exam); // Or you can return appropriate response
        }
    }
}
