using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RMS.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Infrastructure.Context;
using RMS.Infrastructure.services;

namespace RMS.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConfiguration = new PostgresDbConfiguration();
        
        configuration.GetSection("PostgresDbConfiguration").Bind(dbConfiguration);

        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Test")
        {
            services.AddDbContext<PostgresDbContext>(options => options.UseNpgsql(dbConfiguration.ConnectionString,
                x => x.MigrationsAssembly(typeof(PostgresDbContext).Assembly.FullName)));    
        }

       

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IPostgresDbContext>(provider => provider.GetRequiredService<PostgresDbContext>());
        services.AddScoped<IRecipeService, RecipeService>();
        return services;
    }
    
}