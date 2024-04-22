using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using RMS.Application.Common.Dto.Recipe;
using RMS.Application.Common.Mappers;
using RMS.BaseTests.Builders.Domain;
using RMS.Domain.Entities;


namespace RMS.FunctionalTests.Recipes.Commands;

public class RecipeCreateCommandTests : BaseTest
{

    
    [Fact]
    public async Task RecipeCreateCommandTest_GivenValidRecipe_StatusOk()
    {
        

        //given

        var user = new UserBuilder().WithFirstName("-").WithLastName("-").WithEmail("-").WithPassword("-").Build();
        var category = new CategoryBuilder().WithName("-").Build();

        var ingredient = new IngredientBuilder().WithName("-").Build();

        var ingredientCreateDto = ingredient.FromEntityToIngredientCreateDto();
        

        await DbContext.Users.AddAsync(user);
        await DbContext.Ingredients.AddAsync(ingredient);
        await DbContext.SaveChangesAsync(new CancellationToken());

        var recipe = new RecipeBuilder().WithUser(user).WithCategory(category).WithInstruction("-").WithTitle("-").Build();
        var serializedRecipe = JsonSerializer.Serialize(recipe);
        var searializedRecipeStringContent = new StringContent(serializedRecipe, Encoding.UTF8, "application/json");

        //When

        var response = await Client.PostAsync("/api/Recipe/Create", searializedRecipeStringContent);
        
        


        //Then

        using var _ = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<RecipeDetailsDto>();

        content.Should().NotBeNull();
        content.Title.Should().Be(recipe.Title);
        content.CategoryName.Should().Be(category.Name);
        content.UserName.Should().Be(user.UserName);
        content.Instruction.Should().Be(recipe.Instruction);
        

    }


    public RecipeCreateCommandTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }
}