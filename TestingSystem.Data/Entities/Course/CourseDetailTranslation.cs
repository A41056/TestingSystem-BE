namespace TestingSystem.Data.Entities.Course
{
    public class CourseDetailTranslation
    {
        public string LanguageCode { get; set; }
        public Guid CourseDetailId { get; set; }
        public string TabName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual CourseDetail CourseDetail { get; set; }
        public virtual LanguageTag Language { get; set; }
    }
}
