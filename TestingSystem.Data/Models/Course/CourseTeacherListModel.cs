namespace TestingSystem.Data.Models.Course
{
    public class CourseTeacherListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string University { get; set; }
        public int SortOrder { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
    }
}
