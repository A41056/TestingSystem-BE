namespace TestingSystem.Data.Entities.Course
{
    public class CourseTeacher
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public int? SortOrder { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
        public virtual ICollection<CourseTeacherTranslation> CourseTeacherTranslations { get; set; } = new List<CourseTeacherTranslation>();

    }
}
