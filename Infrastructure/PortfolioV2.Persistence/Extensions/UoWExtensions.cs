using Microsoft.Extensions.DependencyInjection;
using PortfolioV2.Domain.IRepositories.IUnitOfWorks;
using PortfolioV2.Persistence.Repositories.UnitOfWorks;

namespace PortfolioV2.Persistence.Extensions;

public static class UoWExtensions
{
    public static void AddUnitOfWorkExtension(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}

