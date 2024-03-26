using Microsoft.EntityFrameworkCore;
using TestingSystem.Data.Common;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models.User;
using TestingSystem.Infrastructure.Repositories.Interfaces;
using TestingSystem.Utilities.Exceptions;

namespace TestingSystem.Infrastructure.Repositories.Implements
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IRoleRepository _roleRepository;

        public UserRepository(TestingSystemDbContext dbContext, IRoleRepository roleRepository) : base(dbContext)
        {
            _roleRepository = roleRepository;
        }

        public async Task<bool> RegisterUser(CreateUserRequest request)
        {
            try
            {
                request.RoleName = "User";
                await CreateUser(request);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> AddUser(CreateUserRequest request)
        {
            return await CreateUser(request);
        }

        private async Task<User> CreateUser(CreateUserRequest request)
        {
            var userCheck = await DbSet.FirstOrDefaultAsync(u => u.UserName == request.UserName);

            if (userCheck != null)
                throw new UsernameExistedException();

            var roleId = await _roleRepository.GetByRoleName(request.RoleName);

            string password = request.Password;
            byte[] passwordSalt;
            byte[] passwordHash;

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                RoleId = roleId.GetValueOrDefault(),
                UserName = request.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = request.FirstName,
                LastName = request.LastName,
                FullName = request.FirstName + " " + request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                BirthDay = request.BirthDay,
                Gender = request.Gender,
                FullTextSearch = request.UserName + " " + request.FullName + " " + request.Email + " " + request.PhoneNumber,
                Deleted = false,
                AccessFailedCount = 0,
                IsActive = true,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow
            };

            DbSet.Add(user);

            await SaveChangeAsync();

            return user;
        }

        public async Task<User> UpdateUserInfo(UpdateUserRequest request)
        {
            var user = await GetById(request.Id) ?? throw new UserNotFoundException();

            if (user == null)
                throw new UserNotFoundException();

            if (request.FirstName != null)
                user.FirstName = request.FirstName;

            if (request.LastName != null)
                user.LastName = request.LastName;

            if (request.BirthDay != null)
                user.BirthDay = request.BirthDay.Value;

            if (request.PhoneNumber != null)
                user.PhoneNumber = request.PhoneNumber;

            if (request.Gender != null)
                user.Gender = request.Gender;

            if (request.RoleName != null)
            {
                Guid? roleId = await _roleRepository.GetByRoleName(request.RoleName);

                if (roleId.HasValue)
                {
                    user.RoleId = roleId.Value; // Assign the non-nullable Guid value
                }
                else
                {
                    // Handle the case where the role does not exist
                    // You might throw an exception, log a warning, or take other appropriate action
                }
            }

            if (request.NewPassword != null)
            {
                byte[] passwordSalt;
                byte[] passwordHash;

                using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.NewPassword));
                }

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            user.FullName = user.FirstName + " " + user.LastName;
            user.FullTextSearch = user.UserName + " " + user.FullName + " " + user.Email + " " + user.PhoneNumber;
            user.Modified = DateTime.UtcNow;

            await SaveChangeAsync();

            return user;
        }

        public async Task<PaginatedResponseModel<User>> GetListUser(SearchingUserRequest request)
        {
            return await GetPaginatedDataByRequest(request,
                filter: f =>
                (request.UserName == null || f.UserName.Contains(request.UserName)) &&
                (request.FirstName == null || f.FirstName.Contains(request.FirstName)) &&
                (request.LastName == null || f.LastName.Contains(request.LastName)) &&
                (request.FullName == null || f.FullName.Contains(request.FullName)) &&
                (request.Email == null || f.Email.Contains(request.Email)) &&
                (request.PhoneNumber == null || f.PhoneNumber.Contains(request.PhoneNumber)) &&
                (request.BirthDay == null || f.BirthDay == request.BirthDay) &&
                (request.Gender == null || f.Gender == request.Gender)
                );
        }

        public async Task<User> GetUser(Guid userId)
        {
            return await base.GetById(userId) ?? throw new UserNotFoundException();
        }
    }
}
