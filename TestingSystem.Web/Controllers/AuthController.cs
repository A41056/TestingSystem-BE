using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Models;
using TestingSystem.Web.Controllers;

namespace TestingSystem.Admin.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<string> Login(LoginRequest request)
    {
        return await _authService.Authenticate(request);
    }
}
