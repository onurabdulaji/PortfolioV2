namespace PortfolioV2.Domain.Entities;

public class Hero : BaseEntity
{
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public string? BackgroundImageUrl { get; set; }
    public Hero() : base() { }
    public Hero(string? title, string? subTitle, string? backgroundImageUrl) : base()
    {
        Title = title;
        SubTitle = subTitle;
        BackgroundImageUrl = backgroundImageUrl;
    }
}
