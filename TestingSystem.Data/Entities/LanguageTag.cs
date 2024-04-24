using TestingSystem.Data.Entities.Category;
using TestingSystem.Data.Entities.Course;

namespace TestingSystem.Data.Entities
{
    public class LanguageTag
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        public int SortOrder { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public virtual ICollection<CategoryTranslation> CategoryTranslations { get; set; } = new List<CategoryTranslation>();

        public virtual ICollection<CourseDetailTranslation> CourseDetailTranslations { get; set; } = new List<CourseDetailTranslation>();

        public virtual ICollection<CourseTeacherTranslation> CourseTeacherTranslations { get; set; } = new List<CourseTeacherTranslation>();

        public virtual ICollection<CourseTranslation> CourseTranslations { get; set; } = new List<CourseTranslation>();
        public virtual ICollection<LessionTranslation> LessionTranslations { get; set; } = new List<LessionTranslation>();

    }
}
