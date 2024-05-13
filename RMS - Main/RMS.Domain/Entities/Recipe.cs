using RMS.Domain.Enums;

namespace RMS.Domain.Entities;

public class Recipe
{
    public Guid Id
    {
        get;
        private set;
    }
    
    public string Title { get; set; }
    
    public string Instruction { get; set; }
    
    public IList<RecipeIngrediant>? Ingrediants { get; set; } 
    
    public ApplicationUser User
    {
        get;
        private set;
    }
    

    public Recipe AddUser(ApplicationUser user)
    {
        User = user;
        return this;
    }
    
    
    public Recipe()
    {
        Id = Guid.NewGuid();

    }
    
}