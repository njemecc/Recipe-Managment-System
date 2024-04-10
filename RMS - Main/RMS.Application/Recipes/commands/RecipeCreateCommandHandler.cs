using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Dto.Recipe;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Mappers;
using RMS.Domain.Entities;

namespace RMS.Application.Recipes.commands;

public class RecipeCreateCommandHandler(IRecipeService recipeService) : IRequestHandler<RecipeCreateCommand,RecipeDetailsDto>
{
    public async Task<RecipeDetailsDto> Handle(RecipeCreateCommand request, CancellationToken cancellationToken)
    {

        var result = await recipeService.CreateRecipeAsync(request.Recipe);

        return result;

    }
}