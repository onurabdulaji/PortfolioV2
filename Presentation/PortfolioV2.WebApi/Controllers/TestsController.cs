using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortfolioV2.Application.Features.VerticalSlice.HeroSlice;
using PortfolioV2.DataTransfer.DTOs.HeroEntity;
using Swashbuckle.AspNetCore.Annotations;

namespace PortfolioV2.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TestsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    

    [HttpPost("CreateHeroTest")]
    [SwaggerOperation
        (
            Summary = "Create a new hero test",
            Description = "This endpoint creates a new hero test using the provided CreateHeroDto.",
            OperationId = "CreateHeroTest",
            Tags = new[] { "Tests" }
        )]
    [SwaggerResponse(StatusCodes.Status201Created, "Hero test created successfully.", typeof(CreateHeroResponseDto))]
    [SwaggerResponse(StatusCodes.Status200OK, "Hero test created successfully and Return Of ResponseDTO.", typeof(CreateHeroResponseDto))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data.")] // Fluent Validation
    public async Task<IActionResult> CreateHeroTest([FromBody] CreateHeroDto createHeroDto, CancellationToken cancellationToken = default)
    {
        var command = new CreateHeroHandler.CreateHeroCommand(createHeroDto);
        var response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}
