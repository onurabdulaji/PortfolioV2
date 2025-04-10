namespace PortfolioV2.Application.Commons.FactoryDtos;

public interface IDtoFactory
{
    TEntity CreateEntityFromDto<TEntity, TDto>(TDto dto);
    TDto CreateDtoFromEntity<TEntity, TDto>(TEntity entity);
}
