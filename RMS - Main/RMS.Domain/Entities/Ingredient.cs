namespace RMS.Domain.Entities;

public class Ingredient
{
    public Guid Id
    {
        get;
        private set;
    }
    public string Name { get; set; }

    public Ingredient(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
        
    }
    
    public IList<RecipeIngrediant> Receipts { get; set; }
}