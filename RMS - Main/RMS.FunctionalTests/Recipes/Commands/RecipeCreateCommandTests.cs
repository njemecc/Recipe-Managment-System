using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using RMS.Application.Common.Dto.Recipe;
using RMS.Application.Common.Mappers;
using RMS.BaseTests.Builders.Commands;
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
        
        
        await PostgresDbContext.Users.AddAsync(user);
        await PostgresDbContext.SaveChangesAsync(new CancellationToken());

        var recipe = new RecipeBuilder().WithUser(user).WithInstruction("-").WithTitle("-").Build();
        var createRecipeDto = recipe.FromEntityToCreateDto();
        var recipeCreateCommand = new RecipeCreateCommandBuilder().WithRecipeCreateDto(createRecipeDto).Build();
       
        var serializedRecipe = JsonSerializer.Serialize(recipeCreateCommand);
        var searializedRecipeStringContent = new StringContent(serializedRecipe, Encoding.UTF8, "application/json");

        //When

        var response = await Client.PostAsync("/api/Recipe/Create", searializedRecipeStringContent,new CancellationToken());
        
        //Then

        using var _ = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<RecipeDetailsDto>();

        content.Should().NotBeNull();
        content.Title.Should().Be(recipe.Title);
        content.UserName.Should().Be(user.UserName);
        content.Instruction.Should().Be(recipe.Instruction);
        

    }


    public RecipeCreateCommandTests(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }
}