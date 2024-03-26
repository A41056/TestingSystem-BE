using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Models.Question;

namespace TestingSystem.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Teacher")]
    public class QuestionController : BaseController
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddQuestion(CreateOrUpdateQuestionRequest request)
        {
            var question = await _questionService.AddQuestion(request);
            return Ok(question); // Or you can return CreatedAtAction or any appropriate response
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteQuestion(Guid id)
        {
            var result = await _questionService.DeleteQuestion(id);
            return Ok(result); // Or you can return appropriate response based on the result
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var question = await _questionService.GetById(id);
            if (question == null)
            {
                return NotFound(); // Or any appropriate response
            }
            return Ok(question);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetListByExamId(SearchingQuestionRequest request)
        {
            var paginatedResponse = await _questionService.GetListByExamId(request);
            return Ok(paginatedResponse);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateQuestion(QuestionDto request)
        {
            var question = await _questionService.UpdateQuestion(request);
            return Ok(question); // Or you can return appropriate response
        }
    }
}
