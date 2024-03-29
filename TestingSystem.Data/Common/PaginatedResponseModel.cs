namespace TestingSystem.Data.Common;
public class PaginatedResponseModel<T>
{
    public List<T> Data { get; set; } = new();
    public int PageNum { get; set; } = 1;
    public int PageSize { get; set; } = 15;
    public int TotalPages { get; set; } = 0;
    public int TotalRecords { get; set; } = 0;
    public int? TotalChildrenRecords { get; set; } = 0;

    public PaginatedResponseModel()
    { }

    public PaginatedResponseModel(List<T> data, int totalCount, int? totalChildrenCount = null)
    {
        Data = data;
        TotalRecords = totalCount;
        TotalChildrenRecords = totalChildrenCount.HasValue ? totalChildrenCount : totalCount;
        TotalPages = (int)(TotalRecords / (double)PageSize);
    }

    public PaginatedResponseModel(List<T> data, int totalCount, int pageNum, int pageSize, int? totalChildrenCount = null)
    {
        Data = data;
        TotalRecords = totalCount;
        TotalChildrenRecords = totalChildrenCount.HasValue ? totalChildrenCount : totalCount;
        TotalPages = (int)Math.Ceiling(TotalRecords / (double)pageSize);
        PageNum = pageNum;
        PageSize = pageSize;
    }
}
