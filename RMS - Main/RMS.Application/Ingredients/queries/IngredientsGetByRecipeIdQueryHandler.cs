using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Dto.Ingredient;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Mappers;

namespace RMS.Application.Ingredients.queries;

public class IngredientsGetByRecipeIdQueryHandler(IPostgresDbContext dbContext) : IRequestHandler<IngredientsGetByRecipeIdQuery,IList<IngredientCreateDto>>
{
    public async Task<IList<IngredientCreateDto>> Handle(IngredientsGetByRecipeIdQuery request, CancellationToken cancellationToken)
    {
      var Ingredients = await dbContext.RecipeIngrediants.Where(x => x.RecipeId.ToString() == request.RecipeId).Select(ri => ri.Ingredient).ToListAsync(cancellationToken);

      await dbContext.SaveChangesAsync(cancellationToken);

      return Ingredients.Select(x => x.FromEntityToIngredientCreateDto()).ToList();
      
    }
    }