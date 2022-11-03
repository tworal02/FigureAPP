using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable()]
    class Square : FIgure
    {
        public double side { get; set; }
        public Square(double side, List<Point> points) : base(points)
        {
            this.side = Math.Pow(Math.Pow(points[1].X - points[0].X, 2) + Math.Pow(points[1].Y - points[0].Y, 2), 0.5); 
        }
     
        public override double CalculateArea()
        {
            area = side * side;
            return area;
        }

        public override double CalculatePerimeter()
        {
            perimetr = 4 * side;
            return perimetr;
        }
        public override void FindCenter()
        {
            double sumX = 0;
            double sumY = 0;
            foreach (var point in points)
            {
                sumX += point.X;
                sumY += point.Y;
            }
            this.Center = new Point(sumX / 4, sumY / 4);
        }
        public override void MoveFigure(double x, double y)
        {
            foreach (var point in points)
            {
                point.X += x;
                point.Y += y;
            }
        }
        public override void RotateFigure(double degree)
        {
            foreach (var point in points)
            {
                point.X = point.X * Math.Cos(degree) - point.Y * Math.Sin(degree);
                point.Y = point.Y * Math.Cos(degree) + point.X * Math.Sin(degree);
            }
        }
        public override void ScaleFigure(double scale)
        {
            foreach (var point in points)
            {
                point.X = Center.X - scale * (Center.X - point.X);
                point.Y = Center.Y - scale * (Center.Y - point.Y);
            }
            this.CalculateArea();
            this.CalculatePerimeter();
        }
        public override string ToString()
        {
            return $"Square\nSide: {side}\nArea: {area}\nPerimeter: {perimetr}";
        }
    }
}
