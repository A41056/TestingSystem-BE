using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestingSystem.Data.Common;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Answer;
using TestingSystem.Data.Models.Exam;
using TestingSystem.Data.Models.Question;
using TestingSystem.Infrastructure.Repositories.Interfaces;
using TestingSystem.Utilities.Exceptions;

namespace TestingSystem.Infrastructure.Repositories.Implements;
public class ExamRepository : BaseRepository<Exam>, IExamRepository
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IAnswerRepository _answerRepository;


    public ExamRepository(TestingSystemDbContext dbContext, IQuestionRepository questionRepository, IAnswerRepository answerRepository) : base(dbContext)
    {
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
    }

    public async Task<Exam> CreateExam(CreateOrUpdateExamRequest request)
    {
        var exam = new Exam
        {
            ExamId = Guid.NewGuid(),
            LessonId = request.LessonId,
            Title = request.Title,
            Status = Utilities.Enum.ExamStatus.Pulished,
            IsAutoGrade = true,
            CreatedByUserId = request.CreatedByUserId,
            ModifiedByUserId = request.CreatedByUserId,
            Created = DateTime.UtcNow,
            Modified = DateTime.UtcNow,
            Questions = new List<Question>()
        };

        DbSet.Add(exam);

        await SaveChangeAsync();

        foreach (var questionRequest in request.Questions)
        {
            questionRequest.ExamId = exam.ExamId;
            var question = await _questionRepository.AddQuestion(questionRequest);

            exam.Questions.Add(question);
        }

        return exam;
    }

    public Task<bool> DeleteAnswer(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ExamDto> GetDetail(Guid id)
    {
        var examDetail = await GetById(id);
        
        // Fetch questions and include their answers
        var questions = await _questionRepository.GetListByFilter(
            filter: q => q.ExamId == id,
            "SortOrder",
            includes: new Expression<Func<Question, object>>[]
                {
                    i => i.Answers
                });

        examDetail.Questions = questions;

        return MapToExamDetailDTO(examDetail);
    }

    public async Task<Exam> GetById(Guid id)
    {
        return await base.GetById(id);
    }

    public async Task<PaginatedResponseModel<Exam>> GetList(SearchingExamRequest request)
    {
        return await GetPaginatedDataByRequest(request,
                filter: f =>
                (request.ExamId == null || f.ExamId == request.ExamId) &&
                (request.Title == null || f.Title == request.Title) &&
                (request.Status == null || f.Status == request.Status) &&
                (request.CreatedByUserId == null || f.CreatedByUserId == request.CreatedByUserId) &&
                (request.ModifiedByUserId == null || f.ModifiedByUserId == request.ModifiedByUserId) &&
                (f.LessonId == null)
                );
    }

    public async Task<ExamDto> UpdateExam(ExamDto request)
    {
        var exam = await DbSet.FirstOrDefaultAsync(e => e.ExamId == request.ExamId);

        if (exam == null)
            throw new ExamNotExistException();

        exam.LessonId = request.LessonId;
        exam.Title = request.Title;
        exam.Status = Utilities.Enum.ExamStatus.Pulished;
        exam.ModifiedByUserId = request.ModifiedByUserId.GetValueOrDefault();
        exam.Modified = DateTime.UtcNow;

        foreach (var questionRequest in request.Questions)
        {
            await _questionRepository.UpdateQuestion(questionRequest);
        }

        await SaveChangeAsync();


        return MapToExamDetailDTO(exam);
    }

    private ExamDto MapToExamDetailDTO(Exam exam)
    {
        var examDetailDTO = new ExamDto
        {
            ExamId = exam.ExamId,
            Title = exam.Title,
            IsAutoGrade = exam.IsAutoGrade,
            Questions = exam.Questions.Select(q => new QuestionDto
            {
                Id = q.Id,
                SortOrder = q.SortOrder,
                Explanation = q.Explanation,
                Note = q.Note,
                IsSingleChoice = q.IsSingleChoice,
                Created = q.Created,
                Modified = q.Modified,
                Answers = q.Answers.OrderBy(a => a.SortOrder).Select(a => new AnswerDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Correct = a.Correct,
                    SortOrder = a.SortOrder
                }).ToList()
            }).ToList()
        };

        return examDetailDTO;
    }

    public async Task<Exam> GetByLessonId(Guid lessonId)
    {
        return await DbSet.FirstOrDefaultAsync(e => e.LessonId == lessonId);
    }
}
