using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Data.Models.User;
public class UpdateUserRequest
{
    public Guid Id { get; set; }
    public string? RoleName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime? BirthDay { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Gender { get; set; }
    public string? NewPassword { get; set; }
}
