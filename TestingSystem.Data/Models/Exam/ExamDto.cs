using TestingSystem.Data.Models.Question;

namespace TestingSystem.Data.Models.Exam;
public class ExamDto
{
    public string? Title { get; set; }
    public bool? IsAutoGrade { get; set; }
    public Guid? ExamId { get; set; }
    public Guid? ModifiedByUserId { get; set; }
    public List<QuestionDto> Questions { get; set; }
}
