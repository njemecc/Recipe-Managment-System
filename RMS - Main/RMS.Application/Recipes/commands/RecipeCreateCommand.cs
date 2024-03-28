using MediatR;
using RMS.Application.Common.Dto.Recipe;

namespace RMS.Application.Recipes.commands;

public record RecipeCreateCommand(RecipeCreateDto Recipe) : IRequest<RecipeDetailsDto>;