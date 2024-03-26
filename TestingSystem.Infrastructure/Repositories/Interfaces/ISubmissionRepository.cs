using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Submission;

namespace TestingSystem.Infrastructure.Repositories.Interfaces;
public interface ISubmissionRepository : IBaseRepository<Submission>
{
    Task<PaginatedResponseModel<Submission>> GetListSubmitOfUser(SearchingSubmitRequest userId);
    Task<Submission> GetSubmission(Guid id);
    Task<SubmissionDto> Submit(SubmissionDto request);
}
