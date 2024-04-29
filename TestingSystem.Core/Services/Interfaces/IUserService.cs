using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.User;

namespace TestingSystem.Core.Services.Interfaces;
public interface IUserService 
{
    Task<PaginatedResponseModel<User>> GetListUser(SearchingUserRequest request);
    Task<UserDto> GetUser(Guid userId);
    Task<bool> RegisterUser(CreateUserRequest request);
    Task<User> AddUser(CreateUserRequest request);
    Task<User> UpdateUserInfo(UpdateUserRequest request);
}
