using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces.Lession;
using TestingSystem.Data.Models;

namespace TestingSystem.Admin.Controllers
{
    [Authorize(Roles = "Admin, Teacher")]
    public class LessionController : BaseController
    {
        private readonly ILessionService _lessionService;

        public LessionController(ILessionService lessionService)
        {
            _lessionService = lessionService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertLession(Guid lessionId, LessionDto model)
        {
            await _lessionService.InsertAsync(lessionId, model);
            return Ok();
        }

        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<IEnumerable<LessionDto>>> GetLessionsByCourseId(Guid courseId)
        {
            var lessions = await _lessionService.GetLessionListByCourseIdAsync(courseId);
            return Ok(lessions);
        }

        [HttpGet("{lessionId}")]
        public async Task<ActionResult<LessionDto>> GetLessionById(Guid lessionId)
        {
            var lession = await _lessionService.GetLessionByIdAsync(lessionId);
            if (lession == null)
            {
                return NotFound();
            }
            return Ok(lession);
        }

        [HttpDelete("{lessionId}")]
        public async Task<IActionResult> DeleteLession(Guid lessionId)
        {
            await _lessionService.DeleteLessionAsync(lessionId);
            return Ok();
        }

        [HttpPut("{lessionId}")]
        public async Task<IActionResult> UpdateLession(Guid lessionId, LessionDto model)
        {
            await _lessionService.UpdateLessionAsync(lessionId, model);
            return Ok();
        }

        [HttpPost("{lessionId}/translations")]
        public async Task<IActionResult> InsertLessionTranslation(Guid lessionId, LessionTranslationDtro model)
        {
            await _lessionService.InsertTranslationAsync(lessionId, model);
            return Ok();
        }

        [HttpDelete("{lessionId}/translations")]
        public async Task<IActionResult> DeleteLessionTranslations(Guid lessionId)
        {
            await _lessionService.DeleteLessionTranslationAsync(lessionId);
            return Ok();
        }

        [HttpGet("{lessionId}/translations")]
        public async Task<ActionResult<IEnumerable<LessionTranslationDtro>>> GetLessionTranslations(Guid lessionId)
        {
            var translations = await _lessionService.GetLessionTranslationByIdAsync(lessionId);
            return Ok(translations);
        }

        [HttpGet("translations/{languageCode}")]
        public async Task<ActionResult<IEnumerable<LessionTranslationDtro>>> GetLessionTranslationsByLanguage(string languageCode)
        {
            var translations = await _lessionService.GetListLessionByLanguageCode(languageCode);
            return Ok(translations);
        }

        [HttpGet("{lessionId}/translations/{languageCode}")]
        public async Task<ActionResult<IEnumerable<LessionTranslationDtro>>> GetLessionTranslationsByLessionAndLanguage(Guid lessionId, string languageCode)
        {
            var translations = await _lessionService.GetListLessionByLessionId(lessionId, languageCode);
            return Ok(translations);
        }
    }
}
