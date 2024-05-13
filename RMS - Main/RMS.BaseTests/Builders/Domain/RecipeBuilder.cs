using RMS.Domain.Entities;
using RMS.Domain.Enums;

namespace RMS.BaseTests.Builders.Domain


{
    public class RecipeBuilder
    {
        private string _title;
        private string _instruction;
        private IList<RecipeIngrediant> _ingredients = new List<RecipeIngrediant>();
        private ApplicationUser _user;
      
        public RecipeBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public RecipeBuilder WithInstruction(string instruction)
        {
            _instruction = instruction;
            return this;
        }
        public RecipeBuilder WithIngredients(IList<RecipeIngrediant> ingredients)
        {
            _ingredients = ingredients;
            return this;
        }

        public RecipeBuilder WithUser(ApplicationUser user)
        {
            _user = user;
            return this;
        }

        public Recipe Build()
        {
            var recipe = new Recipe();
            recipe.Title = _title;
            recipe.Instruction = _instruction;
            recipe.Ingrediants = _ingredients;
            recipe.AddUser(_user);
            
            return recipe;
        }
    }
}
