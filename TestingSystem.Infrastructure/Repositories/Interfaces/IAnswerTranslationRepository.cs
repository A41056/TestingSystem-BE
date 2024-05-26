using TestingSystem.Data.Models.Answer;

namespace TestingSystem.Infrastructure.Repositories.Interfaces
{
    public interface IAnswerTranslationRepository : IBaseRepository<Data.Entities.AnswerTranslation>
    {
        Task InsertTranslationAsync(Guid AnswerId, AnswerTranslationCreateOrUpdateDto model);

        Task DeleteTranslationsByAnswerIdAsync(Guid AnswerId);

        Task<IEnumerable<AnswerTranslationCreateOrUpdateDto>> GetAnswerTranslationsByAnswerIdAsync(Guid AnswerId);
        Task<IEnumerable<AnswerTranslationCreateOrUpdateDto>> GetListByLanguageCode(string languageCode);
        Task<IEnumerable<AnswerTranslationCreateOrUpdateDto>> GetListByAnswerId(Guid AnswerId, string languageCode);
    }
}
