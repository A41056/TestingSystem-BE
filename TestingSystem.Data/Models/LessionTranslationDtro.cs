namespace TestingSystem.Data.Models
{
    public class LessionTranslationDtro : BaseConcreteTranslation
    {
        public Guid LessonId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
