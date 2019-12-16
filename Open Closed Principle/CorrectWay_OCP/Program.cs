using System;
using System.Collections.Generic;
using System.Linq;

namespace CorrectWay_OCP
{
    //to solve this, as per context we need to implement specification pattern
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Extra_Large
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specifications);
    }

    class ColorSpecification : ISpecification<Product>
    {
        public ColorSpecification(Color color)
        {
            this._color = color;
        }
        private Color _color;
        public bool IsSatisfied(Product t)
        {
            return _color == t.Color;
        }
    }


    class SizeSpecification : ISpecification<Product>
    {
        public SizeSpecification(Size size)
        {
            this._size = size;
        }
        private Size _size;
        public bool IsSatisfied(Product t)
        {
            return _size == t.Size;
        }
    }


    class SizeAndColorSpecification : ISpecification<Product>
    {
        public SizeAndColorSpecification(Size size, Color color)
        {
            this._size = size;
            this._color = color;
        }
        private Size _size;
        private Color _color;
        public bool IsSatisfied(Product t)
        {
            return _size == t.Size && _color == t.Color;
        }
    }


    //Generic Way
    class AndSpecification<T> : ISpecification<T>
    {
        IList<ISpecification<T>> _specs;
        public AndSpecification(IList<ISpecification<T>> specs)
        {
            _specs = specs;
        }

        public bool IsSatisfied(T t)
        {
            return _specs.All(x => x.IsSatisfied(t));
        }
    }

    class ProductFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specifications)
        {
            foreach (var item in items)
            {
                if (specifications.IsSatisfied(item))
                    yield return item;
            }
        }

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
            var productFilter = new ProductFilter();
            foreach (var product in productFilter.Filter(products, new SizeSpecification(Size.Small)))
            {
                Console.WriteLine(product);
            }

            Console.WriteLine($"filter by Color {Color.Blue}");


            foreach (var product in productFilter.Filter(products, new ColorSpecification(Color.Blue)))
            {
                Console.WriteLine(product);
            }



            Console.WriteLine($"filter by Color  {Color.Blue} and Size {Size.Extra_Large}");


            foreach (var product in productFilter.Filter(products, new SizeAndColorSpecification(Size.Extra_Large, Color.Blue)))
            {
                Console.WriteLine(product);
            }




            Console.WriteLine($"Generic filter by Color  {Color.Blue} and Size {Size.Extra_Large}");


            foreach (var product in productFilter.Filter(products, new AndSpecification<Product>(
                    new List<ISpecification<Product>>
                        {
                            new ColorSpecification(Color.Blue),
                            new SizeSpecification(Size.Extra_Large)

                        })
                ))
            {
                Console.WriteLine(product);
            }


        }
    }
}
