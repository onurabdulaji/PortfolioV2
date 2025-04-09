using PortfolioV2.Domain.Entities;
using PortfolioV2.Domain.IRepositories.IUnitOfWorks;

namespace PortfolioV2.Application.IManagements.HeroManagements;

public class HeroManagementService : IHeroManagementService
{
    private readonly IUnitOfWork _unitOfWork;

    public HeroManagementService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task TCreateHeroAsync(Hero createHero, CancellationToken cancellationToken = default)
    {
        await _unitOfWork.GetHeroWriteRepository.AddAsync(createHero, cancellationToken);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IList<Hero>> TGetAllHeroesAsync(CancellationToken cancellationToken = default)
    {
        var list = await _unitOfWork.GetHeroReadRepository.GetAllHeroesListAsync(cancellationToken: cancellationToken);
        return list.ToList();
    }

    public async Task<Hero?> TGetHeroByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var unit = await _unitOfWork.GetHeroReadRepository.GetHeroByIdAsync(q => q.Id == id, cancellationToken: cancellationToken);
        return unit;
    }
}
