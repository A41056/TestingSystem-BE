using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces;

namespace TestingSystem.Admin.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class RoleController : BaseController
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<Guid?> GetByRoleName(string roleName)
    {
        return await _roleService.GetByRoleName(roleName);
    }
}
