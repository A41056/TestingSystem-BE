using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces.Lession;
using TestingSystem.Data.Models;

namespace TestingSystem.Admin.Controllers
{
    public class LessonController : BaseController
    {
        private readonly ILessionService _lessionService;

        public LessonController(ILessionService lessionService)
        {
            _lessionService = lessionService;
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpPost]
        public async Task<IActionResult> InsertLession(LessionDto model)
        {
            await _lessionService.InsertAsync(Guid.NewGuid(), model);
            return Ok();
        }

        [HttpGet("{courseId}/lessons")]
        public async Task<ActionResult<IEnumerable<LessionDto>>> GetLessionsByCourseId(Guid courseId)
        {
            var lessions = await _lessionService.GetLessionListByCourseIdAsync(courseId);
            return Ok(lessions);
        }

        [HttpGet("{courseId}/lessons/{languageCode}")]
        public async Task<ActionResult<IEnumerable<LessionDto>>> GetLessionsByCourseId(Guid courseId, string languageCode)
        {
            var lessions = await _lessionService.GetLessionTransListByCourseIdAsync(courseId, languageCode);
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

        [Authorize(Roles = "Admin, Teacher")]
        [HttpDelete("{lessionId}")]
        public async Task<IActionResult> DeleteLession(Guid lessionId)
        {
            await _lessionService.DeleteLessionAsync(lessionId);
            return Ok();
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpPut("{lessionId}")]
        public async Task<IActionResult> UpdateLession(Guid lessionId, LessionDto model)
        {
            await _lessionService.UpdateLessionAsync(lessionId, model);
            return Ok();
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpPost("{lessionId}/translations")]
        public async Task<IActionResult> InsertLessionTranslation(Guid lessionId, LessionTranslationDtro model)
        {
            await _lessionService.InsertTranslationAsync(lessionId, model);
            return Ok();
        }

        [Authorize(Roles = "Admin, Teacher")]
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

        [HttpPost("list-translations/{languageCode}")]
        public async Task<ActionResult<IEnumerable<LessionTranslationDtro>>> GetLessionTranslationsByLessionsAndLanguage(string languageCode, [FromBody] List<Guid> lessionIds)
        {
            var translations = await _lessionService.GetListLessionTransByLessionIds(lessionIds, languageCode);
            return Ok(translations);
        }
    }
}
