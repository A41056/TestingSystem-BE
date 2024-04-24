using TestingSystem.Core.Services.Interfaces.Lession;
using TestingSystem.Data.Models;
using TestingSystem.Infrastructure.Repositories.Interfaces.Lession;

namespace TestingSystem.Core.Services.Implements.Lession
{
    public class LessionService : ILessionService
    {
        private readonly ILessionRepository _lessionRepository;
        private readonly ILessionTranslationRepository _lessionTranslationRepository;

        public LessionService(ILessionRepository lessionRepository, ILessionTranslationRepository lessionTranslationRepository) 
        {
            _lessionRepository = lessionRepository;
            _lessionTranslationRepository = lessionTranslationRepository;
        }

        public async Task DeleteLessionAsync(Guid lessionId)
        {
            await _lessionRepository.DeleteAsync(lessionId);
        }

        public async Task DeleteLessionTranslationAsync(Guid lessionId)
        {
            await _lessionTranslationRepository.DeleteAsync(lessionId);
        }

        public async Task<LessionDto> GetLessionByIdAsync(Guid lessionId)
        {
            return await _lessionRepository.GetLessionByIdAsync(lessionId);
        }

        public async Task<IEnumerable<LessionDto>> GetLessionListByCourseIdAsync(Guid courseId)
        {
            return await _lessionRepository.GetLessionListByCourseIdAsync(courseId);
        }

        public async Task<IEnumerable<LessionTranslationDtro>> GetLessionTranslationByIdAsync(Guid lessionId)
        {
            return await _lessionTranslationRepository.GetLessionTranslationByIdAsync(lessionId);
        }

        public async Task<IEnumerable<LessionTranslationDtro>> GetListLessionByLanguageCode(string languageCode)
        {
            return await _lessionTranslationRepository.GetListLessionByLanguageCode(languageCode);
        }

        public async Task<IEnumerable<LessionTranslationDtro>> GetListLessionByLessionId(Guid lessionId, string languageCode)
        {
            return await _lessionTranslationRepository.GetListLessionByLessionId(lessionId, languageCode);
        }

        public async Task InsertAsync(Guid lessionId, LessionDto model)
        {
            await _lessionRepository.InsertAsync(lessionId, model);
        }

        public async Task InsertTranslationAsync(Guid lessionId, LessionTranslationDtro model)
        {
            await _lessionTranslationRepository.InsertTranslationAsync(lessionId, model);
        }

        public async Task UpdateLessionAsync(Guid lessionId, LessionDto model)
        {
            await _lessionRepository.UpdateLessionAsync(lessionId, model);  
        }
    }
}
