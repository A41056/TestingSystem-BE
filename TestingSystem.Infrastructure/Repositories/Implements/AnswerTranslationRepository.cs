using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Db;
using TestingSystem.Data.Models.Answer;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Infrastructure.Repositories.Implements
{
    public class AnswerTranslationRepository : BaseRepository<Data.Entities.AnswerTranslation>, IAnswerTranslationRepository
    {
        public AnswerTranslationRepository(TestingSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task DeleteTranslationsByAnswerIdAsync(Guid AnswerId)
        {
            var AnswerTrans = await DbSet.FirstOrDefaultAsync(c => c.AnswerId == AnswerId);

            if (AnswerTrans != null)
                await Delete(AnswerTrans);
        }

        public async Task<IEnumerable<AnswerTranslationCreateOrUpdateDto>> GetListByLanguageCode(string languageCode)
        {
            var result = new List<AnswerTranslationCreateOrUpdateDto>();
            var ctts = await DbSet.Where(ctt => ctt.LanguageCode == languageCode).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new AnswerTranslationCreateOrUpdateDto()
                {
                    AnswerId = item.AnswerId,
                    LanguageCode = item.LanguageCode,
                    Content = item.Content,
                });
            }

            return result;
        }

        public async Task<IEnumerable<AnswerTranslationCreateOrUpdateDto>> GetListByAnswerId(Guid AnswerId, string languageCode)
        {
            var result = new List<AnswerTranslationCreateOrUpdateDto>();
            var ctts = await DbSet.Where(ctt => ctt.AnswerId == AnswerId && ctt.LanguageCode == languageCode).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new AnswerTranslationCreateOrUpdateDto()
                {
                    AnswerId = item.AnswerId,
                    LanguageCode = item.LanguageCode,
                    Content = item.Content,
                });
            }

            return result;
        }

        public async Task<IEnumerable<AnswerTranslationCreateOrUpdateDto>> GetAnswerTranslationsByAnswerIdAsync(Guid AnswerId)
        {
            var result = new List<AnswerTranslationCreateOrUpdateDto>();
            var ctts = await DbSet.Where(ctt => ctt.AnswerId == AnswerId).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new AnswerTranslationCreateOrUpdateDto()
                {
                    AnswerId = item.AnswerId,
                    LanguageCode = item.LanguageCode,
                    Content = item.Content,
                });
            }

            return result;
        }

        public async Task InsertTranslationAsync(Guid AnswerId, AnswerTranslationCreateOrUpdateDto model)
        {
            var course = await DbSet.FirstOrDefaultAsync(lt => lt.AnswerId == AnswerId && lt.LanguageCode == model.LanguageCode);

            if (course == null)
            {
                var courseTrans = new Data.Entities.AnswerTranslation()
                {
                    Id = Guid.NewGuid(),
                    LanguageCode = model.LanguageCode,
                    AnswerId = AnswerId,
                    Content = model.Content
                };

                await DbSet.AddAsync(courseTrans);
            }
            else
            {
                course.Content = model.Content;
            }

            await SaveChangeAsync();
        }
    }
}
