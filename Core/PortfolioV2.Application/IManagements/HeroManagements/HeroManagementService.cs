using Microsoft.Extensions.Logging;
using PortfolioV2.Domain.Entities;
using PortfolioV2.Domain.IRepositories.IUnitOfWorks;

namespace PortfolioV2.Application.IManagements.HeroManagements;

public class HeroManagementService : IHeroManagementService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<HeroManagementService> _logger;

    public HeroManagementService(IUnitOfWork unitOfWork, ILogger<HeroManagementService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task TCreateHeroAsync(Hero createHero, CancellationToken cancellationToken = default)
    {
        await _unitOfWork.GetHeroWriteRepository.AddAsync(createHero, cancellationToken);
        _logger.LogInformation("Hero created with ID: {Id}", createHero.Id);
        await _unitOfWork.SaveChangesAsync();
        _logger.LogInformation("Changes saved to the database.");
    }

    public async Task<IList<Hero>> TGetAllHeroesAsync(CancellationToken cancellationToken = default)
    {
        var list = await _unitOfWork.GetHeroReadRepository.GetAllHeroesListAsync(cancellationToken: cancellationToken);
        _logger.LogInformation("Retrieved {Count} heroes from the database.", list.Count);
        return list.ToList();
    }

    public async Task<Hero?> TGetHeroByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var unit = await _unitOfWork.GetHeroReadRepository.GetHeroByIdAsync(q => q.Id == id, cancellationToken: cancellationToken);
        _logger.LogInformation("Retrieved hero with ID: {Id}", id);
        return unit;
    }
}
