using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Dto.Recipe;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Mappers;
using RMS.Application.Recipes.commands;
using RMS.Domain.Entities;
using RMS.Domain.Enums;

namespace RMS.Infrastructure.services;

public class RecipeService(IPostgresDbContext dbContext) : IRecipeService
{
    public async Task<RecipeDetailsDto> CreateRecipeAsync(RecipeCreateDto recipe)
    {
        var user = await dbContext.Users.Where(x => x.Id == recipe.UserId).FirstOrDefaultAsync();

       
        
        if (user == null )
        {
            throw new Exception("User with this ID does not exists");
        }

        var recipeEntity = recipe.FromCreateDtoToEntity().AddUser(user);


        if (recipe.Ingredients != null && recipe.Ingredients.Count > 0)
        {
            foreach (var ing in recipe.Ingredients)
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
        }
       
        
         await dbContext.Recipes.AddAsync(recipeEntity);

        await dbContext.SaveChangesAsync(CancellationToken.None);
        
        return recipeEntity.ToCustomDetailsDto();
    }
}