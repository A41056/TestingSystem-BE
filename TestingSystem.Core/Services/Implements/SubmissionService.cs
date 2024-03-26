using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.Submission;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Core.Services.Implements;
public class SubmissionService : ISubmissionService
{
    private readonly ISubmissionRepository _submissionRepository;
    public SubmissionService(ISubmissionRepository submissionRepository)
    {
        _submissionRepository = submissionRepository;
    }

    public async Task<PaginatedResponseModel<Submission>> GetListSubmitOfUser(SearchingSubmitRequest userId)
    {
        return await _submissionRepository.GetListSubmitOfUser(userId);
    }

    public async Task<Submission> GetSubmission(Guid id)
    {
        return await _submissionRepository.GetSubmission(id);
    }

    public async Task<SubmissionDto> Submit(SubmissionDto request)
    {
        return await _submissionRepository.Submit(request);
    }
}
