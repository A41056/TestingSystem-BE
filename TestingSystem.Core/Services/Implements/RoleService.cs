using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Entities;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Core.Services.Implements;
public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Guid?> GetByRoleName(string roleName)
    {
        return await _roleRepository.GetByRoleName(roleName);
    }

    public async Task<UserRole> GetUserRole(Guid id)
    {
       return await _roleRepository.GetById(id);
    }
}
