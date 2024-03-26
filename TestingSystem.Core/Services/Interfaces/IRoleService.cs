using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Data.Entities;

namespace TestingSystem.Core.Services.Interfaces;
public interface IRoleService
{
    Task<UserRole> GetUserRole(Guid id);

    Task<Guid?> GetByRoleName(string roleName);
}
