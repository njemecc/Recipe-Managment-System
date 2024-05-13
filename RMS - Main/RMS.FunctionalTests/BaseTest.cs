using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using RMS.Application.Common.Interfaces;
using RMS.Infrastructure.Context;

namespace RMS.FunctionalTests;

public class BaseTest : IClassFixture<CustomWebApplicationFactory<Program>>
{

    private readonly CustomWebApplicationFactory<Program> _factory;
    public readonly HttpClient Client;
    public readonly PostgresDbContext PostgresDbContext ;
    public readonly Mock<IRecipeService> MockRecipeService;


    public BaseTest(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = factory.CreateClient();
        var scope = factory.Services.CreateScope();
        PostgresDbContext = scope.ServiceProvider.GetRequiredService<PostgresDbContext>();
        //MockRecipeService = factory.MockRecipeService;
    }
    
}