using RMS.Application.Common.Dto.Ingredient;
using RMS.Domain.Entities;

namespace RMS.Application.Common.Dto.Recipe;

public record RecipeCreateDto(string UserId, string Title, string Instruction,IList<IngredientCreateDto>? Ingredients);