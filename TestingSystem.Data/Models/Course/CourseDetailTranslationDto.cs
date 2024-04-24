namespace TestingSystem.Data.Models.Course
{
    public class CourseDetailTranslationDto : BaseConcreteTranslation
    {
        public Guid CourseDetailId { get; set; }

        public string TabName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
