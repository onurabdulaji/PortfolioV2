using PortfolioV2.DataTransfer.Configuration;
using PortfolioV2.Domain.Entities;

namespace PortfolioV2.DataTransfer.DTOs.HeroEntity;

public class CreateHeroDto : BaseDtoConfiguration<CreateHeroDto, Hero>
{
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public string? BackgroundImageUrl { get; set; }
}

public class CreateHeroResponseDto : BaseDtoConfiguration<CreateHeroResponseDto, Hero>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
}

