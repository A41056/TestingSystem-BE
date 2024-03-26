using TestingSystem.Data.Common;
using TestingSystem.Utilities.Enum;

namespace TestingSystem.Data.Models.Exam;
public class SearchingExamRequest : PaginatedRequestModel
{
    public Guid? ExamId { get; set; }
    public string? Title { get; set; }
    public ExamStatus? Status { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public Guid? CreatedByUserId { get; set; }
    public Guid? ModifiedByUserId { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }
}
