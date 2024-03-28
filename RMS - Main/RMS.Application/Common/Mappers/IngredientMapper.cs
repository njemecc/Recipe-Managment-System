using Riok.Mapperly.Abstractions;
using RMS.Application.Common.Dto.Ingredient;
using RMS.Application.Common.Dto.Recipe;
using RMS.Domain.Entities;

namespace RMS.Application.Common.Mappers;

[Mapper]
public static partial class IngredientMapper
{
    public static partial Ingredient FromCreateIngredientDtoToEntity(this IngredientCreateDto dto);

    public static partial IngredientCreateDto FromEntityToIngredientCreateDto(this Ingredient entity);
}