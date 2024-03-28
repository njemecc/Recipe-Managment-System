using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMS.Domain.Entities;

namespace RMS.Infrastructure.Domain.Identity;

public class ApplicationUserConfiguration :IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users");

        builder.HasMany(x => x.Roles).WithOne().HasForeignKey(x => x.Id).IsRequired().OnDelete(DeleteBehavior.Cascade);
        
    }
}