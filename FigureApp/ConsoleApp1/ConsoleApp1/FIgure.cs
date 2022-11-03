using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    [Serializable()]
    [XmlInclude(typeof(Rectangular))]
    [XmlInclude(typeof(Square))]
    [XmlInclude(typeof(Triangle))]
    [XmlRoot(Namespace = "CosoleApp1")]
    public abstract class FIgure
    {
 
        public double area { get; set; }
        public double perimetr { get; set; }
        public List<Point> points { get; set; }
        public Point Center { get; protected set; }
        public FIgure(List<Point> points)
        {
            this.points = points;
            this.CalculateArea();
            this.CalculatePerimeter();
            this.FindCenter();
        }

        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();
        public abstract void MoveFigure(double x, double y);
        public abstract void RotateFigure(double degree);
        public abstract void ScaleFigure(double scale);
        public abstract void FindCenter();

    }
}
