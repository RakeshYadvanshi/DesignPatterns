using System;
using System.Collections.Generic;

namespace Issue_OCP
{

    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Extra_Large
    }

    public class Product
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public Product(string name, Color color, Size size)
        {
            if (name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            Name = name;
            Color = color;
            Size = size;
        }


        public override string ToString()
        {
            return $"{Name} has color {Color} and has size {Size}";
        }
    }

    /// <summary>
    ///  this class break open close principle so as for every type of filter we introduce in product,
    ///  we need to modify this class
    /// </summary>
    public class ProductFilter
    {
        public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var product in products)
            {
                if (product.Size == size)
                {
                    yield return product;
                }
            }

        }

        public static IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var product in products)
            {
                if (product.Color == color)
                {
                    yield return product;
                }
            }

        }

        public static IEnumerable<Product> FilterByColorAndSize(IEnumerable<Product> products, Color color, Size size)
        {
            foreach (var product in products)
            {
                if (product.Color == color && product.Size == size)
                {
                    yield return product;
                }
            }

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var house = new Product("House", Color.Blue, Size.Extra_Large);
            var doll = new Product("Doll", Color.Red, Size.Small);
            var cup = new Product("Cup", Color.Green, Size.Medium);

            List<Product> products = new List<Product>
            {
                house,doll,cup
            };
            Console.WriteLine($"filter by Size {Size.Small}");
            foreach (var product in ProductFilter.FilterBySize(products, Size.Small))
            {
                Console.WriteLine(product);
            }


            Console.WriteLine($"filter by Color {Color.Blue}");
            foreach (var product in ProductFilter.FilterByColor(products, Color.Blue))
            {
                Console.WriteLine(product);
            }
        }
    }
}
