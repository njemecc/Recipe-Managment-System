using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMS.Domain.Entities;

namespace RMS.Infrastructure.Domain.Recipe;

public class RecipeConfiguration : IEntityTypeConfiguration<RMS.Domain.Entities.Recipe>
{
    public void Configure(EntityTypeBuilder<RMS.Domain.Entities.Recipe> builder)
    {
        builder.ToTable("Recipes");

        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property<string>("UserId");
        builder.Property<Guid>("CategoryId");

        builder.HasIndex("UserId");
        builder.HasIndex("CategoryId");
        
        builder.HasOne(r => r.User).WithMany(u => u.Recipes).HasForeignKey("UserId").IsRequired();
        builder.HasOne(r => r.Category).WithMany(c => c.Recipes).HasForeignKey("CategoryId").IsRequired();

    }
}