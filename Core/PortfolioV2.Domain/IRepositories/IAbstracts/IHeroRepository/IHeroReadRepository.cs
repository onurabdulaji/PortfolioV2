using PortfolioV2.Domain.Entities;
using PortfolioV2.Domain.IRepositories.IGenerics;
using System.Linq.Expressions;

namespace PortfolioV2.Domain.IRepositories.IAbstracts.IHeroRepository;

public interface IHeroReadRepository : IGenericReadRepository<Hero>
{
    // Tüm kahramanları listeleme
    Task<IList<Hero>> GetAllHeroesListAsync(bool trackingChanges = false, CancellationToken cancellationToken = default);

    // Id'ye göre kahraman getirme
    Task<Hero> GetHeroByIdAsync(Expression<Func<Hero, bool>> predicate, bool trackingChanges = false, CancellationToken cancellationToken = default);

    // Kahraman sayısını alma
    Task<int> CountHeroAsync(Expression<Func<Hero, bool>>? predicate = null);

    // Sadece bir kahraman bulma
    Task<Hero> FindHeroAsync(Expression<Func<Hero, bool>> predicate);

    // Kahramanları IQueryable olarak getirme
    IQueryable<Hero> FindHero(Expression<Func<Hero, bool>> predicate, bool enableTracking = false);

    // Birden fazla id'ye göre kahramanları getirme
    Task<IList<Hero>> GetByIdsAsync(IList<string> ids, bool trackingChanges = false, CancellationToken cancellationToken = default);

}
