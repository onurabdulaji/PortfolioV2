using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using PortfolioV2.Application.Commons.IResponses.BaseHandlers;
using PortfolioV2.Application.IServices.HeroService;
using PortfolioV2.DataTransfer.DTOs.HeroEntity;

namespace PortfolioV2.Application.Features.VerticalSlice.HeroSlice;

public class CreateHeroHandler
{
    public class CreateHeroCommand(CreateHeroDto createHeroDto) : IRequest<CreateHeroResponseDto>
    {
        public CreateHeroDto CreateHeroDto { get; set; } = createHeroDto;
    }

    public class CreateHeroCommandHandler : IRequestHandler<CreateHeroCommand, CreateHeroResponseDto>
    {
        private readonly IHeroService _heroService;
        private readonly ILogger<CreateHeroCommandHandler> _logger;
        private readonly IResponseMapper<CreateHeroDto,CreateHeroResponseDto> _responseMapper;

        public CreateHeroCommandHandler(IHeroService heroService, ILogger<CreateHeroCommandHandler> logger, IResponseMapper<CreateHeroDto, CreateHeroResponseDto> responseMapper)
        {
            _heroService = heroService;
            _logger = logger;
            _responseMapper = responseMapper;
        }

        public async Task<CreateHeroResponseDto> Handle(CreateHeroCommand request, CancellationToken cancellationToken)
        {
            await _heroService.CreateHeroAsync(request.CreateHeroDto, cancellationToken);
            _logger.LogInformation("Hero created successfully with title: {Title}", request.CreateHeroDto.Title);
            return _responseMapper.Map(request.CreateHeroDto);
        }
    }
}
