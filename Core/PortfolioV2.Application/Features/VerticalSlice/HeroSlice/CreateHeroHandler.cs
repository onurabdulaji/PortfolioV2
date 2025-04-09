using Mapster;
using MediatR;
using PortfolioV2.Application.IServices.HeroService;
using PortfolioV2.DataTransfer.DTOs.HeroEntity;

namespace PortfolioV2.Application.Features.VerticalSlice.HeroSlice;

public class CreateHeroHandler
{
    public record CreateHeroCommand : IRequest<CreateHeroResponseDto>
    {
        public CreateHeroDto CreateHeroDto { get; set; }

        public CreateHeroCommand(CreateHeroDto createHeroDto)
        {
            CreateHeroDto = createHeroDto;
        }
    }

    public class CreateHeroCommandHandler : IRequestHandler<CreateHeroCommand, CreateHeroResponseDto>
    {
        private readonly IHeroService _heroService;

        public CreateHeroCommandHandler(IHeroService heroService)
        {
            _heroService = heroService;
        }

        public async Task<CreateHeroResponseDto> Handle(CreateHeroCommand request, CancellationToken cancellationToken)
        {
            await _heroService.CreateHeroAsync(request.CreateHeroDto, cancellationToken);

            return ResponseMapper.Map(request.CreateHeroDto);
        }
    }
    protected class ResponseMapper
    {
        public static CreateHeroResponseDto Map(CreateHeroDto dto)
        {
            return dto.Adapt<CreateHeroResponseDto>();
        }
    }
}

//public interface ICreateHeroMapper
//{
//    CreateHeroResponseDto Map(CreateHeroDto dto);
//}

//public class CreateHeroMapper : ICreateHeroMapper
//{
//    public CreateHeroResponseDto Map(CreateHeroDto dto)
//    {
//        return dto.Adapt<CreateHeroResponseDto>();
//    }
//}