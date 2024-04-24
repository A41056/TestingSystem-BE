namespace TestingSystem.Data.Entities.Category
{
    public class CategoryTranslation
    {
        public string LanguageCode { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual LanguageTag Language { get; set; }
    }
}
