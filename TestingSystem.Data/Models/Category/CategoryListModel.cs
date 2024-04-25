namespace TestingSystem.Data.Models.Category
{
    public class CategoryListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameNonAscii { get; set; }
        public int SortOrder { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public bool IsActive { get; set; }
    }
}
