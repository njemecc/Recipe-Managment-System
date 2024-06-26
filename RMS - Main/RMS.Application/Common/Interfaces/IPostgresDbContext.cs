﻿using Microsoft.EntityFrameworkCore;
using RMS.Domain.Entities;
using RMS.Domain.Enums;

namespace RMS.Application.Common.Interfaces;

public interface IPostgresDbContext
{
    
    public DbSet<ApplicationUser> Users { get; }
    public DbSet<Recipe> Recipes { get; }
    
    
    public DbSet<Ingredient> Ingredients { get; }
    
    
    public DbSet<RecipeIngrediant> RecipeIngrediants { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}