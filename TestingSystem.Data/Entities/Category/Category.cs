namespace TestingSystem.Data.Entities.Category
{
    public class Category
    {
        public Guid Id { get; set; }
        public string NameNoneAscii { get; set; }
        public int SortOrder { get; set; }
        public bool Deleted { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public virtual ICollection<CategoryTranslation> CategoryTranslations { get; set; } = new List<CategoryTranslation>();

        public virtual ICollection<Course.Course> Courses { get; set; } = new List<Course.Course>();
    }
}
