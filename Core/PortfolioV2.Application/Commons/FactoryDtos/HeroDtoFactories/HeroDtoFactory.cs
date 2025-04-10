using Mapster;
using Microsoft.Extensions.Logging;
using PortfolioV2.DataTransfer.DTOs.HeroEntity;
using PortfolioV2.Domain.Entities;

namespace PortfolioV2.Application.Commons.FactoryDtos.HeroDtoFactories;

public class HeroDtoFactory : IHeroDtoFactory
{
    private readonly ILogger<HeroDtoFactory> _logger;

    public HeroDtoFactory(ILogger<HeroDtoFactory> logger)
    {
        _logger = logger;
    }

    public CreateHeroDto CreateHeroDto(Hero hero) // Bu islemde belki Guncellemede 
    {
        if (hero == null)
        {
            _logger.LogError("Hero is null");
            throw new ArgumentNullException(nameof(hero));
        }
        return hero.Adapt<CreateHeroDto>();
    }

    public Hero CreateHero(CreateHeroDto heroDto) // Bu islem eklerken 
    {
        if (heroDto == null)
        {
            _logger.LogError("HeroDto is null");
            throw new ArgumentNullException(nameof(heroDto));
        }
        return heroDto.Adapt<Hero>();
    }

    public GetAllHeroDto CreateGetAllHeroDto(Hero hero)
    {
        if (hero == null)
        {
            _logger.LogError("Hero is null");
            throw new ArgumentNullException(nameof(hero));
        }
        return hero.Adapt<GetAllHeroDto>();
    }

    public IList<GetAllHeroDto> CreateGetAllHeroDtos(IList<Hero> heroes)
    {
        if (heroes == null || heroes.Any())
        {
            _logger.LogError("Heroes list is null or empty");
            throw new ArgumentNullException(nameof(heroes));
        }
        return heroes.Adapt<IList<GetAllHeroDto>>();
    }
}
