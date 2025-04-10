using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using PortfolioV2.Domain.Entities.IBase;
using PortfolioV2.Domain.IRepositories.IGenerics;
using PortfolioV2.Persistence.Context.Data;
using System.Linq.Expressions;

namespace PortfolioV2.Persistence.Repositories.Generics;

public class GenericReadRepository<T> : IGenericReadRepository<T> where T : class, IBaseEntity, new()
{
    protected readonly AppDbContext _context;
    private readonly ILogger<GenericReadRepository<T>> _logger;
    public GenericReadRepository(AppDbContext context, ILogger<GenericReadRepository<T>> logger)
    {
        _context = context;
        _logger = logger;
    }

    protected DbSet<T> Table { get => _context.Set<T>(); }
    protected IQueryable<T> GetQuery(bool enableTracking = false)
    {
        _logger.LogInformation("GetQuery method called with enableTracking: {EnableTracking}", enableTracking);
        return enableTracking ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
    }

    public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
    {

        _logger.LogInformation("GetAllAsync method called with enableTracking: {EnableTracking}", enableTracking);
        IQueryable<T> queryable = GetQuery(enableTracking);

        if (predicate is not null)
            queryable = queryable.Where(predicate);
        _logger.LogInformation("Predicate applied: {Predicate}", predicate);

        if (include is not null)
            queryable = include(queryable);
        _logger.LogInformation("Include applied: {Include}", include);

        if (orderBy is not null)
            queryable = orderBy(queryable);
        _logger.LogInformation("OrderBy applied: {orderBy}", orderBy);

        var result = await queryable.ToListAsync();
        _logger.LogInformation("Query executed with result count: {Count}", result.Count);

        return result;
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
    {
        _logger.LogInformation("GetAsync method called with enableTracking: {EnableTracking}", enableTracking);
        IQueryable<T> query = GetQuery(enableTracking);

        query = query.Where(predicate);
        _logger.LogInformation("Predicate applied: {Predicate}", predicate);


        if (include is not null)
            query = include(query);
        _logger.LogInformation("Include applied: {Include}", include);

        var result = await query.FirstOrDefaultAsync();

        _logger.LogInformation("Query executed. Result: {Result}", result);

        return result;

    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        _logger.LogInformation("CountAsync method called with predicate: {Predicate}", predicate);

        IQueryable<T> query = GetQuery(false);

        if (predicate is not null)
            query = query.Where(predicate);
        _logger.LogInformation("Predicate applied: {Predicate}", predicate);

        _logger.LogInformation("Count result: {Count}", await query.CountAsync());
        return await query.CountAsync();
    }

    public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
    {
        _logger.LogInformation("FindAsync method called with predicate: {Predicate}", predicate);
        IQueryable<T> query = GetQuery(false)
           .Where(predicate);
        _logger.LogInformation("Predicate applied: {Predicate}", predicate);

        _logger.LogInformation("Query executed: {query}", query.FirstOrDefaultAsync());
        return await query.FirstOrDefaultAsync();
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
    {
        _logger.LogInformation("Find method called with enableTracking: {EnableTracking}", enableTracking);

        _logger.LogInformation("Predicate applied: {Predicate}", predicate);
        return GetQuery(enableTracking).Where(predicate);
    }
}
