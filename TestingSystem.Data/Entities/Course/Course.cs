namespace TestingSystem.Data.Entities.Course
{
    public partial class Course
    {
        public Guid Id { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? AuthorId { get; set; }
        public short Status { get; set; }
        public string NameNonAscii { get; set; }
        public bool? IsHot { get; set; }
        public string Tags { get; set; }
        public short ProductType { get; set; }
        public string? CourseImageUrl { get; set; }
        public string FullTextSearch { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public virtual Category.Category Category { get; set; }

        public virtual User Author { get; set; }

        public virtual CourseTeacher CourseTeacher { get; set; }

        public virtual ICollection<CourseDetail> CourseDetails { get; set; } = new List<CourseDetail>();

        public virtual ICollection<CourseTranslation> CourseTranslations { get; set; } = new List<CourseTranslation>();
        public virtual ICollection<Lession> Lessions { get; set; } = new List<Lession>();

    }
}
