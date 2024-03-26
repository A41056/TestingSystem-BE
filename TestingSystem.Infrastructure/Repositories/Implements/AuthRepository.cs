using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Infrastructure.Repositories.Implements;
public class AuthRepository : BaseRepository<User>, IAuthRepository
{
    private readonly IConfiguration _configuration;
    private readonly IRoleRepository _roleRepository;

    public AuthRepository(TestingSystemDbContext dbContext, IConfiguration configuration, IRoleRepository roleRepository) : base(dbContext)
    {
        _configuration = configuration;
        _roleRepository = roleRepository;
    }

    public async Task<string> Authenticate(LoginRequest request)
    {
        var user = await DbSet
            .SingleOrDefaultAsync(u => u.UserName == request.UserName);

        if (user == null || !VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
        {
            return null; // Authentication failed
        }

        var token = await GenerateJwtToken(user);
        return token;
    }

    private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != storedHash[i]) return false;
            }
        }
        return true;
    }

    private async Task<string> GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

        var role = await _roleRepository.GetById(user.RoleId);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role.RoleName),

            }),
            Expires = DateTime.UtcNow.AddDays(7), // Token validity period
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
