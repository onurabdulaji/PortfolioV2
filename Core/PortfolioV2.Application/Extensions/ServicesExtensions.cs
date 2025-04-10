using Microsoft.Extensions.DependencyInjection;
using PortfolioV2.Application.Commons.FactoryDtos;
using PortfolioV2.Application.Commons.FactoryDtos.HeroDtoFactories;
using PortfolioV2.Application.IManagements.HeroManagements;
using PortfolioV2.Application.IServices.HeroService;

namespace PortfolioV2.Application.Extensions;

public static class ServicesExtensions
{
    public static void AddServicesExtension(this IServiceCollection services)
    {
        services.AddScoped<IDtoFactory, DtoFactory>();
        services.AddScoped<IHeroDtoFactory, HeroDtoFactory>();

        services.AddScoped<IHeroManagementService,HeroManagementService>();

        services.AddScoped<IHeroService, HeroService>();
    }
}
