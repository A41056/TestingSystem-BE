namespace TestingSystem.Data.Models.Course
{
    public class CourseTeacherDto : BaseTranslation<CourseTeacherTranslationDto>
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public int SortOrder { get; set; }
        public string AvatarUrl { get; set; }
    }
}
