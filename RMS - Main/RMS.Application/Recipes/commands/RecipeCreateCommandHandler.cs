using MediatR;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Dto.Recipe;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Mappers;
using RMS.Domain.Entities;

namespace RMS.Application.Recipes.commands;

public class RecipeCreateCommandHandler(IPostgresDbContext dbContext) : IRequestHandler<RecipeCreateCommand,RecipeDetailsDto>
{
    public async Task<RecipeDetailsDto> Handle(RecipeCreateCommand request, CancellationToken cancellationToken)
    {


        var user = await dbContext.Users.Where(x => x.Id == request.Recipe.UserId).FirstOrDefaultAsync(cancellationToken);

        var category = await dbContext.Categories.Where(x => x.Id == request.Recipe.CategoryId)
            .FirstOrDefaultAsync(cancellationToken);
        
        if (user == null || category == null )
        {
            throw new Exception("User or Category with this ID does not exists");
        }
        
        var recipeEntity = request.Recipe.FromCreateDtoToEntity().AddUser(user).AddCategory(category);

        foreach (var ing in request.Recipe.Ingredients)
        {
           var ingrediantEntity = ing.FromCreateIngredientDtoToEntity();
               
            dbContext.Ingredients.Add(ing.FromCreateIngredientDtoToEntity());

           var recipeIngredient = new RecipeIngrediant
           {
               Recipe = recipeEntity,
               Ingredient = ingrediantEntity
           };

           dbContext.RecipeIngrediants.Add(recipeIngredient);

        }
        
        var result = dbContext.Recipes.Add(recipeEntity);

        await dbContext.SaveChangesAsync(cancellationToken);

        //pokusati i ToDto(); ovde da vidimo da li automatski mapira 
        return recipeEntity.ToCustomDetailsDto();
    }
}