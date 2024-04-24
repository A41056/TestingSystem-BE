using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Db;
using TestingSystem.Data.Models;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Infrastructure.Repositories.Implements
{
    public class LanguageTagRepository : BaseRepository<Data.Entities.LanguageTag>, ILanguageTagRepository
    {
        public LanguageTagRepository(TestingSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<LanguageTagsDto> GetDefault()
        {
            var lt = await DbSet.FirstOrDefaultAsync(lt => lt.IsDefault == true);

            if (lt == null)
                return null;

            return new LanguageTagsDto()
            {
                Code = lt.Code,
                Name = lt.Name,
                IsDefault = lt.IsDefault,
                SortOrder = lt.SortOrder
            };
        }

        public async Task<IEnumerable<LanguageTagsDto>> GetListAsync()
        {
            var tags = new List<LanguageTagsDto>();

            var tagsInDb = await DbSet.Where(lt => lt.IsActive == true).OrderBy(lt => lt.SortOrder).ToListAsync();

            foreach ( var lt in tagsInDb)
            {
                tags.Add(new LanguageTagsDto() 
                { 
                    Code = lt.Code, 
                    Name = lt.Name, 
                    IsDefault = lt.IsDefault, 
                    SortOrder = lt.SortOrder 
                });
            }
            return tags;
        }
    }
}
