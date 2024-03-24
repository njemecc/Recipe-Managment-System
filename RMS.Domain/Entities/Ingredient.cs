namespace RMS.Domain.Entities;

public class Ingredient
{
    public Guid Id
    {
        get;
        private set;
    }
    public string Name { get; set; }
    
    public IList<RecipeIngrediant> RecipeIngredients { get; set; }
}