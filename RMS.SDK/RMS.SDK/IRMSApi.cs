using Refit;
using RMS.SDK.Dto;

namespace RMS.SDK;

public interface IRMSApi
{
    [Post("/api/Category/Create")]
    public Task<RMSCategoryCreateResponseDto> CreateCategoryAsync(RMSCategoryCreateRequestDto request);
}