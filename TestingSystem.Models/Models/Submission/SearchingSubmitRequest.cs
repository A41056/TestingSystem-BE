using TestingSystem.Data.Common;

namespace TestingSystem.Data.Models.Submission;
public class SearchingSubmitRequest : PaginatedRequestModel
{
    public Guid? Id { get; set; }
    public Guid? UserId { get; set; }
    public Guid? ExamId { get; set; }
}
