using TestingSystem.Data.Models.Category;

namespace TestingSystem.Core.Services.Interfaces.Category
{
    public interface ICategoryService
    {
        Task InsertAsync(Guid categoryId, CategoryDto model);
        Task<bool> CheckCategoryExisted(Guid categoryId);
        Task<IEnumerable<CategoryListModel>> GetCategoryListAsync();
        Task SoftDeleteCategoryAsync(Guid categoryId);
        Task UpdateCategoryAsync(Guid categoryId, CategoryUpdateModel model);
        Task InsertTranslationAsync(Guid categoryId, CategoryTranslationDto model);
        Task<CategoryDto> GetCategoryById(Guid categoryId);

        Task DeleteAsync(Guid categoryId);
        Task UpdateTranslationAsync(Guid categoryId, CategoryTranslationDto model);
        Task<IEnumerable<CategoryTranslationDto>> GetListByLanguageCode(string languageCode);
        Task<IEnumerable<CategoryTranslationDto>> GetListByCategoryId(Guid categoryId, string languageCode);
        Task<IEnumerable<CategoryTranslationDto>> GetCategoryTranslationByIdAsync(Guid categoryId);
    }
}
