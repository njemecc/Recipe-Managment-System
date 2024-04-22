using RMS.SDK.Api.Dto.Ingredient;

namespace RMS.SDK.Extensions;

public static class CreateIngredientResponseExtensions
{
    public static IngredientCreateResponseModel ToModel(this IngredientCreateResponseDto dto)
    {
        return new IngredientCreateResponseModel(dto.Name);
    }
}