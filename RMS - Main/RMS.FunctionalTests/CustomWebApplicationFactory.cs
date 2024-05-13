using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using RMS.Application.Common.Interfaces;
using RMS.Infrastructure.Context;

namespace RMS.FunctionalTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
 //   public Mock<IRecipeService> MockRecipeService { get; } = new();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll<DbContext>();

            var dbName = Guid.NewGuid()
                .ToString();

            services.AddDbContext<PostgresDbContext>(options =>
            {
                options.UseInMemoryDatabase(dbName);
            });
            
          //  services.AddScoped(_ => MockRecipeService.Object);
        });
    }



}