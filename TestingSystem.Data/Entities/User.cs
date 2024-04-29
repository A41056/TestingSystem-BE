namespace TestingSystem.Data.Entities;
public class User
{
    public Guid Id { get; set; }
    public Guid RoleId { get; set; }
    public string UserName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
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

    public UserRole UserRole { get; set; }
    public ICollection<Exam> Exams { get; set; }
    public ICollection<Submission> Submissions { get; set; }
    public ICollection<Course.Course> Courses { get; set; }
    public ICollection<Course.CourseTeacher> CourseTeachers { get; set; }


}
