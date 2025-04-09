using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PortfolioV2.Domain.Entities.IBase;
using PortfolioV2.Domain.IRepositories.IGenerics;
using PortfolioV2.Persistence.Context.Data;
using System.Linq.Expressions;

namespace PortfolioV2.Persistence.Repositories.Generics;

public class GenericReadRepository<T> : IGenericReadRepository<T> where T : class, IBaseEntity, new()
{
    protected readonly AppDbContext _context;

    public GenericReadRepository(AppDbContext context)
    {
        _context = context;
    }

    protected DbSet<T> Table { get => _context.Set<T>(); }
    protected IQueryable<T> GetQuery(bool enableTracking = true)
    {
        return enableTracking ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
    }

    public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
    {
        IQueryable<T> queryable = GetQuery(enableTracking);

        if (predicate is not null)
            queryable = queryable.Where(predicate);

        if (include is not null)
            queryable = include(queryable);

        if (orderBy is not null)
            queryable = orderBy(queryable);

        return await queryable.ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
    {
        IQueryable<T> query = GetQuery(enableTracking);

        query = query.Where(predicate);

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        IQueryable<T> query = GetQuery(false);

        if (predicate is not null)
            query = query.Where(predicate);

        return await query.CountAsync();
    }

    public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
    {
        IQueryable<T> query = GetQuery(false)
           .Where(predicate);

        return await query.FirstOrDefaultAsync();
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
    {
        return GetQuery(enableTracking).Where(predicate);
    }
}
