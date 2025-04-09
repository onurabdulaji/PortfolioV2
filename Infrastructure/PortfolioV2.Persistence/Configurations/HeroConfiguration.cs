using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioV2.Domain.Entities;

namespace PortfolioV2.Persistence.Configurations;

public class HeroConfiguration : BaseConfiguration<Hero>
{
    public override void Configure(EntityTypeBuilder<Hero> builder)
    {
        base.Configure(builder);
    }
}
