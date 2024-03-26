using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Models;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Core.Services.Implements;
public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<string> Authenticate(LoginRequest request)
    {
        return await _authRepository.Authenticate(request);
    }
}
