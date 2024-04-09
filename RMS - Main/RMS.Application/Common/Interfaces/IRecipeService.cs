using Microsoft.AspNetCore.Http.HttpResults;
using RMS.Application.Common.Dto.Recipe;

namespace RMS.Application.Common.Interfaces;

public interface IRecipeService
{
  Task<RecipeDetailsDto> Created(RecipeCreateDto recipe);
}