using RMS.SDK.Api.Dto.Ingredient;

namespace RMS.SDK.Models;

public class IngredientCreateRequestModel(string Name)
{
    public IngredientCreateRequestDto ToDto()
    {
        return new IngredientCreateRequestDto(new IngredientCreateDto(Name));
    }
}