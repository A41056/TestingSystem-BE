using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Answer;

namespace TestingSystem.Core.Services.Interfaces;
public interface IAnswerService
{
    Task<PaginatedResponseModel<Answer>> GetListByQuestionId(SearchingAnswerRequest request);
    Task<Answer> GetById(Guid id);
    Task<Answer> AddAnswer(CreateOrUpdateAnswerRequest request);
    Task<Answer> UpdateAnswer(AnswerDto request);
    Task<bool> DeleteAnswer(Guid id);
}
