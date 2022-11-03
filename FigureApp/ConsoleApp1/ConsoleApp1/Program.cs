using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string figuresInfo = "";
            List<FIgure> fIgures = new List<FIgure>();
            string folderName = @"C:\Users\Tworal\OneDrive\Desktop\ConsoleApp\Figures.txt";
            while (true)
            {
                //Console application with menu:
                //1) show all figures
                //2) create a figure
                //3) change figure:
                //    a) move figure
                //    b) rotate figure
                //    c) scale figure
                //4)save to file
                //0) exit
                //While application is openings it's load data from file. 
                //figure should have info about their perimeter and area too.
                Console.WriteLine("Menu:\n");
                Console.WriteLine("1) show all figures\n");
                Console.WriteLine("2) create a figure\n");
                Console.WriteLine("3) change figure:\n");
                Console.WriteLine("a) move figure\n");
                Console.WriteLine("b) rotate figure\n");
                Console.WriteLine("4)save to file\n");
                Console.WriteLine("0) exit");
                Console.Write("\nChoose from menu: ");
                string input = Console.ReadLine();


                if (input == "0")
                {
                    Environment.Exit(0);

                }
                if (input == "1")
                {
                    string[] lines = File.ReadAllLines(@"C:\Users\Orkhan\OneDrive\Desktop\ConsoleApp\Figures.txt");
                    foreach (var item in lines)
                    {
                        Console.WriteLine(item);
                        string[] words = item.Split(' ', ':');
                        foreach (var w in words) Console.WriteLine(w);
                    }
                }
                if (input == "2")
                {
                    Console.WriteLine("a) Square\n");
                    Console.WriteLine("b) rectangular\n");
                    Console.WriteLine("c) Triangle\n");
                    string options = Console.ReadLine();
                    switch (options)
                    {
                        case "a":
                            Console.Write("Enter side:");
                            double side = Convert.ToDouble(Console.ReadLine());
                            List<Point> pointsquare = new List<Point>()
                            {
                                new Point(0,0),
                                new Point(0,4),
                                new Point(4,4),
                                new Point(4,0)
                            };
                            Square newSquare = new Square(side, pointsquare);
                            double area = newSquare.CalculateArea();
                            double perimetr = newSquare.CalculatePerimeter();
                            Console.WriteLine($"Area:{area}, Perimetr{perimetr}");

                            figuresInfo += $"Square Side: {side} Area: {area} Perimeter: {perimetr}";
                            break;
                        case "b":
                            Console.Write("Enter length:");
                            double length = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter height:");
                            double height = Convert.ToDouble(Console.ReadLine());
                            List<Point> pointRectangular = new List<Point>()
                            {
                                new Point(0,0),
                                new Point(0,5),
                                new Point(5,4),
                                new Point(4,0)
                            };
                            Rectangular newRectangular = new Rectangular(length, height, pointRectangular);
                            double RectangularArea = newRectangular.CalculateArea();
                            double RectangularPerimetr = newRectangular.CalculatePerimeter();
                            Console.WriteLine($"Area:{RectangularArea}, Perimetr{RectangularPerimetr}");
                            fIgures.Add(newRectangular);
                            figuresInfo += newRectangular.ToString(); break;
                        case "c":
                            Console.Write("Enter a:");
                            double a = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter b:");
                            double b = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter c:");
                            double c = Convert.ToDouble(Console.ReadLine());
                            List<Point> pointTriangle = new List<Point>()
                            {
                                new Point(0,0),
                                new Point(0,8),
                                new Point(6,0)
                            };
                            Triangle newTriangle = new Triangle(pointTriangle);
                            double TriangleArea = newTriangle.CalculateArea();
                            double TrianglePerimetr = newTriangle.CalculatePerimeter();
                            Console.WriteLine($"Area:{TriangleArea}, Perimetr{TrianglePerimetr}");
                            figuresInfo += $"\nTriangle\nSide 1: {a}\nSide 2: {b}\nSide 3: {c}\nArea: {TriangleArea}\nPerimeter: {TrianglePerimetr}\n"; break;
                        default:
                            break;
                    }
                }
                else if (input == "3")
                {
                    Console.WriteLine("Choose option a,b,c:");
                    string yourOption = Console.ReadLine();
                    switch (yourOption)
                    {
                        case "a":
                            Console.Write("Choose figure: ");
                            int optionFigure = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < fIgures.Count; i++)
                            {
                                if (optionFigure == i + 1)
                                {
                                    FIgure currentFigure = fIgures[i];
                                    Console.Write("Enter x: ");
                                    double x = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("Enter y: ");
                                    double y = Convert.ToDouble(Console.ReadLine());
                                    currentFigure.MoveFigure(x, y);
                                }
                            }
                            break;
                        case "b":
                            Console.Write("Choose figure: ");
                            int optionFigureRotate = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < fIgures.Count; i++)
                            {
                                if (optionFigureRotate == i + 1)
                                {
                                    FIgure currentFigure = fIgures[i];
                                    Console.Write("Enter degree: ");
                                    double degree = Convert.ToDouble(Console.ReadLine());
                                    currentFigure.RotateFigure(degree);
                                }
                            }
                            break;
                        case "c":
                            Console.Write("Choose figure: ");
                            int optionFigureScale = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < fIgures.Count; i++)
                            {
                                if (optionFigureScale == i + 1)
                                {
                                    FIgure currentFigure = fIgures[i];
                                    Console.Write("Enter scale: ");
                                    double scale = Convert.ToDouble(Console.ReadLine());
                                    currentFigure.RotateFigure(scale);
                                }
                            }
                            break;
                    }   
                }
                if (input == "4")
                {
                    using (StreamWriter writer = new StreamWriter(folderName, false))
                    {
                        foreach (var f in fIgures)
                            writer.WriteLine(f.ToString());
                    }
                    break;
                    Stream SaveFileStream = File.Create(folderName);
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(SaveFileStream, fIgures);
                    SaveFileStream.Close();
                }
            }
        }
    }
}
