using System.Reflection;
using TestingSystem.Data.Common;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.User;

namespace TestingSystem.Infrastructure.Repositories.Interfaces;
public interface IUserRepository : IBaseRepository<User>
{
    Task<PaginatedResponseModel<User>> GetListUser(SearchingUserRequest request);
    Task<User> GetUser(Guid userId);
    Task<bool> RegisterUser(CreateUserRequest request);
    Task<User> AddUser(CreateUserRequest request);
    Task<User> UpdateUserInfo(UpdateUserRequest request);
}
