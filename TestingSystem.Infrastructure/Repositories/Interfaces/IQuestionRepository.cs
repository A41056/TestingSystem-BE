using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Question;

namespace TestingSystem.Infrastructure.Repositories.Interfaces;
public interface IQuestionRepository : IBaseRepository<Question>
{
    Task<PaginatedResponseModel<Question>> GetListByExamId(SearchingQuestionRequest request);
    Task<List<Answer>> GetAllAnswers(Guid id);
    Task<Question> GetById(Guid id);
    Task<Question> AddQuestion(CreateOrUpdateQuestionRequest request);
    Task<Question> UpdateQuestion(QuestionDto request);
    Task<bool> DeleteQuestion(Guid id);
}
