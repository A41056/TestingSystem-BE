using TestingSystem.Data.Models.Question;

namespace TestingSystem.Infrastructure.Repositories.Interfaces
{
    public interface IQuestionTranslationRepository : IBaseRepository<Data.Entities.QuestionTranslation>
    {
        Task InsertTranslationAsync(Guid QuestionId, QuestionTranslationCreateOrUpdateDto model);

        Task DeleteTranslationsByQuestionIdAsync(Guid QuestionId);

        Task<IEnumerable<QuestionTranslationCreateOrUpdateDto>> GetQuestionTranslationsByQuestionIdAsync(Guid QuestionId);
        Task<IEnumerable<QuestionTranslationCreateOrUpdateDto>> GetListByLanguageCode(string languageCode);
        Task<IEnumerable<QuestionTranslationCreateOrUpdateDto>> GetListByQuestionId(Guid QuestionId, string languageCode);
    }
}
