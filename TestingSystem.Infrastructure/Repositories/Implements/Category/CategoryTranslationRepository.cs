using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities.Category;
using TestingSystem.Data.Models.Category;
using TestingSystem.Infrastructure.Repositories.Interfaces;
using TestingSystem.Infrastructure.Repositories.Interfaces.Category;

namespace TestingSystem.Infrastructure.Repositories.Implements.Category
{
    public class CategoryTranslationRepository : BaseRepository<Data.Entities.Category.CategoryTranslation>, ICategoryTranslationRepository
    {
        private readonly ILanguageTagRepository _languageTagRepository;
        public CategoryTranslationRepository(TestingSystemDbContext dbContext, ILanguageTagRepository languageTagRepository) : base(dbContext)
        {
            _languageTagRepository = languageTagRepository;
        }

        public async Task DeleteAsync(Guid categoryId)
        {
            var ct = await DbSet.FirstOrDefaultAsync(ct => ct.CategoryId == categoryId);

            if (ct != null)
            {
                await Delete(ct);
            }
        }

        public async Task<IEnumerable<CategoryTranslationDto>> GetCategoryTranslationByIdAsync(Guid categoryId)
        {
            var result = new List<CategoryTranslationDto>();
            var categoryTrans = await DbSet.Where(ct => ct.CategoryId == categoryId).ToListAsync();

            foreach (var category in categoryTrans)
            {
                result.Add(new CategoryTranslationDto()
                {
                    LanguageCode = category.LanguageCode,
                    Name = category.Name,
                    Description = category.Description,
                });
            }
            return result;
        }

        public async Task<IEnumerable<CategoryTranslationDto>> GetListByCategoryId(Guid categoryId, string languageCode)
        {
            var result = new List<CategoryTranslationDto>();
            var categoryTrans = await DbSet.Where(ct => ct.CategoryId == categoryId && ct.LanguageCode == languageCode).ToListAsync();

            foreach (var category in categoryTrans)
            {
                result.Add(new CategoryTranslationDto()
                {
                    LanguageCode = category.LanguageCode,
                    Name = category.Name,
                    Description = category.Description,
                });
            }
            return result;
        }

        public async Task<IEnumerable<CategoryTranslationDto>> GetListByLanguageCode(string languageCode)
        {
            var result = new List<CategoryTranslationDto>();
            var categoryTrans = await DbSet.Where(ct => ct.LanguageCode == languageCode).ToListAsync();

            foreach (var category in categoryTrans)
            {
                result.Add(new CategoryTranslationDto()
                {
                    LanguageCode = category.LanguageCode,
                    Name = category.Name,
                    Description = category.Description,
                });
            }
            return result;
        }

        public async Task InsertTranslationAsync(Guid categoryId, CategoryTranslationDto model)
        {
            var categoryTrans = new CategoryTranslation()
            {
                Id = Guid.NewGuid(),
                CategoryId = categoryId,
                Name = model.Name,
                LanguageCode = model.LanguageCode,
                Description = model.Description
            };

            await DbSet.AddAsync(categoryTrans);

            await SaveChangeAsync();
        }

        public async Task UpdateTranslationAsync(Guid id, CategoryTranslationDto model)
        {
            var ct = await DbSet.FirstOrDefaultAsync(ct => ct.Id == id);

            if (ct != null)
            {
                ct.LanguageCode = model.LanguageCode;
                ct.Name = model.Name;
                ct.Description = model.Description;

                await SaveChangeAsync();
            }

        }
    }
}
