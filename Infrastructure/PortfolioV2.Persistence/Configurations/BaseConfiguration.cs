using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioV2.Domain.Entities.IBase;

namespace PortfolioV2.Persistence.Configurations;

public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IBaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(prop => prop.CreatedDate)
             .IsRequired();
    }
}
