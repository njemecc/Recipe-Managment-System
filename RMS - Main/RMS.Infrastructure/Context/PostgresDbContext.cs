using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RMS.Application.Common.Interfaces;
using RMS.Domain.Entities;
using RMS.Domain.Enums;
using RMS.Infrastructure.Configuration;

namespace RMS.Infrastructure.Context;

public class PostgresDbContext(DbContextOptions<PostgresDbContext> options): IdentityDbContext<ApplicationUser,IdentityRole,string,IdentityUserClaim<string>,IdentityUserRole<string>,IdentityUserLogin<string>,IdentityRoleClaim<string>,IdentityUserToken<string>>(options),IPostgresDbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Test")
        {
           
                   
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=root;Database=RMS");
            
        }
        
 
    }
        


    public DbSet<ApplicationUser> Users => Set<ApplicationUser>();
    public DbSet<Recipe> Recipes => Set<Recipe>();
    
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();

    public DbSet<RecipeIngrediant> RecipeIngrediants => Set<RecipeIngrediant>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
    
}