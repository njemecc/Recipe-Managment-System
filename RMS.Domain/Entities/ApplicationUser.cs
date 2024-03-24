using Microsoft.AspNetCore.Identity;

namespace RMS.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    
    public Guid Id
    {
        get;
        private set;
    }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public string? Email { get; set; }
    
    public string? Password { get; set; }
    
    public IList<IdentityRole> Roles { get; } = new List<IdentityRole>();

    public IList<Recipe> Recipes { get; set; } = new List<Recipe>();


}