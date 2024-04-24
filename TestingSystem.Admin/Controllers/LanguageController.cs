using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces.Language;
using TestingSystem.Data.Models;

namespace TestingSystem.Admin.Controllers
{
    public class LanguageController : BaseController
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet("default")]
        public async Task<ActionResult<LanguageTagsDto>> GetDefaultLanguage()
        {
            var defaultLanguage = await _languageService.GetDefault();
            if (defaultLanguage == null)
            {
                return NotFound();
            }
            return Ok(defaultLanguage);
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<LanguageTagsDto>>> GetLanguageList()
        {
            var languageList = await _languageService.GetListAsync();
            if (languageList == null)
            {
                return NotFound();
            }
            return Ok(languageList);
        }
    }
}
