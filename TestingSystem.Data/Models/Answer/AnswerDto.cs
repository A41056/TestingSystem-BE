namespace TestingSystem.Data.Models.Answer;
public class AnswerDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public bool? Correct { get; set; }
    public int? SortOrder { get; set; }
}
