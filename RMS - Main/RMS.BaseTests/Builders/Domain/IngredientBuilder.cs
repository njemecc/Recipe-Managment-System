using RMS.Domain.Entities;

namespace RMS.BaseTests.Builders.Domain;

public  class IngredientBuilder

{
    private string _name;

    public IngredientBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
    
    public Ingredient Build()
    {
        return new Ingredient(_name);
    }

   
}