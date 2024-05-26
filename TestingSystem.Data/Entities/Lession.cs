namespace TestingSystem.Data.Entities
{
    public class Lession
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public int SortOrder { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public Course.Course Course { get; set; }
        public virtual ICollection<LessionTranslation> LessionTranslations { get; set; } = new List<LessionTranslation>();
        public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    }
}
