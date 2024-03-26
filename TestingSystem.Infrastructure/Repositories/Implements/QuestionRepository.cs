using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Common;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Question;
using TestingSystem.Infrastructure.Repositories.Interfaces;
using TestingSystem.Utilities.Exceptions;

namespace TestingSystem.Infrastructure.Repositories.Implements;
public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
{
    private readonly IAnswerRepository _answerRepository;

    public QuestionRepository(TestingSystemDbContext dbContext, IAnswerRepository answerRepository) : base(dbContext)
    {
        _answerRepository = answerRepository;
    }

    public async Task<Question> AddQuestion(CreateOrUpdateQuestionRequest request)
    {
        var question = new Question
        {
            Id = Guid.NewGuid(),
            ExamId = request.ExamId.GetValueOrDefault(),
            SortOrder = request.SortOrder,
            Explanation = request.Explanation,
            Note = request.Note,
            IsSingleChoice = request.IsSingleChoice,
            Created = DateTime.UtcNow,
            Modified = DateTime.UtcNow,
            Answers = new List<Answer>()
        };

        DbSet.Add(question);

        await SaveChangeAsync();

        foreach (var answerRequest in request.Answers)
        {
            answerRequest.QuestionId = question.Id;
            var answer = await _answerRepository.AddAnswer(answerRequest);

            question.Answers.Add(answer);
        }

        return question;
    }

    public async Task<bool> DeleteQuestion(Guid id)
    {
        var questionToDelete = await DbSet.Include(q => q.Answers)
                                          .FirstOrDefaultAsync(q => q.Id == id);

        if (questionToDelete == null)
            return false;

        DbSet.Remove(questionToDelete);

        await SaveChangeAsync();

        return true;
    }

    public async Task<List<Answer>> GetAllAnswers(Guid id)
    {
        return await _answerRepository.GetListByFilter(filter: f => (f.QuestionId == id));
    }

    public async Task<Question> GetById(Guid id)
    {
        return await base.GetById(id);
    }

    public async Task<PaginatedResponseModel<Question>> GetListByExamId(SearchingQuestionRequest request)
    {
        return await GetPaginatedDataByRequest(request,
                filter: f =>
                (request.ExamId == null || f.ExamId == request.ExamId) &&
                (request.Explannation == null || f.Explanation == request.Explannation)
                );
    }

    public async Task<Question> UpdateQuestion(QuestionDto request)
    {
        var question = await DbSet.FirstOrDefaultAsync(e => e.Id == request.Id);

        if (question == null)
            throw new ExamNotExistException();

        question.SortOrder = request.SortOrder;
        question.Explanation = request.Explanation;
        question.Note = request.Note;
        question.IsSingleChoice = request.IsSingleChoice;
        question.Modified = DateTime.UtcNow;

        foreach (var answerRequest in request.Answers)
        {
            await _answerRepository.UpdateAnswer(answerRequest);
        }

        await SaveChangeAsync();

        return question;
    }
}
