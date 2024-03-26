using TestingSystem.Data.Models.Answer;

namespace TestingSystem.Data.Models.Question;
public class QuestionDto
{
    public Guid Id { get; set; }
    public int? SortOrder { get; set; }
    public string? Explanation { get; set; }
    public string? Note { get; set; }
    public bool? IsSingleChoice { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }
    public List<AnswerDto> Answers { get; set; }
}
