using TestingSystem.Data.Entities;

namespace TestingSystem.Infrastructure.Repositories.Interfaces;
public interface IRoleRepository : IBaseRepository<UserRole>
{
    Task<UserRole> GetUserRole(Guid id);
    Task<Guid?> GetByRoleName(string roleName);
}
