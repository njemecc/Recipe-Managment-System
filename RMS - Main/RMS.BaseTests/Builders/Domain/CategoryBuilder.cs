using RMS.Domain.Entities;
using RMS.Domain.Enums;

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
            return new Category("-", new Random().Next());
        }
    }
}
