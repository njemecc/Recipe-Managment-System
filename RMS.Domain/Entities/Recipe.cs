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
    
    public Category Category { get; set; }
    
    public IList<RecipeIngrediant> RecipeIngrediants { get; set; } 
    
    public ApplicationUser User
    {
        get;
        private set;
    }
    
    
    
}