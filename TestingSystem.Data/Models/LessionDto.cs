namespace TestingSystem.Data.Models
{
    public class LessionDto
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }
        public int SortOrder { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
