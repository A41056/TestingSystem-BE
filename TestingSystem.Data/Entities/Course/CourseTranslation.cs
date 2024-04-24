namespace TestingSystem.Data.Entities.Course
{
    public partial class CourseTranslation
    {
        public string LanguageCode { get; set; }

        public Guid CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string NumberOfAssignment { get; set; }

        public string NumberOfStudent { get; set; }

        public string NumberOfVideo { get; set; }

        public virtual Course Course { get; set; }

        public virtual LanguageTag Language { get; set; }
    }
}
