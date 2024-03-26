using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using TestingSystem.Data.Common;

namespace TestingSystem.Infrastructure.Repositories.Interfaces;
public interface IBaseRepository<T> where T : class
{
    Task<List<T>> GetAll(params string[] includes);
    Task CreateMany(IEnumerable<T> models);
    Task<PaginatedResponseModel<T>> GetPaginatedData(int pageNumber, int pageSize);

    Task<PaginatedResponseModel<T>> GetPaginatedDataByRequest(PaginatedRequestModel request, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);

    Task<bool> CheckValidationByFilter(Expression<Func<T, bool>> filter);

    Task<List<T>> GetListByFilter(Expression<Func<T, bool>> filter, string sortColumnName = null, bool isDescending = false, params Expression<Func<T, object>>[] includes);

    Task<T> GetDetailByFilter(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);

    Task<T> GetById<Tid>(Tid id);

    Task<bool> IsExists<Tvalue>(string key, Tvalue value);

    Task<T> GetDetailByFilterAdvance(
        Expression<Func<T, bool>> filter,
        params string[] includes);

    Task<bool> IsExistsForUpdate<Tid>(Tid id, string key, string value);

    Task<T> Create(T model);

    Task<IEnumerable<T>> BulkInsert(IEnumerable<T> lstModel);

    Task<EntityEntry<T>> AddUnitOfWork(T model);

    Task Update(T model);
    Task UpdateMany(IEnumerable<T> models);
    void UpdateUnitOfWork(T model);

    Task GetAndUpdateMany(Expression<Func<T, bool>> filter, Action<T> setProperty);

    Task Delete(T model);

    Task SaveChangeAsync();
    List<T> GetListFilterAdvance(Func<T, bool> filter,
        params Expression<Func<T, object>>[] includes);
    IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
}
