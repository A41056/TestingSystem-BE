namespace TestingSystem.Data.Entities.Course
{
    public class CourseDetail
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public int? SortOrder { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<CourseDetailTranslation> CourseDetailTranslations { get; set; } = new List<CourseDetailTranslation>();
    }
}
