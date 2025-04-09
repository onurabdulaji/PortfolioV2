using PortfolioV2.DataTransfer.DTOs.HeroEntity;

namespace PortfolioV2.Application.IServices.HeroService;

public interface IHeroService
{
    Task CreateHeroAsync(CreateHeroDto heroDto , CancellationToken cancellationToken = default);
    Task<IList<GetAllHeroDto>> GetAllHeroesListAsync(CancellationToken cancellationToken = default);
    Task<GetAllHeroDto> GetHeroByIdAsync(string id , CancellationToken cancellationToken = default);
}
