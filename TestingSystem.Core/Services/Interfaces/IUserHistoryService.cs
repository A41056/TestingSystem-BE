using TestingSystem.Data.Models;

namespace TestingSystem.Core.Services.Interfaces
{
    public interface IUserHistoryService
    {
        Task InsertUserHistory(UserHistoryInsertDto request);
        Task<ICollection<UserHistoryDto>> GetHistoryByUserId(Guid userId);
    }
}
