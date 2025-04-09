using Microsoft.EntityFrameworkCore;
using PortfolioV2.Domain.Entities;
using PortfolioV2.Domain.IRepositories.IAbstracts.IHeroRepository;
using PortfolioV2.Persistence.Context.Data;
using PortfolioV2.Persistence.Repositories.Generics;

namespace PortfolioV2.Persistence.Repositories.Concretes.HeroRepositories;

public class HeroWriteRepository : GenericWriteRepository<Hero>, IHeroWriteRepository
{
    public HeroWriteRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(Hero hero, CancellationToken cancellationToken = default)
    {
        await Table.AddAsync(hero, cancellationToken);
        await SaveAsync();
    }

    public async Task AddRangeAsync(IList<Hero> heroes, CancellationToken cancellationToken = default)
    {
        await Table.AddRangeAsync(heroes, cancellationToken);
        await SaveAsync();
    }

    public async Task ChangeStatusAsync(Hero hero, CancellationToken cancellationToken = default)
    {
        hero.Status = !hero.Status;
        Table.Update(hero);
        await SaveAsync();
    }

    public async Task DeleteAsync(Hero hero, CancellationToken cancellationToken = default)
    {
        Table.Remove(hero);
        await SaveAsync();
    }

    public async Task DeleteRangeAsync(IList<Hero> heroes, CancellationToken cancellationToken = default)
    {
        Table.RemoveRange(heroes);
        await SaveAsync();
    }

    public async Task UpdateAsync(Hero hero, CancellationToken cancellationToken = default)
    {
        Table.Update(hero);
        await SaveAsync();
    }
}
