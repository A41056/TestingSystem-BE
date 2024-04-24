using TestingSystem.Data.Entities;
using TestingSystem.Data.Models;

namespace TestingSystem.Infrastructure.Repositories.Interfaces
{
    public interface ILanguageTagRepository : IBaseRepository<LanguageTag>
    {
        Task<IEnumerable<LanguageTagsDto>> GetListAsync();
        Task<LanguageTagsDto> GetDefault();
    }
}
