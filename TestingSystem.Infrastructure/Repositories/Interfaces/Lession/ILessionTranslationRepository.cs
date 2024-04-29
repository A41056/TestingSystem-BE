using TestingSystem.Data.Models;
using TestingSystem.Data.Models.Course;

namespace TestingSystem.Infrastructure.Repositories.Interfaces.Lession
{
    public interface ILessionTranslationRepository : IBaseRepository<Data.Entities.LessionTranslation>
    {
        Task InsertTranslationAsync(Guid lessionId, LessionTranslationDtro model);

        Task DeleteAsync(Guid lessionId);

        Task<IEnumerable<LessionTranslationDtro>> GetLessionTranslationByIdAsync(Guid lessionId);
        Task<IEnumerable<LessionTranslationDtro>> GetListLessionByLanguageCode(string languageCode);
        Task<IEnumerable<LessionTranslationDtro>> GetListLessionByLessionId(Guid lessionId, string languageCode);
        Task<IEnumerable<LessionTranslationDtro>> GetListLessionTransByLessionIds(List<Guid> lessionId, string languageCode);
    }
}
