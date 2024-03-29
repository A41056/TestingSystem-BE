namespace TestingSystem.Data.Entities;
public class Answer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid QuestionId { get; set; }
    public bool? Correct { get; set; }
    public int? SortOrder { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual Question Question { get; set; }

    public virtual ICollection<WebUserChoose> WebUserChooses { get; set; } = new List<WebUserChoose>();
}
