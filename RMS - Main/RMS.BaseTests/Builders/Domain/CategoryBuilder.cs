using RMS.Domain.Entities;
using RMS.Domain.Enums;

namespace RMS.BaseTests.Builders.Domain
{
    public class CategoryBuilder
    {
        private string _name;
        private int _value;

        public CategoryBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CategoryBuilder WithValue(int value)
        {
            _value = value;
            return this;
        }

        public Category Build()
        {
            return new Category(_name, _value);
        }
    }
}
