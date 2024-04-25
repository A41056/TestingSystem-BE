using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces.Category;
using TestingSystem.Data.Models.Category;

namespace TestingSystem.Admin.Controllers
{
    [Authorize(Roles = "Admin, Teacher")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategory(CategoryDto model)
        {
            await _categoryService.InsertAsync(Guid.NewGuid(), model);
            return Ok();
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            await _categoryService.DeleteAsync(categoryId);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryListModel>>> GetCategoryList()
        {
            var categoryList = await _categoryService.GetCategoryListAsync();
            return Ok(categoryList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(Guid id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return Ok(category);
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(Guid categoryId, CategoryUpdateModel model)
        {
            await _categoryService.UpdateCategoryAsync(categoryId, model);
            return Ok();
        }

        [HttpPost("{categoryId}/translations")]
        public async Task<IActionResult> InsertTranslation(Guid categoryId, CategoryTranslationDto model)
        {
            await _categoryService.InsertTranslationAsync(categoryId, model);
            return Ok();
        }

        [HttpPut("{categoryId}/translations")]
        public async Task<IActionResult> UpdateTranslation(Guid categoryId, CategoryTranslationDto model)
        {
            await _categoryService.UpdateTranslationAsync(categoryId, model);
            return Ok();
        }

        [HttpGet("translations/{languageCode}")]
        public async Task<ActionResult<IEnumerable<CategoryTranslationDto>>> GetCategoryTranslations(string languageCode)
        {
            var translations = await _categoryService.GetListByLanguageCode(languageCode);
            return Ok(translations);
        }

        [HttpGet("{categoryId}/translations/{languageCode}")]
        public async Task<ActionResult<IEnumerable<CategoryTranslationDto>>> GetCategoryTranslations(Guid categoryId, string languageCode)
        {
            var translations = await _categoryService.GetListByCategoryId(categoryId, languageCode);
            return Ok(translations);
        }

        [HttpGet("{categoryId}/translations")]
        public async Task<ActionResult<IEnumerable<CategoryTranslationDto>>> GetCategoryTranslations(Guid categoryId)
        {
            var translations = await _categoryService.GetCategoryTranslationByIdAsync(categoryId);
            return Ok(translations);
        }
    }
}
