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

        public async Task<IEnumerable<LessionTranslationDtro>> GetListLessionTransByLessionIds(List<Guid> lessionId, string languageCode)
        {
            var result = new List<LessionTranslationDtro>();
            var ctts = await DbSet.Where(ctt => lessionId.Contains(ctt.LessionId) && ctt.LanguageCode == languageCode).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new LessionTranslationDtro()
                {
                    LessonId = item.LessionId,
                    LanguageCode = item.LanguageCode,
                    Title = item.Title,
                    Content = item.Content
                });
            }

            return result;
        }

        public async Task InsertTranslationAsync(Guid lessionId, LessionTranslationDtro model)
        {
            var lesson = await DbSet.FirstOrDefaultAsync(lt => lt.LessionId == lessionId && lt.LanguageCode == model.LanguageCode);

            if (lesson == null)
            {
                var lessonTrans = new Data.Entities.LessionTranslation()
                {
                    Id = Guid.NewGuid(),
                    LessionId = lessionId,
                    LanguageCode = model.LanguageCode,
                    Title = model.Title,
                    Content = model.Content
                };

                await DbSet.AddAsync(lessonTrans);
            }
            else
            {
                lesson.Title = model.Title;
                lesson.Content = model.Content;
            }
            
            await SaveChangeAsync();
        }
    }
}
