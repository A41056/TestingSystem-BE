namespace TestingSystem.Data.Models.Course
{
    public class CourseTeacherSingleModel
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<CourseTeacherTranslationDto> Translation { get; set; }
    }
}
