using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Rektanglar_och_Ellipser
{
    internal class Program
    {
        public enum ShapeType
        {
            Rectangle,
            Ellipse
        }

        public static Shape CreateShape(ShapeType shape)
        {
            switch (shape)
            {
                case ShapeType.Rectangle:
                    return new Rectangle();
                case ShapeType.Ellipse:
                    return new Ellipse();
            }
            return new Ellipse();
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Shape Parameter´s Calculator in C#\r");
            Menu();
            string inputValue = Console.ReadLine();

            while (inputValue != "q")
            {
                switch (inputValue)
                {
                    case "1":
                        var parametersRectangle = GetDataFromUser();
     
                        Shape rectangle = CreateShape(ShapeType.Rectangle);
                        rectangle.Length = parametersRectangle[0];
                        rectangle.Width = parametersRectangle[1];
                        ViewShapeInfo(rectangle);
                        inputValue = Console.ReadLine();
                        break;
                    case "2":
                        var parametersEllipse = GetDataFromUser();
                        Shape ellipse = CreateShape(ShapeType.Ellipse);
                        ellipse.Length = parametersEllipse[0];
                        ellipse.Width = parametersEllipse[1];
                        ViewShapeInfo(ellipse);
                        inputValue = Console.ReadLine();
                        break;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("This option is not defined. Try again!");
                        inputValue = Console.ReadLine();
                        break;
                }
            }
        }


        public static void ViewShapeInfo(Shape shape)
        {
            Console.WriteLine(shape.ToString());
            Menu();
            
        }

        public static void Menu()
        {
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Choose one option and press Enter:");
            Console.WriteLine("1 - I want to know info about rectangle");
            Console.WriteLine("2 - I want to know info about ellipse");
            Console.WriteLine("q - Exit");
        }

        public static List<double> GetDataFromUser()
        {
            string[] paramNames = { "length", "width" };
            List<double> parameters = new List<double>();
            foreach (string name in paramNames)
            {
                parameters.Add(CheckParameters(name));
            }
            return parameters;
        }

        public static double GetCheckedParameters(string name)
        {
            bool isSaved = false;
            while (!isSaved)
            {
                Console.WriteLine("Insert " + name + " and press Enter: ");
                string parameter = Console.ReadLine();
                try
                {
                    double parameterFromUser = Convert.ToInt32(parameter);
                    if (parameterFromUser > 0)
                    {
                        isSaved = true; 
                        return parameterFromUser;
                    }
                    else
                    {
                        Console.WriteLine("Parameter must be greater than 0");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Parameter must be numeric");
                }
            }
            return 0;

        }
    }
}
