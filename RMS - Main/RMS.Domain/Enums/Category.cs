using Ardalis.SmartEnum;

namespace RMS.Domain.Enums
{
    public class Category : SmartEnum<Category, int>
    {
        public static readonly Category CookedMeal = new CookedMealCategory();
        public static readonly Category Grill = new GrillCategory();

        
        public Category(string name, int value) : base(name, value)
        {
        }

        public sealed class GrillCategory : Category
        {
            public GrillCategory() : base(nameof(Grill), 2)
            {
            }
        }

        public sealed class CookedMealCategory : Category
        {
            public CookedMealCategory() : base(nameof(CookedMeal), 1)
            {
            }
        }
    }
}