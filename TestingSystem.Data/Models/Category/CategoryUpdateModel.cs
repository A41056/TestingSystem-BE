namespace TestingSystem.Data.Models.Category
{
    public class CategoryUpdateModel
    {
        public string NameNonAscii { get; set; }
        public string LinkUrl { get; set; }
        public int SortOrder { get; set; }
        public Guid? ParentId { get; set; }
        public short CategoryType { get; set; }
        public Guid? ImageFileId { get; set; }
    }
}
