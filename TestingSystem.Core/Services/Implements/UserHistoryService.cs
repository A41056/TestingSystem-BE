using Microsoft.Extensions.Logging;
using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Models;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Core.Services.Implements
{
    public class UserHistoryService : IUserHistoryService
    {
        private readonly IUserHistoryRepository _repository;
        private readonly ILogger<UserHistoryService> _logger;
        public UserHistoryService(IUserHistoryRepository repository, ILogger<UserHistoryService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ICollection<UserHistoryDto>> GetHistoryByUserId(Guid userId)
        {
            return await _repository.GetHistoryByUserId(userId);
        }

        public async Task InsertUserHistory(UserHistoryInsertDto request)
        {
            await _repository.InsertUserHistory(request);
        }
    }
}
