using TestingSystem.Utilities.Enum;

namespace TestingSystem.Data.Entities;
public class Exam
{
    public Guid ExamId { get; set; }
    public string Title { get; set; }
    public ExamStatus Status { get; set; }
    public bool IsAutoGrade { get; set; }
    public Guid CreatedByUserId { get; set; }
    public Guid ModifiedByUserId { get; set; }
    public DateTime? Created{ get; set; }
    public DateTime? Modified { get; set; }

    public User Teacher { get; set; } // Navigation property
    public ICollection<Question> Questions { get; set; } // Navigation property
    public ICollection<Submission> Submissions { get; set; }
}
