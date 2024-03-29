namespace TestingSystem.Data.Models.Submission;
public class SubmissionDto
{
    public Guid? Id { get; set; }
    public Guid? StudentId { get; set; }
    public Guid? ExamId { get; set; }
    public DateTime? SubmittedAt { get; set; }
    public double? Score { get; set; }
}
