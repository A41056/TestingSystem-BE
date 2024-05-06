using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Infrastructure.Repositories.Implements
{
    public class UserHistoryRepository : BaseRepository<UserHistory>, IUserHistoryRepository
    {
        public UserHistoryRepository(TestingSystemDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<UserHistoryDto>> GetHistoryByUserId(Guid userId)
        {
            var userHistories = await DbSet.Where(uh => uh.UserId == userId).ToListAsync();

            var result = new List<UserHistoryDto>();

            foreach (var item in userHistories)
            {
                result.Add(new UserHistoryDto()
                {
                    UserId = item.UserId,
                    CourseId = item.CourseId
                });
            }

            return result;

        }

        public async Task InsertUserHistory(UserHistoryInsertDto request)
        {
            var userHistory = await DbSet.FirstOrDefaultAsync(uh => uh.UserId == request.UserId && uh.CourseId == request.CourseId);

            if (userHistory == null)
            {
                var userH = new UserHistory()
                {
                    UserId = request.UserId,
                    CourseId = request.CourseId,
                    Created = DateTime.UtcNow
                };

                await DbSet.AddAsync(userH);

                await SaveChangeAsync();
            }
        }
    }
}
