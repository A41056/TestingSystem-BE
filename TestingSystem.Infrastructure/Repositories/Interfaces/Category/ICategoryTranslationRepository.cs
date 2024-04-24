using TestingSystem.Data.Models.Category;

namespace TestingSystem.Infrastructure.Repositories.Interfaces.Category
{
    public interface ICategoryTranslationRepository : IBaseRepository<Data.Entities.Category.CategoryTranslation>
    {
        Task InsertTranslationAsync(Guid categoryId, CategoryTranslationDto model);
        Task DeleteAsync(Guid categoryId);
        Task UpdateTranslationAsync(Guid categoryId, CategoryTranslationDto model);
        Task<IEnumerable<CategoryTranslationDto>> GetListByLanguageCode(string languageCode);
        Task<IEnumerable<CategoryTranslationDto>> GetListByCategoryId(Guid categoryId, string languageCode);
        Task<IEnumerable<CategoryTranslationDto>> GetCategoryTranslationByIdAsync(Guid categoryId);
    }
}
