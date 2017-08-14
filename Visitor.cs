using System;

namespace Patterns
{

    //ideas : doctor visitor, expression visitor, document visitor
    public interface IShapeVisitor {
        void Visit(Triangle visitable);
        void Visit(Circle visitable);
        void Visit(Rectangle visitable);
    }

    public class Rectangle:IVisitable
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public void Accept(IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Circle:IVisitable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Radius { get; set; }

        public void Accept(IShapeVisitor visitor)
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

        public void Accept(IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ShapeAreaVisitor : IShapeVisitor
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

    public class ShapeDrawSVGVisitor : IShapeVisitor
    {
        private string svgContent;

        public string RenderSVG(int h, int w) {
            return "<svg id=\"mySVG\">" + svgContent + "</svg>";
        }
        public void Visit(Triangle visitable)
        {
            //svgContent += $"<path fill=\"none\" stroke=\"red\" stroke-width=\"3\" d=\"M{visitable.A} 0 L{visitable.B} {visitable.Height} L{visitable.C} {visitable.Height} Z\"/>";
        }

        public void Visit(Circle visitable)
        {
            svgContent += $"<ellipse cx=\"{visitable.X}\" cy=\"{visitable.Y}\" rx=\"{visitable.Radius}\" ry=\"{visitable.Radius}\" style=\"fill:yellow;stroke:purple;stroke-width:2\" />";
        }

        public void Visit(Rectangle visitable)
        {
            svgContent += $"<rect width=\"{visitable.Width}\" height=\"{visitable.Height}\" style=\"fill:rgb(0,0,255);stroke-width:3;stroke:rgb(0,0,0)\" />";
        }
    }

    public class ShapeLengthVisitor : IShapeVisitor
    {
        public double Length { get; set; }
        public void Visit(Triangle visitable)
        {
            Length += visitable.A * + visitable.B + visitable.C;
        }

        public void Visit(Circle visitable)
        {
            Length += 2 * Math.PI * visitable.Radius;
        }

        public void Visit(Rectangle visitable)
        {
            Length += 2 * visitable.Height + 2 * visitable.Width;
        }
    }

    public interface IVisitable
    {
        void Accept(IShapeVisitor visitor);
    }

    public class VisitorTest {
        public static void Test() {
            IVisitable[] shapes = new IVisitable[] {
                new Triangle { B = 5.6, Height = 7.3 },
                new Circle { Radius = 13, X = 50, Y = 50 },
                new Triangle { B = 8, A = 17, C = 10, Height = 12 },
                new Rectangle { Height = 6, Width = 7.6 },
                new Triangle { B = 5.6,  A = 17, C = 10, Height = 4 }
            };

            ShapeAreaVisitor areaVisitor = new ShapeAreaVisitor();
            ShapeLengthVisitor lengthVisitor = new ShapeLengthVisitor();
            ShapeDrawSVGVisitor drawVisitor = new ShapeDrawSVGVisitor();
            foreach (var item in shapes)
            {
                item.Accept(areaVisitor);
                item.Accept(lengthVisitor);
                item.Accept(drawVisitor);
            }
            var svg = drawVisitor.RenderSVG(600,600);
            Console.WriteLine("Total Area: " + areaVisitor.Area);
            Console.WriteLine("Total Length: " + lengthVisitor.Length);
        }
    }
}