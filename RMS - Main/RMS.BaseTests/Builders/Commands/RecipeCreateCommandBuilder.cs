using RMS.Application.Common.Dto.Recipe;
using RMS.Application.Common.Mappers;
using RMS.Application.Recipes.commands;
using RMS.BaseTests.Builders.Domain;

namespace RMS.BaseTests.Builders.Commands;

public class RecipeCreateCommandBuilder
{
    private RecipeCreateDto _recipeCreateDto;

    public RecipeCreateCommand Build() => new(_recipeCreateDto);

    public RecipeCreateCommandBuilder WithRecipeCreateDto(RecipeCreateDto recipeCreateDto)
    {
        _recipeCreateDto = recipeCreateDto;
        return this;
    }
}