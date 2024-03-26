namespace TestingSystem.Data.Models.Submission;
public class CreateOrUpdateSubmitRequest
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ExamId { get; set; }
    public bool IsAutoGrade { get; set; }
    public DateTime? SubmittedAt { get; set; }
}
