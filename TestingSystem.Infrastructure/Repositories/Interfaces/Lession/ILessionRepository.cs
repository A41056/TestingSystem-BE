using TestingSystem.Data.Models;

namespace TestingSystem.Infrastructure.Repositories.Interfaces.Lession
{
    public interface ILessionRepository : IBaseRepository<Data.Entities.Lession>
    {
        Task InsertAsync(Guid lessionId, LessionDto model);
        Task<IEnumerable<LessionDto>> GetLessionListByCourseIdAsync(Guid courseId);
        Task<LessionDto> GetLessionByIdAsync(Guid lessionId);
        Task DeleteAsync(Guid lessionId);
        Task UpdateLessionAsync(Guid lessionId, LessionDto model);
    }
}
