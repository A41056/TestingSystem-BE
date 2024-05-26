using TestingSystem.Data.Models.Question;
using TestingSystem.Utilities.Enum;

namespace TestingSystem.Data.Models.Exam;
public class CreateOrUpdateExamRequest
{
    public Guid? Id { get; set; }
    public Guid? LessonId { get; set; }
    public string? Title { get; set; }
    public Guid CreatedByUserId { get; set; }
    public Guid ModifiedByUserId { get; set; }
    public ICollection<CreateOrUpdateQuestionRequest>? Questions { get; set; }
}
