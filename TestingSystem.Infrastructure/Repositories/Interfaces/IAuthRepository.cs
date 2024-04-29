using TestingSystem.Data.Entities;
using TestingSystem.Data.Models;

namespace TestingSystem.Infrastructure.Repositories.Interfaces;
public interface IAuthRepository : IBaseRepository<User>
{
    Task<string> Authenticate(LoginRequest request);
    Task ForgotPassword(ForgotPasswordRequest email);
    Task ResetPassword(ResetPasswordRequest request);
}
