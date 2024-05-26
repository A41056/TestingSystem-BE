namespace TestingSystem.Data.Models.Question
{
    public class QuestionTranslationCreateOrUpdateDto : BaseConcreteTranslation
    {
        public Guid QuestionId { get; set; }

        public string Content { get; set; }
    }
}
