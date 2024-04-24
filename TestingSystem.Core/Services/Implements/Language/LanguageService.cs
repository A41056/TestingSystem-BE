using TestingSystem.Core.Services.Interfaces.Language;
using TestingSystem.Data.Models;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Core.Services.Implements.Language
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageTagRepository _languageTagRepository;
        public LanguageService(ILanguageTagRepository languageTagRepository) 
        {
            _languageTagRepository = languageTagRepository;
        }

        public Task<LanguageTagsDto> GetDefault()
        {
            return _languageTagRepository.GetDefault();
        }

        public Task<IEnumerable<LanguageTagsDto>> GetListAsync()
        {
            return _languageTagRepository.GetListAsync();
        }
    }
}
