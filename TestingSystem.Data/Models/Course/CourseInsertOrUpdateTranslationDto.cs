namespace TestingSystem.Data.Models.Course
{
    public class CourseInsertOrUpdateTranslationDto : BaseConcreteTranslation
    {
        public Guid CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string NumberOfAssignment { get; set; }

        public string NumberOfStudent { get; set; }

        public string NumberOfVideo { get; set; }
    }
}
