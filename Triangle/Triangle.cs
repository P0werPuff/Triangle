using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Triangle
    {
        public double a;
        public double b;
        public double c;
        public double h;

        public double GetSetA
        {
            get { return a; }
            set { a = value; }
        }

        public double GetSetB
        {
            get { return b; }
            set { b = value; }
        }

        public double GetSetC
        {
            get { return c; }
            set { c = value; }
        }

        public double GetSetH
        {
            get { return h; }
            set { h = value; }
        }

        public bool ExistTriangle
        {
            get
            {
                if ((a < b + c) && (b < a + c) && (c < a + b))
                    return true;
                else return false;
            }
        }

        public string TriangleType
        {
            get
            {
                if (a == b && b == c && c == a)
                {
                    return "Равносторонний";
                }
                else if (b == c || a == b || c == a)
                {
                    return "Равнобедренный";
                }
                else return "Разносторонний";
            }
        }

        public Triangle(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
            h = Height();
        }

        public Triangle(bool byHeight, double A, double H)
        {
            if (byHeight == true)
            {
                a = A;
                h = H;
                b = h;
                c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(h, 2));
            }
            else
            {
                a = A;
                h = H;
                b = Math.Sqrt(Math.Pow(a / 2, 2) + Math.Pow(h, 2));
                c = b;
            }
        }

        public Triangle()
        {
            a = 0;
            b = 0;
            c = 0;
        }

        public string OutputA()
        {
            return Convert.ToString(a);
        }

        public string OutputB()
        {
            return Convert.ToString(b);
        }

        public string OutputC()
        {
            return Convert.ToString(c);
        }

        public string OutputH()
        {
            return Convert.ToString(h);
        }

        public double Perimeter()
        {
            double p = a + b + c;
            return p;
        }

        public double HalfPerimeter()
        {
            return Perimeter() / 2;
        }

        public double Surface()
        {
            double p = HalfPerimeter();
            double s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            return s;
        }

        public double Height()
        {
            double p = HalfPerimeter();
            double h = 2 * Math.Sqrt(p * (p - a) * (p - b) * (p - c)) / a;
            return h;
        }
    }
}
