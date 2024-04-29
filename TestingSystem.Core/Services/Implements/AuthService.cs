using Microsoft.Extensions.Logging;
using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Models;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Core.Services.Implements;
public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly ILogger<AuthService> _logger;
    public AuthService(ILogger<AuthService> logger, IAuthRepository authRepository)
    {
        _logger = logger;
        _authRepository = authRepository;
    }

    public async Task<string> Authenticate(LoginRequest request)
    {
        return await _authRepository.Authenticate(request);
    }

    public async Task ForgotPassword(ForgotPasswordRequest email)
    {
        await _authRepository.ForgotPassword(email);
    }

    public async Task ResetPassword(ResetPasswordRequest request)
    {
        await _authRepository.ResetPassword(request);
    }
}
