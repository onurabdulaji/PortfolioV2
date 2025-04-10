using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PortfolioV2.Domain.Entities;
using PortfolioV2.Domain.IRepositories.IAbstracts.IHeroRepository;
using PortfolioV2.Persistence.Context.Data;
using PortfolioV2.Persistence.Repositories.Generics;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PortfolioV2.Persistence.Repositories.Concretes.HeroRepositories;

public class HeroReadRepository : GenericReadRepository<Hero>, IHeroReadRepository
{
    public HeroReadRepository(AppDbContext context, ILogger<GenericReadRepository<Hero>> logger) : base(context, logger)
    {
    }

    public async Task<int> CountHeroAsync(Expression<Func<Hero, bool>>? predicate = null)
    {
        var query = GetQuery(false);
        if (predicate is not null)
            query = query.Where(predicate);

        return await query.CountAsync();
    }

    public IQueryable<Hero> FindHero(Expression<Func<Hero, bool>> predicate, bool enableTracking = false)
    {
        var query = GetQuery(enableTracking);  
        return query.Where(predicate); 
    }

    public async Task<Hero> FindHeroAsync(Expression<Func<Hero, bool>> predicate)
    {
        var query = GetQuery();  
        return await query.FirstOrDefaultAsync(predicate);
    }

    public async Task<IList<Hero>> GetAllHeroesListAsync(bool trackingChanges = false, CancellationToken cancellationToken = default)
    {
        var query = GetQuery(trackingChanges);
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<IList<Hero>> GetByIdsAsync(IList<string> ids, bool trackingChanges = false, CancellationToken cancellationToken = default)
    {
        var query = GetQuery(trackingChanges);
        query = query.Where(hero => ids.Contains(hero.Id));

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<Hero> GetHeroByIdAsync(Expression<Func<Hero, bool>> predicate, bool trackingChanges = false, CancellationToken cancellationToken = default)
    {
        var query = GetQuery(trackingChanges);
        return await query.FirstOrDefaultAsync(predicate, cancellationToken);
    }
}
