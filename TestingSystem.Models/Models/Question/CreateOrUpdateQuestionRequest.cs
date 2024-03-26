using TestingSystem.Data.Models.Answer;

namespace TestingSystem.Data.Models.Question;
public class CreateOrUpdateQuestionRequest
{
    public Guid? QuestionId { get; set; }
    public Guid? ExamId { get; set; }
    public int? SortOrder { get; set; }
    public string? Explanation { get; set; }
    public string? Note { get; set; }
    public bool? IsSingleChoice { get; set; }

    public ICollection<CreateOrUpdateAnswerRequest>? Answers { get; set; }
}
