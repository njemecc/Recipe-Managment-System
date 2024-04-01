using Refit;
using RMS.SDK.Dto;

namespace RMS.SDK;

public interface IRMSApi
{
    [Post("/api/Category/Create")]
    public Task<RmsCategoryCreateResponseDto> CreateCategoryAsync(RMSCategoryCreateRequestDto request);
}