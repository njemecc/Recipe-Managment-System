using System.Data;
using FluentValidation;

namespace RMS.Application.Ingredients.queries;

public class IngredientGetByRecipeIdQueryValidator : AbstractValidator<IngredientsGetByRecipeIdQuery>
{
    public  IngredientGetByRecipeIdQueryValidator()
    {
        RuleFor(i => i.RecipeId).NotEmpty().WithMessage("RecipeId is required");
    }
}