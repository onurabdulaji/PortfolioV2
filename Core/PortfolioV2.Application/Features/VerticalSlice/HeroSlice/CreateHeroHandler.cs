using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CreateHeroCommandHandler> _logger;

        public CreateHeroCommandHandler(IHeroService heroService, ILogger<CreateHeroCommandHandler> logger)
        {
            _heroService = heroService;
            _logger = logger;
        }

        public async Task<CreateHeroResponseDto> Handle(CreateHeroCommand request, CancellationToken cancellationToken)
        {
            await _heroService.CreateHeroAsync(request.CreateHeroDto, cancellationToken);
            _logger.LogInformation("Hero created successfully with title: {Title}", request.CreateHeroDto.Title);
            return ResponseMapper.Map(request.CreateHeroDto);
        }
    }
    internal sealed class ResponseMapper
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
////}



//internal sealed class   ✅	Sadece aynı projeden erişilir, miras alınamaz
//protected sealed class  ❌	Derleme hatası
//protected sealed override void	✅	Miras alınan metodu bir daha override edilemez hale getir