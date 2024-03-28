using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMS.Domain.Entities;

namespace RMS.Infrastructure.Domain.RecipeIngredient;

public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngrediant>
{
    public void Configure(EntityTypeBuilder<RecipeIngrediant> builder)
    {
        builder.HasKey(ri => new { ri.RecipeId, ri.IngredientId });

        builder.HasOne(ri => ri.Recipe).WithMany(r => r.Ingrediants).HasForeignKey(ri => ri.RecipeId);
        
        builder.HasOne(ri => ri.Ingredient)
            .WithMany(i => i.Receipts)
            .HasForeignKey(ri => ri.IngredientId);
    }
}