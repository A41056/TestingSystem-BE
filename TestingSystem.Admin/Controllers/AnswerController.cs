using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Models.Answer;

namespace TestingSystem.Admin.Controllers
{
    public class AnswerController : BaseController
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpPost("add")]
        public async Task<IActionResult> AddAnswer(CreateOrUpdateAnswerRequest request)
        {
            var answer = await _answerService.AddAnswer(request);
            return Ok(answer);
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpPost("{answerId}/translations")]
        public async Task<IActionResult> InsertAnswerTranslation(Guid answerId, AnswerTranslationCreateOrUpdateDto model)
        {
            await _answerService.InsertTranslationAsync(answerId, model);
            return Ok();
        }

        [Authorize(Roles = "Admin, Teacher")]
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

        [HttpGet("{answerId}/translations/{languageCode}")]
        public async Task<ActionResult<IEnumerable<AnswerTranslationCreateOrUpdateDto>>> GetAnswerTranslationsByAnswerAndLanguage(Guid answerId, string languageCode)
        {
            var translations = await _answerService.GetListByAnswerId(answerId, languageCode);
            return Ok(translations);
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAnswer(AnswerDto request)
        {
            var answer = await _answerService.UpdateAnswer(request);
            return Ok(answer); // Or you can return appropriate response
        }
    }
}
