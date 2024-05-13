using Riok.Mapperly.Abstractions;
using RMS.Application.Common.Dto.Ingredient;
using RMS.Application.Common.Dto.Recipe;
using RMS.Domain.Entities;

namespace RMS.Application.Common.Mappers;

[Mapper]
public static partial class RecipeMapper
{

    public static RecipeCreateDto FromEntityToCreateDto(this Recipe entity)
    {
        var recipeDto = new RecipeCreateDto(entity.User.Id, entity.Title, entity.Instruction,new List<IngredientCreateDto>());
        return recipeDto;
    }
    public static partial Recipe FromCreateDtoToEntity(this RecipeCreateDto dto);

    public static RecipeDetailsDto ToCustomDetailsDto(this Recipe entity)
    {
        var recipe =
            new RecipeDetailsDto(entity.Title, entity.Instruction, entity.User.FirstName);

        return recipe;
    }

     

}