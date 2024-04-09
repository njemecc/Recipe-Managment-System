using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Dto.Recipe;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Mappers;
using RMS.Application.Recipes.commands;
using RMS.Domain.Entities;

namespace RMS.Infrastructure.services;

public class RecipeService(IPostgresDbContext dbContext) : IRecipeService
{
    public async Task<RecipeDetailsDto> Created(RecipeCreateDto recipe)
    {
        var user = await dbContext.Users.Where(x => x.Id == recipe.UserId).FirstOrDefaultAsync();

        var category = await dbContext.Categories.Where(x => x.Id == recipe.CategoryId)
            .FirstOrDefaultAsync();
        
        if (user == null || category == null )
        {
            throw new Exception("User or Category with this ID does not exists");
        }
        
        var recipeEntity = recipe.FromCreateDtoToEntity().AddUser(user).AddCategory(category);

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
        
        var result = dbContext.Recipes.Add(recipeEntity);

        await dbContext.SaveChangesAsync(CancellationToken.None);

        //pokusati i ToDto(); ovde da vidimo da li automatski mapira 
        return recipeEntity.ToCustomDetailsDto();
    }
}