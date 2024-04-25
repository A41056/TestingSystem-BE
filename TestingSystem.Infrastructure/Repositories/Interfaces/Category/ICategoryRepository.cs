using TestingSystem.Data.Models.Category;

namespace TestingSystem.Infrastructure.Repositories.Interfaces.Category
{
    public interface ICategoryRepository : IBaseRepository<Data.Entities.Category.Category>
    {
        Task InsertAsync(Guid categoryId, CategoryDto model);
        Task<CategoryDto> GetCategoryById(Guid categoryId);
        Task<bool> CheckCategoryExisted(Guid categoryId);
        Task<IEnumerable<CategoryListModel>> GetCategoryListAsync();
        Task SoftDeleteCategoryAsync(Guid categoryId);
        Task UpdateCategoryAsync(Guid categoryId, CategoryUpdateModel model);
    }
}
