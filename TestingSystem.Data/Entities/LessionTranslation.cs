namespace TestingSystem.Data.Entities
{
    public class LessionTranslation
    {
        public Guid Id { get; set; }
        public string LanguageCode { get; set; }
        public Guid LessionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual Lession Lession { get; set; }
        public virtual LanguageTag Language { get; set; }
    }
}
