using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestingSystem.Data.Entities;
using TestingSystem.Data.Entities.Category;
using TestingSystem.Data.Entities.Course;

namespace TestingSystem.Data.Db;
public class TestingSystemDbContext : DbContext
{
    public TestingSystemDbContext(DbContextOptions<TestingSystemDbContext> options) : base(options)
    {
    }

    public virtual DbSet<UserRole> UserRoles { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Question> Questions { get; set; }
    public virtual DbSet<Exam> Exams { get; set; }
    public virtual DbSet<Answer> Answers { get; set; }
    public virtual DbSet<Submission> Submissions { get; set; }
    public virtual DbSet<WebUserChoose> WebUserChooses { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<CategoryTranslation> CategoryTranslations { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<CourseTranslation> CourseTranslations { get; set; }
    public virtual DbSet<CourseDetail> CourseDetails { get; set; }
    public virtual DbSet<CourseDetailTranslation> CourseDetailTranslations { get; set; }
    public virtual DbSet<CourseTeacher> CourseTeachers { get; set; }
    public virtual DbSet<CourseTeacherTranslation> CourseTeacherTranslations { get; set; }
    public virtual DbSet<LanguageTag> LanguageTags { get; set; }
    public virtual DbSet<Lession> Lessions { get; set; }
    public virtual DbSet<LessionTranslation> LessionTranslations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        SeedData(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        var adminRoleId = Guid.NewGuid();
        var teacherRoleId = Guid.NewGuid();
        var userRoleId = Guid.NewGuid();

        // Create roles
        modelBuilder.Entity<UserRole>().HasData(
            new UserRole { RoleId = adminRoleId, RoleName = "Admin" },
            new UserRole { RoleId = teacherRoleId, RoleName = "Teacher" },
            new UserRole { RoleId = userRoleId, RoleName = "User" }
        );

        // Create users
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.NewGuid(),
                RoleId = adminRoleId,
                UserName = "admin",
                PasswordHash = GetPasswordHash("admin", out byte[] salt),
                PasswordSalt = salt,
                FirstName = "AdminFirstName",
                LastName = "AdminLastName",
                FullName = "AdminFirstName AdminLastName",
                Email = "admin@example.com",
                PhoneNumber = "1234567890",
                Gender = "Male",
                BirthDay = new DateTime(1990, 1, 1),
                IsActive = true,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                FullTextSearch = "admin AdminFirstName AdminLastName admin@example.com 1234567890 Male",
                Deleted = false,
                AccessFailedCount = 0
            },
            new User
            {
                Id = Guid.NewGuid(),
                RoleId = teacherRoleId,
                UserName = "teacher",
                PasswordHash = GetPasswordHash("teacher", out byte[] salt2),
                PasswordSalt = salt2,
                FirstName = "TeacherFirstName",
                LastName = "TeacherLastName",
                FullName = "TeacherFirstName TeacherLastName",
                Email = "teacher@example.com",
                PhoneNumber = "9876543210",
                Gender = "Female",
                BirthDay = new DateTime(1985, 5, 10),
                IsActive = true,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                FullTextSearch = "teacher TeacherFirstName TeacherLastName teacher@example.com 9876543210 Female",
                Deleted = false,
                AccessFailedCount = 0
            },
            new User
            {
                Id = Guid.NewGuid(),
                RoleId = userRoleId,
                UserName = "user",
                PasswordHash = GetPasswordHash("user", out byte[] salt3),
                PasswordSalt = salt3,
                FirstName = "Cristiano",
                LastName = "Ronaldo",
                FullName = "Cristiano Ronaldo",
                Email = "ronaldo@example.com",
                PhoneNumber = "5555555555",
                Gender = "Male",
                BirthDay = new DateTime(2000, 10, 15),
                IsActive = true,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                FullTextSearch = "user Cristiano Ronaldo ronaldo@example.com 5555555555 Male",
                Deleted = false,
                AccessFailedCount = 0
            }
        );

        modelBuilder.Entity<LanguageTag>().HasData(
            new LanguageTag { Code = "vi-VN", Name = "VietNam", IsActive = true, IsDefault = true, SortOrder = 0, Created = DateTime.UtcNow },
            new LanguageTag { Code = "en-EN", Name = "English", IsActive = true, IsDefault = false, SortOrder = 1, Created = DateTime.UtcNow },
            new LanguageTag {Code = "ru-RU", Name = "Russia", IsActive = true, IsDefault = false, SortOrder = 2, Created = DateTime.UtcNow }
        );
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
