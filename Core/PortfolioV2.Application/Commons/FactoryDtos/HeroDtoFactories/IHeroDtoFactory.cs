using PortfolioV2.DataTransfer.DTOs.HeroEntity;
using PortfolioV2.Domain.Entities;

namespace PortfolioV2.Application.Commons.FactoryDtos.HeroDtoFactories;

public interface IHeroDtoFactory
{
    CreateHeroDto CreateHeroDto(Hero hero);
    Hero CreateHero(CreateHeroDto heroDto);
    GetAllHeroDto CreateGetAllHeroDto(Hero hero);
    IList<GetAllHeroDto> CreateGetAllHeroDtos(IList<Hero> heroes);
    CreateHeroResponseDto CreateHeroResponseDto(CreateHeroDto createHeroDto);

}
