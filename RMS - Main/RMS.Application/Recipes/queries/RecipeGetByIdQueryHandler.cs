using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Dto.Recipe;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Mappers;

namespace RMS.Application.Recipes.queries;

public class RecipeGetByIdQueryHandler(IPostgresDbContext dbContext) : IRequestHandler<RecipeGetByIdQuery,IList<RecipeDetailsDto>>
{
    public async Task<IList<RecipeDetailsDto>> Handle(RecipeGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result =  await dbContext.Recipes.Include(x => x.User).Where(x => x.User.Id == request.Id.ToString()).ToListAsync();

        if (result.Count == 0)
        {
            return null;
        }

        var dtos = result.Select(recipe => recipe.ToCustomDetailsDto()).ToList();

        return dtos;
    }
}