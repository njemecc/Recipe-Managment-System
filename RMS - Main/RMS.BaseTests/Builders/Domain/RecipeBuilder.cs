using RMS.Domain.Entities;

namespace RMS.BaseTests.Builders.Domain


{
    public class RecipeBuilder
    {
        private string _title;
        private string _instruction;
        private Category _category;
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

        public RecipeBuilder WithCategory(Category category)
        {
            _category = category;
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
            recipe.Category = _category;
            recipe.Ingrediants = _ingredients;
            recipe.AddUser(_user);
            return recipe;
        }
    }
}
