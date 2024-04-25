using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Db;
using TestingSystem.Data.Models.Category;
using TestingSystem.Infrastructure.Repositories.Interfaces;
using TestingSystem.Infrastructure.Repositories.Interfaces.Category;

namespace TestingSystem.Infrastructure.Repositories.Implements.Category
{
    public class CategoryRepository : BaseRepository<Data.Entities.Category.Category>, ICategoryRepository
    {
        private readonly ILanguageTagRepository _languageTagRepository;
        private readonly ICategoryTranslationRepository _categoryTransRepository;

        public CategoryRepository(TestingSystemDbContext dbContext,
            ILanguageTagRepository languageTagRepository,
            ICategoryTranslationRepository categoryTranslationRepository) : base(dbContext)
        {
            _languageTagRepository = languageTagRepository;
            _categoryTransRepository = categoryTranslationRepository;
        }

        public async Task<bool> CheckCategoryExisted(Guid categoryId)
        {
            return await DbSet.FirstOrDefaultAsync(c => c.Id == categoryId) != null;
        }

        public async Task<CategoryDto> GetCategoryById(Guid categoryId)
        {
            var category = await DbSet.FirstOrDefaultAsync(c => c.Id == categoryId);

            return new CategoryDto()
            {
                NameNonAscii = category.NameNoneAscii,
                SortOrder = category.SortOrder,
                IsActive = category.IsActive.GetValueOrDefault()
            };
        }

        public async Task<IEnumerable<CategoryListModel>> GetCategoryListAsync()
        {
            var languageCode = await _languageTagRepository.GetDefault();

            var categoryList = await DbSet
                .Where(c => !c.Deleted && c.IsActive == true)
                .OrderByDescending(c => c.Created)
                .ThenBy(c => c.SortOrder)
                .ToListAsync();

            var categoryModelList = new List<CategoryListModel>();

            foreach (var category in categoryList)
            {
                var categoryTransList = await _categoryTransRepository.GetListByCategoryId(category.Id, languageCode.Code);
                var categoryTrans = categoryTransList.FirstOrDefault();

                categoryModelList.Add(new CategoryListModel
                {
                    Id = category.Id,
                    Name = categoryTrans?.Name,
                    NameNonAscii = category.NameNoneAscii,
                    SortOrder = category.SortOrder,
                    Description = categoryTrans?.Description,
                    Deleted = category.Deleted,
                    IsActive = category.IsActive.GetValueOrDefault(),
                });
            }

            return categoryModelList;
        }

        public async Task InsertAsync(Guid categoryId, CategoryDto model)
        {
            var category = new Data.Entities.Category.Category
            {
                Id = categoryId,
                NameNoneAscii = model.NameNonAscii,
                SortOrder = model.SortOrder,
                IsActive = model.IsActive,
                Created = DateTime.UtcNow
            };

            await DbSet.AddAsync(category);

            await SaveChangeAsync();
        }

        public async Task SoftDeleteCategoryAsync(Guid categoryId)
        {
            var category = await DbSet.FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category != null)
            {
                category.Deleted = true;
                category.Modified = DateTime.UtcNow;

                await SaveChangeAsync();
            }
        }

        public async Task UpdateCategoryAsync(Guid categoryId, CategoryUpdateModel model)
        {
            var category = await DbSet.FindAsync(categoryId);

            category.NameNoneAscii = model.NameNonAscii;
            category.SortOrder = model.SortOrder;
            category.Modified = DateTime.UtcNow;

            await SaveChangeAsync();
        }
    }
}
