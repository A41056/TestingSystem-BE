using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Question;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Core.Services.Implements;
public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuestionTranslationRepository _questionTransRepository;


    public QuestionService(IQuestionRepository questionRepository, IQuestionTranslationRepository questionTranslationRepository)
    {
        _questionRepository = questionRepository;
        _questionTransRepository = questionTranslationRepository;
    }

    public async Task<Question> AddQuestion(CreateOrUpdateQuestionRequest request)
    {
        return await _questionRepository.AddQuestion(request);
    }

    public async Task<bool> DeleteQuestion(Guid id)
    {
        return await (_questionRepository.DeleteQuestion(id));
    }

    public async Task<Question> GetById(Guid id)
    {
        return await _questionRepository.GetById(id);
    }

    public async Task<PaginatedResponseModel<Question>> GetListByExamId(SearchingQuestionRequest request)
    {
        return await _questionRepository.GetListByExamId(request);
    }

    public async Task<IEnumerable<QuestionTranslationCreateOrUpdateDto>> GetListByQuestionId(Guid QuestionId, string languageCode)
    {
        return await _questionTransRepository.GetListByQuestionId(QuestionId, languageCode);
    }

    public async Task InsertTranslationAsync(Guid QuestionId, QuestionTranslationCreateOrUpdateDto model)
    {
        await _questionTransRepository.InsertTranslationAsync(QuestionId, model);
    }

    public async Task<Question> UpdateQuestion(QuestionDto request)
    {
        return await _questionRepository.UpdateQuestion(request);
    }
}
