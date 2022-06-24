using System;

namespace DesignPrinciples
{
    /// <summary>
    /// Open/Closed Principle
    /// Every software module, classes, methods, function etc. are open for extension, but closed for modification.
    /// </summary>
    public class OpenClose
    {
        public class OpenCloseBad
        {
            public class Rectangle
            {
                public double Height { get; set; }
                public double Width { get; set; }
            }

            public class Circle
            {
                public double Radius { get; set; }
            }

            public class AreaCalculator
            {
                private readonly Rectangle rectangle;
                private readonly Circle circle;

                public AreaCalculator(Rectangle rectangle, Circle circle)
                {
                    this.rectangle = rectangle;
                    this.circle = circle;
                }

                public double Calculate(object shape)
                {
                    double area = default;

                    if (shape is Rectangle rectangle)
                    {
                        area = rectangle.Height * rectangle.Width;
                    }

                    if (shape is Circle circle)
                    {
                        area = Math.PI * circle.Radius * circle.Radius;
                    }

                    return area;
                }
            }
        }

        public class OpenCloseGood
        {
            public abstract class Shape
            {
                public abstract double Area();
            }

            public class Rectangle : Shape
            {
                public double Height { get; set; }
                public double Width { get; set; }

                public override double Area()
                {
                    return Height * Width;
                }
            }

            public class Circle : Shape
            {
                public double Radius { get; set; }

                public override double Area()
                {
                    return Math.PI * Radius * Radius;
                }
            }
        }
    }
}
