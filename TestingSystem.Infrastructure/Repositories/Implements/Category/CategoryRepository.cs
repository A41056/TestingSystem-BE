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
                    LinkUrl = category.LinkUrl,
                    SortOrder = category.SortOrder,
                    Description = categoryTrans?.Description,
                    ParentId = category.ParentId,
                    Deleted = category.Deleted,
                    CategoryType = (short)category.CategoryType,
                    IsActive = category.IsActive.GetValueOrDefault(),
                    Level = category.Level
                });
            }

            return categoryModelList;
        }

        public async Task InsertAsync(Guid categoryId, CategoryDto model)
        {
            var level = 0;
            if (model.ParentId != null)
            {
                var parent = await DbSet.FirstOrDefaultAsync(c => c.Id == model.ParentId);
                level = parent.Level + 1;
            }

            var category = new Data.Entities.Category.Category
            {
                Id = categoryId,
                NameNoneAscii = model.NameNonAscii,
                LinkUrl = model.LinkUrl,
                SortOrder = model.SortOrder,
                ParentId = model.ParentId,
                CategoryType = (int)model.CategoryType,
                IsActive = model.IsActive,
                Level = level,
                Identifier = model.Identifier,
                ImageFileId = model.ImageFileId,
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

            var level = 0;
            if (model.ParentId != null)
            {
                var parent = await DbSet.FindAsync(model.ParentId);
                level = parent.Level + 1;
            }

            category.NameNoneAscii = model.NameNonAscii;
            category.LinkUrl = model.LinkUrl;
            category.SortOrder = model.SortOrder;
            category.ParentId = model.ParentId;
            category.CategoryType = (int)model.CategoryType;
            category.Level = level;
            category.Modified = DateTime.UtcNow;
            category.ImageFileId = model.ImageFileId;

            await SaveChangeAsync();
        }
    }
}
