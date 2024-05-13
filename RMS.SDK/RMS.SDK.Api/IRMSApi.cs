using Refit;
using RMS.SDK.Api.Dto.Ingredient;
using RMS.SDK.Dto;

namespace RMS.SDK;

public interface IRMSApi
{
    [Post("/api/Category/Create")]
    public Task<RmsCategoryCreateResponseDto> CreateCategoryAsync(RMSCategoryCreateRequestDto request);
    
    
    [Post("/webhook/IngredientCreationWebHook/Create")]
    public Task<IngredientCreateResponseDto> CreateIngredientAsync(IngredientCreateRequestDto request);
}