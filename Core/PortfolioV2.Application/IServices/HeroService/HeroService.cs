using PortfolioV2.Application.Commons.FactoryDtos.HeroDtoFactories;
using PortfolioV2.Application.IManagements.HeroManagements;
using PortfolioV2.DataTransfer.DTOs.HeroEntity;

namespace PortfolioV2.Application.IServices.HeroService;

public class HeroService : IHeroService
{
    private readonly IHeroManagementService _heroManagementService;
    private readonly IHeroDtoFactory _heroDtoFactory;

    public HeroService(IHeroManagementService heroManagementService, IHeroDtoFactory heroDtoFactory)
    {
        _heroManagementService = heroManagementService;
        _heroDtoFactory = heroDtoFactory;
    }

    public async Task CreateHeroAsync(CreateHeroDto heroDto, CancellationToken cancellationToken = default)
    {
        var newHero = _heroDtoFactory.CreateHero(heroDto);
        await _heroManagementService.TCreateHeroAsync(newHero, cancellationToken);
    }

    public async Task<IList<GetAllHeroDto>> GetAllHeroesListAsync(CancellationToken cancellationToken = default)
    {
        var heroes = await _heroManagementService.TGetAllHeroesAsync(cancellationToken);
        return _heroDtoFactory.CreateGetAllHeroDtos(heroes);
    }

    public async Task<GetAllHeroDto> GetHeroByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var hero = await _heroManagementService.TGetHeroByIdAsync(id, cancellationToken);
        return _heroDtoFactory.CreateGetAllHeroDto(hero);
    }
}
