using RMS.SDK.Application.Models;
using RMS.SDK.Dto;

namespace RMS.SDK.Application.Extensions;

public static class RmsCreateCategoryResponseExtensions
{
    public static RmsCategoryCreateResponseModel ToModel(this RmsCategoryCreateResponseDto dto)
    {
        return new RmsCategoryCreateResponseModel(dto.Name);
    }
}