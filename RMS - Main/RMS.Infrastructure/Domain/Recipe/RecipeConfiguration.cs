using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMS.Domain.Entities;
using RMS.Domain.Enums;

namespace RMS.Infrastructure.Domain.Recipe;

public class RecipeConfiguration : IEntityTypeConfiguration<RMS.Domain.Entities.Recipe>
{
    public void Configure(EntityTypeBuilder<RMS.Domain.Entities.Recipe> builder)
    {
        builder.ToTable("Recipes");

        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property<string>("UserId");

        builder.HasIndex("UserId");
        
        builder.HasOne(r => r.User).WithMany(u => u.Recipes).HasForeignKey("UserId").IsRequired();
        builder.Property(r => r.Category)
            .IsRequired().HasDefaultValue(Category.CookedMeal)
            .HasConversion(
                c => c.Value, 
                v => Category.FromValue(v)); 

    }
}