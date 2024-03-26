using System.Linq.Expressions;
using TestingSystem.Data.Common;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Submission;
using TestingSystem.Infrastructure.Repositories.Interfaces;
using TestingSystem.Utilities.Exceptions;

namespace TestingSystem.Infrastructure.Repositories.Implements;
public class SubmissionRepository : BaseRepository<Submission>, ISubmissionRepository
{
    private readonly IExamRepository _examRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IAnswerRepository _answerRepository;
    private readonly IWebUserChooseRepository _userChooseRepository;

    public SubmissionRepository(TestingSystemDbContext dbContext, IExamRepository examRepository, IQuestionRepository questionRepository, IAnswerRepository answerRepository, IWebUserChooseRepository userChooseRepository) : base(dbContext)
    {
        _examRepository = examRepository;
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
        _userChooseRepository = userChooseRepository;
    }

    public async Task<PaginatedResponseModel<Submission>> GetListSubmitOfUser(SearchingSubmitRequest request)
    {
        return await GetPaginatedDataByRequest(request,
                    filter: f =>
                    (request.Id == null || f.Id == request.Id) &&
                    (request.UserId == null || f.StudentId == request.UserId) &&
                    (request.ExamId == null || f.ExamId == request.ExamId)
                    );
    }

    public async Task<Submission> GetSubmission(Guid id)
    {
        return await base.GetById(id);
    }

    public async Task<SubmissionDto> Submit(SubmissionDto request)
    {
        var exam = await _examRepository.GetById(request.ExamId);

        if (exam == null)
            throw new ExamNotExistException();

        double score = -1;

        if (exam.IsAutoGrade)
            score = await AutoGrade(exam.ExamId, request.StudentId.GetValueOrDefault());

        var submission = new Submission()
        {
            Id = Guid.NewGuid(),
            ExamId = request.ExamId.GetValueOrDefault(),
            StudentId = request.StudentId.GetValueOrDefault(),
            SubmittedAt = DateTime.UtcNow,
            Score = score
        };

        DbSet.Add(submission);

        await SaveChangeAsync();

        return MapToDto(submission);
    }

    private SubmissionDto MapToDto(Submission submission)
    {
        return new SubmissionDto
        {
            Id = submission.Id,
            StudentId = submission.StudentId,
            ExamId = submission.ExamId,
            SubmittedAt = submission.SubmittedAt,
            Score = submission.Score
        };
    }

    private async Task<double> AutoGrade(Guid examId, Guid userId)
    {
        var questions = await _questionRepository.GetListByFilter(filter: q => (q.ExamId == examId), includes: new Expression<Func<Question, object>>[]
                {
                    i => i.Answers
                });

        double totalScore = 0;

        foreach (var question in questions)
        {
            var answers = question.Answers;

            var correctAnswers = answers.Where(a => a.Correct == true).ToList();

            var userChoices = await _userChooseRepository.GetAllUserChooses(new Data.Models.WebUserChoose.SearchingWebUserChoosesRequest()
            {
                QuestionId = question.Id,
                WebUserId = userId
            });

            double questionScore = CalculateQuestionScore(correctAnswers.Count, userChoices);

            totalScore += questionScore;
        }

        return totalScore;
    }

    private double CalculateQuestionScore(int correctAnswerCount, List<WebUserChoose> userChoices)
    {
        if (correctAnswerCount == 0)
            return 0;

        int correctChoicesCount = userChoices.Count(uc => uc.Answer.Correct == true);

        double questionScore = (double)correctChoicesCount / correctAnswerCount;

        return questionScore;
    }
}
