using Microsoft.Extensions.Logging;
using PortfolioV2.Domain.IRepositories.IGenerics;
using PortfolioV2.Domain.IRepositories.IUnitOfWorks;
using PortfolioV2.Persistence.Context.Data;
using PortfolioV2.Persistence.Repositories.Generics;

namespace PortfolioV2.Persistence.Repositories.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly Dictionary<Type,object> _repositories = new();
    private readonly ILogger<UnitOfWork> _logger;

    public UnitOfWork(AppDbContext context, ILogger<UnitOfWork> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    public int SaveChanges()
    {
        try
        {
            return _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while saving changes to the database + UoW.");
            return -1;
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while saving changes to the database + UoW.");
            return -1;
        }
    }

    IGenericReadRepository<T> IUnitOfWork.GetGenericReadRepository<T>()
    {
        return GetOrCreateRepository<IGenericReadRepository<T>, GenericReadRepository<T>>();
    }

    IGenericWriteRepository<T> IUnitOfWork.GetGenericWriteRepository<T>()
    {
        return GetOrCreateRepository<IGenericWriteRepository<T>, GenericWriteRepository<T>>();
    }

    private TRepo GetOrCreateRepository<TInterface, TRepo>() where TRepo : class, TInterface
    {
        if (!_repositories.TryGetValue(typeof(TInterface), out var repo))
        {
            repo = Activator.CreateInstance(typeof(TRepo), _context);
            _repositories[typeof(TInterface)] = repo;
        }
        return (TRepo)repo;
    }
}
