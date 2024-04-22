using Refit;
using RMS.SDK.Api.Dto.Ingredient;
using RMS.SDK.Dto;

namespace RMS.SDK;

public interface IRMSApi
{
    [Post("/api/Category/Create")]
    public Task<RmsCategoryCreateResponseDto> CreateCategoryAsync(RMSCategoryCreateRequestDto request);
    
    
    [Post("/api/Ingredient/Create")]
    public Task<IngredientCreateResponseDto> CreateIngredientAsync(IngredientCreateDto request);
}