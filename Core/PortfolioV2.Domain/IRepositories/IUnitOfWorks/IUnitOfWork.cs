using PortfolioV2.Domain.Entities.IBase;
using PortfolioV2.Domain.IRepositories.IGenerics;

namespace PortfolioV2.Domain.IRepositories.IUnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable , IDisposable
{
    IGenericReadRepository<T> GetGenericReadRepository<T>() where T : class , IBaseEntity , new();
    IGenericWriteRepository<T> GetGenericWriteRepository<T>() where T : class , IBaseEntity , new();
    Task<int> SaveChangesAsync();
    int SaveChanges();
}
