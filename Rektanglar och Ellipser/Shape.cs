using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rektanglar_och_Ellipser
{
    public abstract class Shape
    {
        private double _length;
        private double _width;

        public abstract double Area { get; }
        public double Length 
        {
            get { return _length; }
            set
            {
                if (value > 0)
                {
                    _length = value;
                }
                else
                {
                    throw new ApplicationException("Length must be a number greater than 0");
                }
            }
        }
        public abstract double Perimeter { get; }
        public double Width 
        {
            get { return _width; }
            set
            {
                if (value > 0)
                {
                    _width = value;
                }
                else
                {
                    throw new ApplicationException("Width must be a number greater than 0");
                }
            }
        }

        public Shape(double l, double w)
        {
            Length = l;
            Width = w;
        }

        public Shape()
        {
        }

        public override string ToString()
        {
            string result = 
                "\n Längd: " + Length + 
                "\n Bredd: " + Width + 
                "\n Omkrets: " + Perimeter + 
                "\n Area: " + Area;

            return result;
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle()
        {
        }

        public Rectangle(double l, double w) : base()
        {
            Length = l;
            Width = w;
        }
        
        public override double Area
        {
            get => Length * Width;
        }
        public override double Perimeter
        { 
            get => 2 * (Length + Width); 
        }
    }

    public class Ellipse : Shape
    {
        public Ellipse()
        {
        }

        public Ellipse(double l, double w) : base()
        {
            Length = l;
            Width = w;
        }
        public override double Area
        {
            get => 2 * Math.PI * Math.Sqrt((Length * Length + Width * Width) / 2);
        }
        public override double Perimeter
        {
            get => (Length / 2) * (Width / 2) * Math.PI; 
        }
    }
}
