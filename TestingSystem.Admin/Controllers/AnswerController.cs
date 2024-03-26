using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Models.Answer;

namespace TestingSystem.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin, Teacher")]
    public class AnswerController : BaseController
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAnswer(CreateOrUpdateAnswerRequest request)
        {
            var answer = await _answerService.AddAnswer(request);
            return Ok(answer);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAnswer(Guid id)
        {
            var result = await _answerService.DeleteAnswer(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var answer = await _answerService.GetById(id);
            if (answer == null)
            {
                return NotFound();
            }
            return Ok(answer);
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetListByQuestionId(SearchingAnswerRequest request)
        {
            var paginatedResponse = await _answerService.GetListByQuestionId(request);
            return Ok(paginatedResponse);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAnswer(AnswerDto request)
        {
            var answer = await _answerService.UpdateAnswer(request);
            return Ok(answer); // Or you can return appropriate response
        }
    }
}
