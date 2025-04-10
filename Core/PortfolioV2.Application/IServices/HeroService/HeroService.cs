using Microsoft.Extensions.Logging;
using PortfolioV2.Application.Commons.FactoryDtos.HeroDtoFactories;
using PortfolioV2.Application.IManagements.HeroManagements;
using PortfolioV2.DataTransfer.DTOs.HeroEntity;

namespace PortfolioV2.Application.IServices.HeroService;

public class HeroService : IHeroService
{
    private readonly IHeroManagementService _heroManagementService;
    private readonly IHeroDtoFactory _heroDtoFactory;
    private readonly ILogger<HeroService> _logger;

    public HeroService(IHeroManagementService heroManagementService, IHeroDtoFactory heroDtoFactory, ILogger<HeroService> logger)
    {
        _heroManagementService = heroManagementService;
        _heroDtoFactory = heroDtoFactory;
        _logger = logger;
    }

    public async Task CreateHeroAsync(CreateHeroDto heroDto, CancellationToken cancellationToken = default)
    {
        var newHero = _heroDtoFactory.CreateHero(heroDto);
        _logger.LogInformation("Creating new hero with title: {Title}", newHero.Title);
        await _heroManagementService.TCreateHeroAsync(newHero, cancellationToken);
        _logger.LogInformation("Hero created successfully with title: {Title}", newHero.Title);
    }

    public async Task<IList<GetAllHeroDto>> GetAllHeroesListAsync(CancellationToken cancellationToken = default)
    {
        var heroes = await _heroManagementService.TGetAllHeroesAsync(cancellationToken);
        _logger.LogInformation("Retrieved {Count} heroes", heroes.Count);
        return _heroDtoFactory.CreateGetAllHeroDtos(heroes);
    }

    public async Task<GetAllHeroDto> GetHeroByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var hero = await _heroManagementService.TGetHeroByIdAsync(id, cancellationToken);
        _logger.LogInformation("Retrieved hero with ID: {Id}", id);
        return _heroDtoFactory.CreateGetAllHeroDto(hero);
    }
}
