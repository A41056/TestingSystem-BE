namespace TestingSystem.Data.Models.Course
{
    public class CourseTeacherTranslationDto : BaseConcreteTranslation
    {
        public Guid CourseTeacherId { get; set; }

        public string Name { get; set; }

        public string University { get; set; }

        public string Description { get; set; }
    }
}
