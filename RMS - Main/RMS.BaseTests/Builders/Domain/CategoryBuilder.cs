using RMS.Domain.Entities;

namespace RMS.BaseTests.Builders.Domain
{
    public class CategoryBuilder
    {
        private string _name;

        public CategoryBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public Category Build()
        {
            return new Category(_name);
        }
    }
}
