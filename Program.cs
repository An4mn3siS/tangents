using System;
using System.Collections.Generic;
using System.Text;

namespace касательные
{
    internal class Program
    {
        static double a, b, d, e, x;
        static int n = 1;
        static Random rnd = new Random();
        static double f(double x)
        {
            double f = 2 * x * x + x + Math.Pow(Math.Cos(x), 2);
            return f;
        }
        static double f_der(double x)
        {
            return 4*x+1-Math.Sin(2*x);
        }
        static double Xmin(double a, double b)
        {
            return (f(b) - f(a) + f_der(a) * a - f_der(b) * b) / (f_der(a) - f_der(b));
        }
        static double tang(double x, double a)
        {
            return f(a) + f_der(a) * (x - a);
        }
        static void Main(string[] args)
        {
            a = -1;
            b = 1;
            d = 0.0000001;
            e = 0.000001;
            x = rnd.NextDouble()+rnd.NextDouble()-1;
            while (Math.Abs(f(Xmin(a, b))-tang(x,a)) >= e || Math.Abs(f(Xmin(a, b)) - tang(x, b)) >= e)
            {
                if (f_der(Xmin(a, b))<0)
                    a = Xmin(a, b);
                else
                    b = Xmin(a, b);
                n++;
            }
            Console.WriteLine("X минимальное: " + Convert.ToString(Xmin(a, b)));
            Console.WriteLine("Значение функции в этой точке: " + Convert.ToString(f(Xmin(a,b))));
            Console.WriteLine("Количество итераций: " + Convert.ToString(n - 1));
            Console.WriteLine("Уравнение касательной (слева): f(x) = "+Convert.ToString(f(a))+" + ("+
                Convert.ToString(f_der(a))+") * (x - ("+Convert.ToString(a)+"))");
            Console.ReadLine();
        }
    }
}
