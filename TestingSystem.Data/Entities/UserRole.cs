namespace TestingSystem.Data.Entities;
public class UserRole
{
    public Guid RoleId { get; set; }
    public string RoleName { get; set; }
    public ICollection<User> Users { get; set; }
}
