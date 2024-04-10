namespace RMS.Domain.Entities;

public class Category
{
    
    public Guid Id
    {
        get;
        private set;
    }
    
    public string Name { get; set; }
    
    public IList<Recipe> Recipes { get; set; } = new List<Recipe>();

    public Category(string name)
    {
        Id = Guid.NewGuid();
        this.Name = name;
    }
}