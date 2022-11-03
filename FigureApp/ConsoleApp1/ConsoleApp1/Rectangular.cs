using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable()]
    class Rectangular : FIgure
    {

        public double a { get; set; }
        public double b { get; set; }
   
        public Rectangular(double a,double b, List<Point> points) : base(points)
        {
            this.a = Math.Pow(Math.Pow(points[1].X - points[0].X, 2) + Math.Pow(points[1].Y - points[0].Y, 2), 0.5); ;
            this.b = Math.Pow(Math.Pow(points[3].X - points[2].X, 2) + Math.Pow(points[3].Y - points[2].Y, 2), 0.5); ;

        }
        public override double CalculateArea()
        {
            area = a * b;
            return area;
        }

        public override double CalculatePerimeter()
        {
            perimetr = 2*(a+b);
            return perimetr;
        }

        public override string ToString()
        {
            return "Rectangle Side 1:" +a+" Side 2: "+ b +" Area: "+ area + " Perimeter: " + perimetr;
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
    }
}
