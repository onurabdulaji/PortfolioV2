using PortfolioV2.Domain.Entities;
using PortfolioV2.Domain.IRepositories.IGenerics;

namespace PortfolioV2.Domain.IRepositories.IAbstracts.IHeroRepository;

public interface IHeroWriteRepository : IGenericWriteRepository<Hero>
{
    // Kahraman ekleme
    Task AddAsync(Hero hero, CancellationToken cancellationToken = default);

    // Kahramanları topluca ekleme
    Task AddRangeAsync(IList<Hero> heroes, CancellationToken cancellationToken = default);

    // Kahraman güncelleme
    Task UpdateAsync(Hero hero, CancellationToken cancellationToken = default);

    // Kahraman silme
    Task DeleteAsync(Hero hero, CancellationToken cancellationToken = default);

    // Kahraman durumunu değiştirme (aktif/pasif vs.)
    Task ChangeStatusAsync(Hero hero, CancellationToken cancellationToken = default);

    // Kahramanları topluca silme
    Task DeleteRangeAsync(IList<Hero> heroes, CancellationToken cancellationToken = default);

}
