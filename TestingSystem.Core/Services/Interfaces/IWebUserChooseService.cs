using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.WebUserChoose;

namespace TestingSystem.Core.Services.Interfaces;
public interface IWebUserChooseService
{
    Task<WebUserChoose> SaveChoose(CreateOrUpdateWebUserChooseRequest request);
    Task<PaginatedResponseModel<WebUserChoose>> GetUserChoose(SearchingWebUserChooseRequest request);
    Task<List<WebUserChoose>> GetAllUserChooses(SearchingWebUserChoosesRequest request);
}
