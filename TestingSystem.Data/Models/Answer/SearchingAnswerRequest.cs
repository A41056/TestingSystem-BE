using TestingSystem.Data.Common;

namespace TestingSystem.Data.Models.Answer;
public class SearchingAnswerRequest : PaginatedRequestModel
{
    public Guid? Id { get; set; }
    public Guid? QuestionId { get; set; }
}
