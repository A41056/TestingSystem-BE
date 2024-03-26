using TestingSystem.Data.Common;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.WebUserChoose;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Infrastructure.Repositories.Implements;
public class WebUserChooseRepository : BaseRepository<WebUserChoose>, IWebUserChooseRepository
{
    public WebUserChooseRepository(TestingSystemDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<WebUserChoose>> GetAllUserChooses(SearchingWebUserChoosesRequest request)
    {
        return await GetListByFilter(filter: f => 
                                    (f.QuestionId == request.QuestionId) &&
                                    (f.WebUserId == request.WebUserId)
                                    );
    }

    public async Task<PaginatedResponseModel<WebUserChoose>> GetUserChoose(SearchingWebUserChooseRequest request)
    {
        return await GetPaginatedDataByRequest(request,
                filter: f =>
                (request.Id == null || f.Id == request.Id) &&
                (request.QuestionId == null || f.QuestionId == request.QuestionId) &&
                (request.WebUserId == null || f.WebUserId == request.WebUserId) &&
                (request.AnswerId == null || f.AnswerId == request.AnswerId)
                );
    }

    public async Task<WebUserChoose> SaveChoose(CreateOrUpdateWebUserChooseRequest request)
    {
        var choose = await GetById(request.Id);

        if (choose != null)
        {
            choose.AnswerId = request.AnswerId.GetValueOrDefault();
            choose.Modified = DateTime.UtcNow;
        }   
        else
        {
            choose = new WebUserChoose()
            {
                Id = Guid.NewGuid(),
                WebUserId = request.WebUserId.GetValueOrDefault(),
                QuestionId = request.QuestionId.GetValueOrDefault(),
                AnswerId = request.AnswerId.GetValueOrDefault(),
                AnswerText = request.AnswerText,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow
            };

            DbSet.Add(choose);
        }

        await SaveChangeAsync();

        return choose;
    }
}
