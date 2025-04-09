using PortfolioV2.DataTransfer.Configuration;
using PortfolioV2.Domain.Entities;

namespace PortfolioV2.DataTransfer.DTOs.HeroEntity;

public class GetAllHeroDto : BaseDtoConfiguration<GetAllHeroDto, Hero>
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public string? BackgroundImageUrl { get; set; }
}

