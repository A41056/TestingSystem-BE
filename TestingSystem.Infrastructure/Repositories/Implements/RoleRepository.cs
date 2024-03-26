using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Infrastructure.Repositories.Implements;
public class RoleRepository : BaseRepository<UserRole>, IRoleRepository
{
    public RoleRepository(TestingSystemDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Guid?> GetByRoleName(string roleName)
    {
        var role = await DbSet.FirstOrDefaultAsync(r => r.RoleName == roleName);
        return role?.RoleId;
    }

    public async Task<UserRole> GetUserRole(Guid id)
    {
        return await base.GetById(id);
    }
}
