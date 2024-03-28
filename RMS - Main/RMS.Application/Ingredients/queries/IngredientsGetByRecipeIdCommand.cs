using MediatR;
using RMS.Application.Common.Dto.Ingredient;

namespace RMS.Application.Ingredients.queries;

public record IngredientsGetByRecipeIdCommand(string RecipeId) : IRequest<IList<IngredientCreateDto>>;