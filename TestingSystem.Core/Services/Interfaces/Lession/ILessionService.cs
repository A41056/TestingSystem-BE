using TestingSystem.Data.Models;

namespace TestingSystem.Core.Services.Interfaces.Lession
{
    public interface ILessionService
    {
        Task InsertAsync(Guid lessionId, LessionDto model);
        Task<IEnumerable<LessionDto>> GetLessionListByCourseIdAsync(Guid courseId);
        Task<IEnumerable<LessionDto>> GetLessionTransListByCourseIdAsync(Guid courseId, string languageCode);
        Task<LessionDto> GetLessionByIdAsync(Guid lessionId);

        Task DeleteLessionAsync(Guid lessionId);
        Task UpdateLessionAsync(Guid lessionId, LessionDto model);

        Task InsertTranslationAsync(Guid lessionId, LessionTranslationDtro model);
        Task DeleteLessionTranslationAsync(Guid lessionId);
        Task<IEnumerable<LessionTranslationDtro>> GetLessionTranslationByIdAsync(Guid lessionId);
        Task<IEnumerable<LessionTranslationDtro>> GetListLessionByLanguageCode(string languageCode);
        Task<IEnumerable<LessionTranslationDtro>> GetListLessionByLessionId(Guid lessionId, string languageCode);
        Task<IEnumerable<LessionTranslationDtro>> GetListLessionTransByLessionIds(List<Guid> lessionId, string languageCode);
    }
}
