using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Question;

namespace TestingSystem.Core.Services.Interfaces;
public interface IQuestionService
{
    Task<PaginatedResponseModel<Question>> GetListByExamId(SearchingQuestionRequest request);
    Task<Question> GetById(Guid id);
    Task<Question> AddQuestion(CreateOrUpdateQuestionRequest request);
    Task<Question> UpdateQuestion(QuestionDto request);
    Task<bool> DeleteQuestion(Guid id);
    Task InsertTranslationAsync(Guid QuestionId, QuestionTranslationCreateOrUpdateDto model);
    Task<IEnumerable<QuestionTranslationCreateOrUpdateDto>> GetListByQuestionId(Guid QuestionId, string languageCode);
}
