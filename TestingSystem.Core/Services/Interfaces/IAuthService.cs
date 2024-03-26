using TestingSystem.Data.Models;

namespace TestingSystem.Core.Services.Interfaces;
public interface IAuthService
{
    Task<string> Authenticate(LoginRequest request);
}
