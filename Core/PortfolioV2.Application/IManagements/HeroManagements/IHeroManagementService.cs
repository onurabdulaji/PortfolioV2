using PortfolioV2.Domain.Entities;

namespace PortfolioV2.Application.IManagements.HeroManagements;

public interface IHeroManagementService
{
    // Write
    Task TCreateHeroAsync(Hero createHero, CancellationToken cancellationToken = default);

    // Read
    Task<IList<Hero>> TGetAllHeroesAsync(CancellationToken cancellationToken = default);
    Task<Hero?> TGetHeroByIdAsync(string id, CancellationToken cancellationToken = default);

}
