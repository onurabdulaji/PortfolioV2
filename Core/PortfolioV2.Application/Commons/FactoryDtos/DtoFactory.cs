using Mapster;

namespace PortfolioV2.Application.Commons.FactoryDtos;

public class DtoFactory : IDtoFactory
{
    public TDto CreateDtoFromEntity<TEntity, TDto>(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null");

        return entity.Adapt<TDto>();
    }

    public TEntity CreateEntityFromDto<TEntity, TDto>(TDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto), "DTO cannot be null");

        return dto.Adapt<TEntity>();
    }
}
