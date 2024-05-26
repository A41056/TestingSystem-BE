using Azure.Core;
using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Exam;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Core.Services.Implements;
public class ExamService : IExamService
{
    private readonly IExamRepository _examRepository;

    public ExamService(IExamRepository examRepository)
    {
        _examRepository = examRepository;
    }

    public async Task<Exam> CreateExam(CreateOrUpdateExamRequest request)
    {
        return await _examRepository.CreateExam(request);
    }

    public async Task<bool> DeleteAnswer(Guid id)
    {
        return await _examRepository.DeleteAnswer(id);
    }

    public async Task<Exam> GetById(Guid id)
    {
        return await _examRepository.GetById(id);
    }

    public async Task<PaginatedResponseModel<Exam>> GetList(SearchingExamRequest request)
    {
        return await _examRepository.GetList(request);
    }

    public async Task<ExamDto> GetDetail(Guid id)
    {
        return await _examRepository.GetDetail(id);
    }

    public async Task<ExamDto> UpdateExam(ExamDto request)
    {
        return await (_examRepository.UpdateExam(request));
    }

    public async Task<Exam> GetByLessonId(Guid lessonId)
    {
        return await _examRepository.GetByLessonId(lessonId);
    }
}
