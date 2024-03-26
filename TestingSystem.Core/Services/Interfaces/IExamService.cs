using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Exam;

namespace TestingSystem.Core.Services.Interfaces;
public interface IExamService
{
    Task<PaginatedResponseModel<Exam>> GetList(SearchingExamRequest request);
    Task<ExamDto> GetDetail(Guid id);
    Task<Exam> GetById(Guid id);
    Task<Exam> CreateExam(CreateOrUpdateExamRequest request);
    Task<ExamDto> UpdateExam(ExamDto request);
    Task<bool> DeleteAnswer(Guid id);
}
