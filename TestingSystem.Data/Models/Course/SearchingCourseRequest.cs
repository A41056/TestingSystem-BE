using TestingSystem.Data.Common;

namespace TestingSystem.Data.Models.Course
{
    public class SearchingCourseRequest : PaginatedRequestModel
    {
        public string? NameNonAscii { get; set; }
        public string? FullTextSearch { get; set; }

        public Guid? CategoryId { get; set; }
        public string? LanguageCode { get; set; }
    }
}
