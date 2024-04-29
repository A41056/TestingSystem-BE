using TestingSystem.Core.Services.Interfaces;
using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.User;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Core.Services.Implements;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> AddUser(CreateUserRequest request)
    {
        return await _userRepository.AddUser(request);
    }

    public async Task<PaginatedResponseModel<User>> GetListUser(SearchingUserRequest request)
    {
        return await _userRepository.GetListUser(request);
    }

    public async Task<UserDto> GetUser(Guid userId)
    {
        return await _userRepository.GetUser(userId);
    }

    public async Task<bool> RegisterUser(CreateUserRequest request)
    {
        return await _userRepository.RegisterUser(request);
    }

    public async Task<User> UpdateUserInfo(UpdateUserRequest request)
    {
        return await _userRepository.UpdateUserInfo(request);
    }
}
