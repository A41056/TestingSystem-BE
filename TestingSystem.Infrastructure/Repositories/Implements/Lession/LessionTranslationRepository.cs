using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Db;
using TestingSystem.Data.Models;
using TestingSystem.Infrastructure.Repositories.Interfaces.Lession;

namespace TestingSystem.Infrastructure.Repositories.Implements.Lession
{
    public class LessionTranslationRepository : BaseRepository<Data.Entities.LessionTranslation>, ILessionTranslationRepository
    {
        public LessionTranslationRepository(TestingSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task DeleteAsync(Guid lessionId)
        {
            var course = await DbSet.FirstOrDefaultAsync(c => c.LessionId == lessionId);

            if (course != null)
                await Delete(course);
        }

        public async Task<IEnumerable<LessionTranslationDtro>> GetLessionTranslationByIdAsync(Guid lessionId)
        {
            var result = new List<LessionTranslationDtro>();
            var ctts = await DbSet.Where(ctt => ctt.LessionId == lessionId).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new LessionTranslationDtro()
                {
                    LanguageCode = item.LanguageCode,
                    Title = item.Title,
                    Content = item.Content
                });
            }

            return result;
        }

        public async Task<IEnumerable<LessionTranslationDtro>> GetListLessionByLanguageCode(string languageCode)
        {
            var result = new List<LessionTranslationDtro>();
            var ctts = await DbSet.Where(ctt => ctt.LanguageCode == languageCode).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new LessionTranslationDtro()
                {
                    LanguageCode = item.LanguageCode,
                    Title = item.Title,
                    Content = item.Content
                });
            }

            return result;
        }

        public async Task<IEnumerable<LessionTranslationDtro>> GetListLessionByLessionId(Guid lessionId, string languageCode)
        {
            var result = new List<LessionTranslationDtro>();
            var ctts = await DbSet.Where(ctt => ctt.LessionId == lessionId && ctt.LanguageCode == languageCode).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new LessionTranslationDtro()
                {
                    LanguageCode = item.LanguageCode,
                    Title = item.Title,
                    Content = item.Content
                });
            }

            return result;
        }

        public Task InsertTranslationAsync(Guid lessionId, LessionTranslationDtro model)
        {
            throw new NotImplementedException();
        }
    }
}
