using Mapster;

namespace PortfolioV2.DataTransfer.Configuration;

public class BaseDtoConfiguration<TDto , TEntity> : IRegister
    where TDto : class , new()
    where TEntity : class, new()
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TDto, TEntity>().TwoWays();
    }
}
