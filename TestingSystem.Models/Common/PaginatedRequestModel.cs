namespace TestingSystem.Data.Common;
public class PaginatedRequestModel
{
    public string? Keyword { get; set; }
    public List<string> ListKeyword { get; set; } = new();
    public int PageNum { get; set; } = 1;
    public int PageSize { get; set; } = 15;
}
