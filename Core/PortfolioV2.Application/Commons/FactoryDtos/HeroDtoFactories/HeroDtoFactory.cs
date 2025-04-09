using Mapster;
using PortfolioV2.DataTransfer.DTOs.HeroEntity;
using PortfolioV2.Domain.Entities;

namespace PortfolioV2.Application.Commons.FactoryDtos.HeroDtoFactories;

public class HeroDtoFactory : IHeroDtoFactory
{
    public CreateHeroDto CreateHeroDto(Hero hero) // Bu islemde belki Guncellemede 
    {
        return hero.Adapt<CreateHeroDto>();
    }

    public Hero CreateHero(CreateHeroDto heroDto) // Bu islem eklerken 
    {
        return heroDto.Adapt<Hero>();
    }

    public GetAllHeroDto CreateGetAllHeroDto(Hero hero)
    {
        return hero.Adapt<GetAllHeroDto>();
    }

    public IList<GetAllHeroDto> CreateGetAllHeroDtos(IList<Hero> heroes)
    {
        return heroes.Adapt<IList<GetAllHeroDto>>();
    }

    
}
