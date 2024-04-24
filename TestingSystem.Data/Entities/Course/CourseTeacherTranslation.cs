namespace TestingSystem.Data.Entities.Course
{
    public class CourseTeacherTranslation
    {
        public string LanguageCode { get; set; }
        public Guid CourseTeacherId { get; set; }
        public string Name { get; set; }
        public string University { get; set; }
        public string Description { get; set; }
        public virtual CourseTeacher CourseTeacher { get; set; }
        public virtual LanguageTag Language { get; set; }
    }
}
