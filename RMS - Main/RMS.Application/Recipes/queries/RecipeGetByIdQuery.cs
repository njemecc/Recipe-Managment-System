using MediatR;
using RMS.Application.Common.Dto.Recipe;

namespace RMS.Application.Recipes.queries;

public record RecipeGetByIdQuery(Guid Id) :IRequest<IList<RecipeDetailsDto>>;