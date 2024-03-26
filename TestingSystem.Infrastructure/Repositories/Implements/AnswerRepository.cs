using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Common;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Answer;
using TestingSystem.Infrastructure.Repositories.Interfaces;
using TestingSystem.Utilities.Exceptions;

namespace TestingSystem.Infrastructure.Repositories.Implements;
public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
{
    public AnswerRepository(TestingSystemDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Answer> AddAnswer(CreateOrUpdateAnswerRequest request)
    {
        var answer = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = request.QuestionId.GetValueOrDefault(),
            Name = request.Name,
            SortOrder = request.SortOrder,
            Correct = request.Correct,
            Created = DateTime.UtcNow,
            Modified = DateTime.UtcNow
        };

        DbSet.Add(answer);

        await SaveChangeAsync();

        return answer;
    }

    public async Task<bool> DeleteAnswer(Guid id)
    {
        var answer = await DbSet.FirstOrDefaultAsync(a => a.Id == id);

        if (answer == null)
            throw new ExamNotExistException();

        try
        {
           await Delete(answer);
            return true;
        }
        catch (Exception ex)
        {

        }

        return false;
    }

    public async Task<Answer> GetById(Guid id)
    {
        return await base.GetById(id);
    }

    public async Task<PaginatedResponseModel<Answer>> GetListByQuestionId(SearchingAnswerRequest request)
    {
        return await GetPaginatedDataByRequest(request,
                filter: f =>
                (request.QuestionId == null || f.QuestionId == request.QuestionId) &&
                (request.Id == null || f.Id == request.Id)
                );
    }

    public async Task<Answer> UpdateAnswer(AnswerDto request)
    {
        var answer = await DbSet.FirstOrDefaultAsync(e => e.Id == request.Id);

        if (answer == null)
            throw new ExamNotExistException();

        answer.Name = request.Name;
        answer.SortOrder = request.SortOrder;
        answer.Correct = request.Correct;
        answer.Modified = DateTime.UtcNow;

        await SaveChangeAsync();

        return answer;
    }
}
