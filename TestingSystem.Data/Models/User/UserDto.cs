namespace TestingSystem.Data.Models.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool IsActive { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string? FullTextSearch { get; set; }
        public bool? Deleted { get; set; }
        public short AccessFailedCount { get; set; }
    }
}
