using TestingSystem.Data.Common;

namespace TestingSystem.Data.Models.Question;
public class SearchingQuestionRequest : PaginatedRequestModel
{
    public Guid? ExamId { get; set; }
    public string? Explannation { get; set; }
}
