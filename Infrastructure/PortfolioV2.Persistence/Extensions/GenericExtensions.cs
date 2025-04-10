using Microsoft.Extensions.DependencyInjection;
using PortfolioV2.Domain.IRepositories.IGenerics;
using PortfolioV2.Persistence.Repositories.Generics;

namespace PortfolioV2.Persistence.Extensions;

public static class GenericExtensions
{
    public static void AddGenericPatternExtension(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericReadRepository<>), typeof(GenericReadRepository<>));
        services.AddScoped(typeof(IGenericWriteRepository<>), typeof(GenericWriteRepository<>));
    }
}
