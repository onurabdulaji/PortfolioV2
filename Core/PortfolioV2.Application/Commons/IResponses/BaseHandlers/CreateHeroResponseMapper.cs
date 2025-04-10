using PortfolioV2.DataTransfer.DTOs.HeroEntity;

namespace PortfolioV2.Application.Commons.IResponses.BaseHandlers;

public class CreateHeroResponseMapper : IResponseMapper<CreateHeroDto, CreateHeroResponseDto>
{
    public CreateHeroResponseDto Map(CreateHeroDto source)
    {
        var response = new CreateHeroResponseDto
        {
            Message = "Hero Created",
            Success = true,
        };

        if (source.Title == null)
        {
            response.Message = "Hero Not Created";
            response.Success = false;
            return response;
        }

        if (source.SubTitle == null)
        {
            response.Message = "Hero Not Created";
            response.Success = false;
            return response;
        }

        if (source.BackgroundImageUrl == null)
        {
            response.Message = "Hero Not Created";
            response.Success = false;
            return response;
        }

        return response;

    }
}
