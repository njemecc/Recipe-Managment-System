using RMS.Application.Common.Dto.Ingredient;
using RMS.Domain.Entities;

namespace RMS.Application.Common.Dto.Recipe;

public record RecipeCreateDto(string UserId,Domain.Enums.Category Category, string Title, string Instruction,IList<IngredientCreateDto>? Ingredients);