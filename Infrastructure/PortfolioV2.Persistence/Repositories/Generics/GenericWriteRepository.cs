using Microsoft.EntityFrameworkCore;
using PortfolioV2.Domain.Entities.IBase;
using PortfolioV2.Domain.IRepositories.IGenerics;
using PortfolioV2.Persistence.Context.Data;

namespace PortfolioV2.Persistence.Repositories.Generics;

public class GenericWriteRepository<T> : IGenericWriteRepository<T> where T : class, IBaseEntity, new()
{
    protected readonly AppDbContext _context;

    public GenericWriteRepository(AppDbContext context)
    {
        _context = context;
    }


    protected DbSet<T> Table => _context.Set<T>();
    private async Task SaveAsync() => await _context.SaveChangesAsync();

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
        await SaveAsync();
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await Table.AddRangeAsync(entities);
        await SaveAsync();
    }

    public async Task<T> ChangeStatus(T entity)
    {
        entity.Status = !entity.Status;
        Table.Update(entity);
        await SaveAsync();
        return entity;
    }

    public async Task<T> DeleteAsync(T entity)
    {
        Table.Remove(entity);
        await SaveAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        Table.Update(entity);
        await SaveAsync();
        return entity;
    }
}
