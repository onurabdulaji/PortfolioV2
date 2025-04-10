using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PortfolioV2.Domain.IRepositories.IAbstracts.IHeroRepository;
using PortfolioV2.Domain.IRepositories.IGenerics;
using PortfolioV2.Domain.IRepositories.IUnitOfWorks;
using PortfolioV2.Persistence.Context.Data;
using PortfolioV2.Persistence.Repositories.Concretes.HeroRepositories;
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

    public IHeroReadRepository GetHeroReadRepository
    {
        get
        {
            if (!_repositories.ContainsKey(typeof(IHeroReadRepository)))
            {
                _logger.LogInformation("Creating new HeroReadRepository.");
            }
            else
            {
                _logger.LogInformation("Returning cached HeroReadRepository.");
            }
            return GetOrCreateRepository<IHeroReadRepository, HeroReadRepository>();
        }
    }

    public IHeroWriteRepository GetHeroWriteRepository
    {
        get
        {
            if (!_repositories.ContainsKey(typeof(IHeroWriteRepository)))
            {
                _logger.LogInformation("Creating new HeroWriteRepository.");
            }
            else
            {
                _logger.LogInformation("Returning cached HeroWriteRepository.");
            }
            return GetOrCreateRepository<IHeroWriteRepository, HeroWriteRepository>();
        }
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
            _logger.LogDebug("Attempting to save changes...");
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
            _logger.LogDebug("Attempting to save changes asynchronously...");
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
        _logger.LogInformation("GetGenericReadRepository<T> method called for type {Type}", typeof(T).Name);
        return GetOrCreateRepository<IGenericReadRepository<T>, GenericReadRepository<T>>();
    }

    IGenericWriteRepository<T> IUnitOfWork.GetGenericWriteRepository<T>()
    {
        _logger.LogInformation("GetGenericWriteRepository<T> method called for type {Type}", typeof(T).Name);
        return GetOrCreateRepository<IGenericWriteRepository<T>, GenericWriteRepository<T>>();
    }

    private TRepo GetOrCreateRepository<TInterface, TRepo>() where TRepo : class, TInterface
    {
        if (!_repositories.TryGetValue(typeof(TInterface), out var repo))
        {
            _logger.LogInformation("Creating new repository of type {Type}", typeof(TRepo).Name);
            repo = Activator.CreateInstance(typeof(TRepo), _context);
            _repositories[typeof(TInterface)] = repo;
        }
        else
        {
            _logger.LogInformation("Returning cached repository of type {Type}", typeof(TRepo).Name);
        }
        return (TRepo)repo;
    }

}
