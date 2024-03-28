using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Dto.Ingredient;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Mappers;

namespace RMS.Application.Ingredients.queries;

public class IngredientsGetByRecipeIdCommandHandler(IPostgresDbContext dbContext) : IRequestHandler<IngredientsGetByRecipeIdCommand,IList<IngredientCreateDto>>
{
    public async Task<IList<IngredientCreateDto>> Handle(IngredientsGetByRecipeIdCommand request, CancellationToken cancellationToken)
    {
      var Ingredients = await dbContext.RecipeIngrediants.Where(x => x.RecipeId.ToString() == request.RecipeId).Select(ri => ri.Ingredient).ToListAsync(cancellationToken);

      await dbContext.SaveChangesAsync(cancellationToken);

      return Ingredients.Select(x => x.FromEntityToIngredientCreateDto()).ToList();
      
    }
    }