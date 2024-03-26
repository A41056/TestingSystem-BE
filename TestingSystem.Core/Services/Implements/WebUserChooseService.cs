using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Common;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.WebUserChoose;
using TestingSystem.Infrastructure.Repositories.Implements;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Core.Services.Implements;
public class WebUserChooseService : BaseRepository<WebUserChoose>, IWebUserChooseService
{
    private readonly IWebUserChooseRepository _webUserChooseRepository;
    public WebUserChooseService(TestingSystemDbContext dbContext, IWebUserChooseRepository webUserChooseRepository) : base(dbContext)
    {
        _webUserChooseRepository = webUserChooseRepository;
    }

    public async Task<List<WebUserChoose>> GetAllUserChooses(SearchingWebUserChoosesRequest request)
    {
        return await _webUserChooseRepository.GetAllUserChooses(request);
    }

    public async Task<PaginatedResponseModel<WebUserChoose>> GetUserChoose(SearchingWebUserChooseRequest request)
    {
        return await _webUserChooseRepository.GetUserChoose(request);
    }

    public async Task<WebUserChoose> SaveChoose(CreateOrUpdateWebUserChooseRequest request)
    {
        return await _webUserChooseRepository.SaveChoose(request);
    }
}
