using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using TestingSystem.Data.Db;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Models;
using TestingSystem.Infrastructure.Repositories.Interfaces;
using System.Diagnostics;

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

    public async Task ForgotPassword(ForgotPasswordRequest request)
    {
        // Generate a new password
        string newPassword = GenerateRandomPassword();

        var user = await DbSet.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        // Update user's password
        byte[] salt;
        user.PasswordHash = GetPasswordHash(newPassword, out salt);
        user.PasswordSalt = salt;

        // Save changes to the database
        await SaveChangeAsync();

        // Send email with new password
        await SendForgotPasswordEmail(request.Email, newPassword);
    }

    private async Task SendForgotPasswordEmail(string email, string newPassword)
    {
        var mailSettings = _configuration.GetSection("MailSettings");

        var Email = new MailMessage();

        Email.From = new MailAddress(email);
        Email.Subject = "Reset Password";
        Email.To.Add(new MailAddress(email));
        Email.Body = $"<html><body>Your new password: {newPassword}</body></html>";
        Email.IsBodyHtml = true;

        var smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("giappq1@vmogroup.com", "yeux vcbm dleu lbpg"),
            EnableSsl = true
        };

        try
        {

            smtp.Send(Email);
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex.Message);
        }
    }

    public async Task ResetPassword(ResetPasswordRequest request)
    {
        var user = await DbSet.FirstOrDefaultAsync(u => u.UserName == request.Username);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        // Validate old password (if necessary)
        if (!VerifyPasswordHash(request.OldPassword, user.PasswordHash, user.PasswordSalt))
        {
            throw new Exception("Invalid old password");
        }

        // Generate new password hash
        byte[] salt;
        user.PasswordHash = GetPasswordHash(request.NewPassword, out salt);
        user.PasswordSalt = salt;

        // Save changes to the database
        await SaveChangeAsync();
    }

    private string GenerateRandomPassword()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
    }

    private byte[] GetPasswordHash(string password, out byte[] salt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            salt = hmac.Key;
            return hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
