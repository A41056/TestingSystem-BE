using TestingSystem.Data.Entities;
using TestingSystem.Data.Models;

namespace TestingSystem.Infrastructure.Repositories.Interfaces
{
    public interface IUserHistoryRepository : IBaseRepository<UserHistory>
    {
        Task InsertUserHistory(UserHistoryInsertDto request);
        Task<ICollection<UserHistoryDto>> GetHistoryByUserId(Guid userId);
    }
}
