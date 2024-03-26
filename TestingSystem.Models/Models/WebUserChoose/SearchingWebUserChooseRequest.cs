using TestingSystem.Data.Common;

namespace TestingSystem.Data.Models.WebUserChoose;
public class SearchingWebUserChooseRequest : PaginatedRequestModel
{
    public Guid Id { get; set; }
    public Guid WebUserId { get; set; }
    public Guid QuestionId { get; set; }
    public Guid AnswerId { get; set; }
    public string AnswerText { get; set; }
    public bool CorrectAnswer { get; set; }
}
