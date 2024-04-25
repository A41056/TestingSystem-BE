namespace TestingSystem.Data.Models.Course
{
    public class CourseInfoDto : BaseTranslation<CourseInsertOrUpdateTranslationDto>
    {
        public Guid Id { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? AuthorId { get; set; }
        public short? Status { get; set; }
        public string? NameNonAscii { get; set; }
        public bool? IsHot { get; set; }
        public string? Tags { get; set; }
        public string? CourseImageUrl { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
