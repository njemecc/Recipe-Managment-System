using RMS.SDK.Dto;

namespace RMS.SDK.Application.Models;

public record RmsCategoryCreateRequestModel(string Name)
{
    public RMSCategoryCreateRequestDto ToDto()
    {
        return new RMSCategoryCreateRequestDto(new RMSCategoryCreateDto(Name));
    }
}