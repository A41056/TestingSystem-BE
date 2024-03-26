using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Submission;

namespace TestingSystem.Core.Services.Interfaces;
public interface ISubmissionService
{
    Task<PaginatedResponseModel<Submission>> GetListSubmitOfUser(SearchingSubmitRequest userId);
    Task<Submission> GetSubmission(Guid id);
    Task<SubmissionDto> Submit(SubmissionDto request);
}
