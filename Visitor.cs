using System;

namespace Patterns
{
    public interface IVisitor {
        void Visit(Triangle visitable);
        void Visit(Circle visitable);
        void Visit(Rectangle visitable);
    }

    public class Rectangle:IVisitable
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Circle:IVisitable
    {
        public double Radius { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Triangle:IVisitable
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double Height { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ShapeAreaVisitor : IVisitor
    {
        public double Area { get; set; }
        public void Visit(Triangle visitable)
        {
            Area += (visitable.Height * visitable.B) / 2;
        }

        public void Visit(Circle visitable)
        {
            Area += Math.PI * Math.Pow(visitable.Radius, 2);
        }

        public void Visit(Rectangle visitable)
        {
            Area += visitable.Height * visitable.Width;
        }
    }

    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }

    public class VisitorTest {
        public static void Test() {
            IVisitable[] shapes = new IVisitable[] {
                new Triangle { B = 5.6, Height = 7.3 },
                new Circle { Radius = 13 },
                new Triangle { B = 8, Height = 12 },
                new Rectangle { Height = 6, Width = 7.6 },
                new Triangle { B = 5.6, Height = 4 }
            };

            ShapeAreaVisitor visitor = new ShapeAreaVisitor();
            foreach (var item in shapes)
            {
                item.Accept(visitor);
            }

            Console.WriteLine("Total Area: " + visitor.Area);
        }
    }
}