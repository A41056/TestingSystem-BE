using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Db;


using TestingSystem.Data.Models.Question;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Infrastructure.Repositories.Implements
{
    public class QuestionTranslationRepository : BaseRepository<Data.Entities.QuestionTranslation>, IQuestionTranslationRepository
    {
        public QuestionTranslationRepository(TestingSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task DeleteTranslationsByQuestionIdAsync(Guid QuestionId)
        {
            var questionTrans = await DbSet.FirstOrDefaultAsync(c => c.QuestionId == QuestionId);

            if (questionTrans != null)
                await Delete(questionTrans);
        }

        public async Task<IEnumerable<QuestionTranslationCreateOrUpdateDto>> GetListByLanguageCode(string languageCode)
        {
            var result = new List<QuestionTranslationCreateOrUpdateDto>();
            var ctts = await DbSet.Where(ctt => ctt.LanguageCode == languageCode).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new QuestionTranslationCreateOrUpdateDto()
                {
                    QuestionId = item.QuestionId,
                    LanguageCode = item.LanguageCode,
                    Content = item.Content,
                });
            }

            return result;
        }

        public async Task<IEnumerable<QuestionTranslationCreateOrUpdateDto>> GetListByQuestionId(Guid QuestionId, string languageCode)
        {
            var result = new List<QuestionTranslationCreateOrUpdateDto>();
            var ctts = await DbSet.Where(ctt => ctt.QuestionId == QuestionId && ctt.LanguageCode == languageCode).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new QuestionTranslationCreateOrUpdateDto()
                {
                    QuestionId = item.QuestionId,
                    LanguageCode = item.LanguageCode,
                    Content = item.Content,
                });
            }

            return result;
        }

        public async Task<IEnumerable<QuestionTranslationCreateOrUpdateDto>> GetQuestionTranslationsByQuestionIdAsync(Guid QuestionId)
        {
            var result = new List<QuestionTranslationCreateOrUpdateDto>();
            var ctts = await DbSet.Where(ctt => ctt.QuestionId == QuestionId).ToListAsync();

            foreach (var item in ctts)
            {
                result.Add(new QuestionTranslationCreateOrUpdateDto()
                {
                    QuestionId = item.QuestionId,
                    LanguageCode = item.LanguageCode,
                    Content = item.Content,
                });
            }

            return result;
        }

        public async Task InsertTranslationAsync(Guid QuestionId, QuestionTranslationCreateOrUpdateDto model)
        {
            var course = await DbSet.FirstOrDefaultAsync(lt => lt.QuestionId == QuestionId && lt.LanguageCode == model.LanguageCode);

            if (course == null)
            {
                var courseTrans = new Data.Entities.QuestionTranslation()
                {
                    Id = Guid.NewGuid(),
                    LanguageCode = model.LanguageCode,
                    QuestionId = QuestionId,
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
