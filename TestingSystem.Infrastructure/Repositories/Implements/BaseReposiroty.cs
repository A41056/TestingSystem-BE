using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using TestingSystem.Data.Common;
using TestingSystem.Data.Db;
using TestingSystem.Infrastructure.Repositories.Interfaces;

namespace TestingSystem.Infrastructure.Repositories.Implements;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly TestingSystemDbContext _dbContext;
    protected DbSet<T> DbSet;

    public BaseRepository(TestingSystemDbContext dbContext)
    {
        _dbContext = dbContext;
        DbSet = _dbContext.Set<T>();
    }

    public async Task<List<T>> GetAll(params string[] includes)
    {
        if (includes == null)
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }
        else
        {
            IQueryable<T> query = DbSet;

            // Include related entities
            IQueryable<T> includedQuery = query.AsNoTracking();
            if (includes != null && includes.Any())
            {
                foreach (var include in includes)
                {
                    includedQuery = includedQuery.Include(include);
                }
            }

            return await includedQuery.ToListAsync();
        }
    }

    public async Task<PaginatedResponseModel<T>> GetPaginatedData(int pageNumber, int pageSize)
    {
        var query = DbSet
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking();

        var data = await query.ToListAsync();
        var totalCount = await _dbContext.Set<T>().CountAsync();

        return new PaginatedResponseModel<T>(data, totalCount);
    }

    public async Task<PaginatedResponseModel<T>> GetPaginatedDataByRequest(
        PaginatedRequestModel request,
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        params Expression<Func<T, object>>[] includes)
    {
        var pageNum = request.PageNum;
        var pageSize = request.PageSize;

        // Include related entities
        IQueryable<T> includedQuery = DbSet.AsNoTracking();
        if (includes != null)
        {
            foreach (var include in includes)
            {
                includedQuery = includedQuery.Include(include);
            }
        }

        // Filtering
        IQueryable<T> filteredQuery = includedQuery;
        if (filter != null)
        {
            filteredQuery = includedQuery.Where<T>(filter);
        }

        // OrderBy
        IQueryable<T> orderedQuery = filteredQuery;
        if (orderBy != null)
        {
            orderedQuery = orderBy(filteredQuery);
        }

        // Pagination
        var paginatedQuery = orderedQuery
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize);

        // List related data
        var data = paginatedQuery.ToList();

        // Count all by filter
        var totalCount = await filteredQuery.CountAsync();

        return new PaginatedResponseModel<T>(data, totalCount, pageNum, pageSize);
    }

    public async Task<bool> CheckValidationByFilter(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = DbSet.AsNoTracking();
        var filteredQuery = query.Where(filter);
        if (filteredQuery != null && filteredQuery.Any())
        {
            return true;
        }
        return false;
    }

    public List<T> GetListFilterAdvance(Func<T, bool> filter,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = DbSet;

        // Include related entities
        IQueryable<T> includedQuery = query;
        if (includes != null)
        {
            foreach (var include in includes)
            {
                includedQuery = includedQuery.Include(include);
            }
        }

        // Filter
        var filteredQuery = includedQuery.AsEnumerable().Where(filter);
        return filteredQuery.ToList();
    }

    public async Task<List<T>> GetListByFilter(
        Expression<Func<T, bool>> filter,
        string sortColumnName = null,
        bool isDescending = false,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = DbSet;

        // Include related entities
        IQueryable<T> includedQuery = query;
        if (includes != null)
        {
            foreach (var include in includes)
            {
                includedQuery = includedQuery.Include(include);
            }
        }

        // Filter
        var filteredQuery = includedQuery.Where(filter);

        // OrderBy
        IQueryable<T> orderedQuery = filteredQuery;
        if (!string.IsNullOrEmpty(sortColumnName))
        {
            var entityType = typeof(T);
            var parameter = Expression.Parameter(entityType, "x");
            var property = Expression.Property(parameter, sortColumnName);
            var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), parameter);

            orderedQuery = isDescending
                ? orderedQuery.OrderByDescending(lambda)
                : orderedQuery.OrderBy(lambda);
        }

        return await orderedQuery.ToListAsync();
    }

    public async Task<T?> GetDetailByFilter(
        Expression<Func<T, bool>> filter,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = DbSet;

        // Include related entities
        IQueryable<T> includedQuery = query;
        if (includes != null)
        {
            foreach (var include in includes)
            {
                includedQuery = includedQuery.Include(include);
            }
        }

        var filteredQuery = includedQuery.Where(filter);
        if (!filteredQuery.Any())
            return null;
        return await filteredQuery.FirstOrDefaultAsync();
    }

    public async Task<T> GetDetailByFilterAdvance(
        Expression<Func<T, bool>> filter,
        params string[] includes)
    {
        IQueryable<T> query = DbSet;

        // Include related entities
        IQueryable<T> includedQuery = query;
        if (includes != null)
        {
            foreach (var include in includes)
            {
                includedQuery = includedQuery.Include(include);
            }
        }

        var filteredQuery = await includedQuery.Where(filter).FirstOrDefaultAsync();
        if (filteredQuery != null) return filteredQuery;
        return null;
    }

    public async Task<T> GetById<Tid>(Tid id)
    {
        var data = await _dbContext.Set<T>().FindAsync(id);
        if (data == null)
            return null;
        return data;
    }

    public async Task<bool> IsExists<Tvalue>(string key, Tvalue value)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, key);
        var constant = Expression.Constant(value);
        var equality = Expression.Equal(property, constant);
        var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);

        return await _dbContext.Set<T>().AnyAsync(lambda);
    }

    //Before update existence check
    public async Task<bool> IsExistsForUpdate<Tid>(Tid id, string key, string value)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, key);
        var constant = Expression.Constant(value);
        var equality = Expression.Equal(property, constant);

        var idProperty = Expression.Property(parameter, "Id");
        var idEquality = Expression.NotEqual(idProperty, Expression.Constant(id));

        var combinedExpression = Expression.AndAlso(equality, idEquality);
        var lambda = Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);

        return await _dbContext.Set<T>().AnyAsync(lambda);
    }

    public virtual async Task<T> Create(T model)
    {
        await _dbContext.Set<T>().AddAsync(model);
        await _dbContext.SaveChangesAsync();
        return model;
    }

    public virtual async Task CreateMany(IEnumerable<T> models)
    {
        await _dbContext.Set<T>().AddRangeAsync(models);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<IEnumerable<T>> BulkInsert(IEnumerable<T> lstModel)
    {
        await _dbContext.Set<T>().AddRangeAsync(lstModel);
        await _dbContext.SaveChangesAsync();
        return lstModel;
    }

    public async Task Update(T model)
    {
        _dbContext.Set<T>().Update(model);
        await _dbContext.SaveChangesAsync();
    }

    public void UpdateUnitOfWork(T model)
    {
        _dbContext.Set<T>().Update(model);
    }

    public async Task GetAndUpdateMany(Expression<Func<T, bool>> filter, Action<T> setProperty)
    {
        IQueryable<T> query = DbSet;

        // Get the records to be updated depending on the filter expression
        var recordsToBeUpdated = query.Where(filter).ToList();

        // Update the selected records
        recordsToBeUpdated.ForEach(setProperty);
    }

    public async Task Delete(T model)
    {
        _dbContext.Set<T>().Remove(model);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangeAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = DbSet;
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return query;
    }

    public async Task<EntityEntry<T>> AddUnitOfWork(T model)
    {
        return await _dbContext.Set<T>().AddAsync(model);
    }

    public async Task UpdateMany(IEnumerable<T> models)
    {
        _dbContext.Set<T>().UpdateRange(models);
        await _dbContext.SaveChangesAsync();
    }
}
