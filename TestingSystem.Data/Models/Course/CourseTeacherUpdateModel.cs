namespace TestingSystem.Data.Models.Course
{
    public class CourseTeacherUpdateModel : BaseTranslation<CourseTeacherTranslationDto>
    {
        public Guid CourseId { get; set; }
        public string AvatarUrl { get; set; }
    }
}
