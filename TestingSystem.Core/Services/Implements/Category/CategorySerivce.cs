using TestingSystem.Core.Services.Interfaces.Category;
using TestingSystem.Data.Models.Category;
using TestingSystem.Infrastructure.Repositories.Interfaces.Category;

namespace TestingSystem.Core.Services.Implements.Category
{
    public class CategorySerivce : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryTranslationRepository _categoryTranslationRepository;
        
        public CategorySerivce(ICategoryRepository categoryRepository, ICategoryTranslationRepository categoryTranslationRepository) 
        {
            _categoryRepository = categoryRepository;
            _categoryTranslationRepository = categoryTranslationRepository;
        }

        public async Task<bool> CheckCategoryExisted(Guid categoryId)
        {
            return await _categoryRepository.CheckCategoryExisted(categoryId);
        }

        public async Task DeleteAsync(Guid categoryId)
        {
            await _categoryTranslationRepository.DeleteAsync(categoryId);
        }

        public async Task<CategoryDto> GetCategoryById(Guid categoryId)
        {
            return await _categoryRepository.GetCategoryById(categoryId);
        }

        public async Task<IEnumerable<CategoryListModel>> GetCategoryListAsync()
        {
            return await _categoryRepository.GetCategoryListAsync();
        }

        public async Task<IEnumerable<CategoryTranslationDto>> GetCategoryTranslationByIdAsync(Guid categoryId)
        {
            return await _categoryTranslationRepository.GetCategoryTranslationByIdAsync(categoryId);
        }

        public async Task<IEnumerable<CategoryTranslationDto>> GetListByCategoryId(Guid categoryId, string languageCode)
        {
            return await _categoryTranslationRepository.GetListByCategoryId(categoryId, languageCode);
        }

        public async Task<IEnumerable<CategoryTranslationDto>> GetListByLanguageCode(string languageCode)
        {
            return await _categoryTranslationRepository.GetListByLanguageCode(languageCode);
        }

        public async Task InsertAsync(Guid categoryId, CategoryDto model)
        {
            await _categoryRepository.InsertAsync(categoryId, model);
        }

        public async Task InsertTranslationAsync(Guid categoryId, CategoryTranslationDto model)
        {
            await _categoryTranslationRepository.InsertTranslationAsync(categoryId, model);
        }

        public async Task SoftDeleteCategoryAsync(Guid categoryId)
        {
            await _categoryRepository.SoftDeleteCategoryAsync(categoryId);
        }

        public async Task UpdateCategoryAsync(Guid categoryId, CategoryUpdateModel model)
        {
            await _categoryRepository.UpdateCategoryAsync(categoryId, model);
        }

        public async Task UpdateTranslationAsync(Guid categoryId, CategoryTranslationDto model)
        {
            await _categoryTranslationRepository.UpdateTranslationAsync(categoryId, model);
        }
    }
}
