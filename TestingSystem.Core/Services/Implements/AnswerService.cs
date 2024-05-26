using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Answer;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Core.Services.Implements;
public class AnswerService : IAnswerService
{
    private readonly IAnswerRepository _answerRepository;

    private readonly IAnswerTranslationRepository _answerTransRepository;

    public AnswerService(IAnswerRepository answerRepository, IAnswerTranslationRepository answerTransRepository)
    {
        _answerRepository = answerRepository;
        _answerTransRepository = answerTransRepository;
    }

    public async Task<Answer> AddAnswer(CreateOrUpdateAnswerRequest request)
    {
        return await _answerRepository.AddAnswer(request);
    }

    public async Task<bool> DeleteAnswer(Guid id)
    {
        return await _answerRepository.DeleteAnswer(id);
    }

    public async Task<Answer> GetById(Guid id)
    {
        return await _answerRepository.GetById(id);
    }

    public async Task<IEnumerable<AnswerTranslationCreateOrUpdateDto>> GetListByAnswerId(Guid answerId, string languageCode)
    {
        return await _answerTransRepository.GetListByAnswerId(answerId, languageCode);
    }

    public async Task<PaginatedResponseModel<Answer>> GetListByQuestionId(SearchingAnswerRequest request)
    {
        return await _answerRepository.GetListByQuestionId(request);
    }

    public async Task InsertTranslationAsync(Guid answerId, AnswerTranslationCreateOrUpdateDto model)
    {
        await _answerTransRepository.InsertTranslationAsync(answerId, model);
    }

    public async Task<Answer> UpdateAnswer(AnswerDto request)
    {
        return await _answerRepository.UpdateAnswer(request);
    }
}
