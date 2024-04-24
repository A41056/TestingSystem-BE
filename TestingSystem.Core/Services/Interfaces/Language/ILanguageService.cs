using TestingSystem.Data.Models;

namespace TestingSystem.Core.Services.Interfaces.Language
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageTagsDto>> GetListAsync();
        Task<LanguageTagsDto> GetDefault();
    }
}
