using PortfolioV2.Domain.Entities.IBase;

namespace PortfolioV2.Domain.IRepositories.IGenerics;

public interface IGenericWriteRepository<T> where T : class, IBaseEntity, new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IList<T> entities);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<T> ChangeStatus(T entity);
}
