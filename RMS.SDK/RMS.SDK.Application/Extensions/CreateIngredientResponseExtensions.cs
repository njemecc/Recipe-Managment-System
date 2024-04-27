using RMS.SDK.Api.Dto.Ingredient;
using RMS.SDK.Models;

namespace RMS.SDK.Extensions;

public static class CreateIngredientResponseExtensions
{
    public static IngredientCreateResponseModel ToModel(this IngredientCreateResponseDto dto)
    {
        return new IngredientCreateResponseModel(dto.Ingredient);
    }
}