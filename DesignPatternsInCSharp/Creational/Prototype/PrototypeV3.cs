using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Creational.Prototype
{
    /// <summary>
    /// The Prototype abstract class
    /// </summary>
    public abstract class SandwichPrototype
    {
        public abstract SandwichPrototype Clone();
    }

    public class Sandwich : SandwichPrototype
    {
        private string Bread;
        private string Meat;
        private string Cheese;
        private string Veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            Bread = bread;
            Meat = meat;
            Cheese = cheese;
            Veggies = veggies;
        }

        public override SandwichPrototype Clone()
        {
            string ingredientList = GetIngredientList();
            Console.WriteLine("Cloning sandwich with ingredients: {0}", ingredientList.Remove(ingredientList.LastIndexOf(",")));

            return MemberwiseClone() as SandwichPrototype;
        }

        private string  GetIngredientList()
        {
            return null;
        }
    }

    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> _sandwiches
            = new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name]
        {
            get { return _sandwiches[name]; }
            set { _sandwiches.Add(name, value); }
        }
    }
}
