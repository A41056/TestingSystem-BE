namespace TestingSystem.Data.Models.Answer
{
    public class AnswerTranslationCreateOrUpdateDto : BaseConcreteTranslation
    {
        public Guid AnswerId { get; set; }

        public string Content { get; set; }
    }
}
