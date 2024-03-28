using Refit;
using RMSSdk.Dto;

namespace RMSSdk;

public interface IRMSApi
{
    [Post("/api/Category/Create")]
    public Task<RMSCategoryCreateResponseDto> CreateCategoryAsync(RMSCategoryCreateRequestDto request);
}