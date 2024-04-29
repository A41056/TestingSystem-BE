namespace TestingSystem.Data.Models.User;
public class CreateUserRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string? RoleName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Gender { get; set; }
    public DateTime? BirthDay { get; set; }
    public string? AvatarUrl { get; set; }

}
