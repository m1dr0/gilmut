using System;

namespace mvl2
{
    class Program
    {
        static double func1(double x2, double x3)
        {
            return ((-4 + x2 - 3 * x3) / 2);
        }

        static double func2(double x1, double x3)
        {
            return ((2 - x1 + x3) / 3);
        }

        static double func3(double x1, double x2)
        {
            return (5 - 5 *x1 - 2*x2);
        }

        static double phi1(double x2)
        {
            return (0.7 - Math.Cos(x2 - 1.0));
        }

        static double phi2(double x1)
        {
            return (-2 - (Math.Sin(x1)));
        }

        static void MSI()
        {
            Console.WriteLine("2*x1-x2+3*x3=-4");
            Console.WriteLine("x1+3*x2-x3=2");
            Console.WriteLine("5*x1+2*x2+x3=5");
            Console.WriteLine("Решение системы :\n");
            double n = 22;
            double x1 = -4;
            double x2 = 2;
            double x3 = 5;
            while (n != 0)
            {
                x1 = func1(x2, x3);
                x2 = func2(x1, x3);
                x3 = func3(x1, x2);
                Console.WriteLine("x1=" + x1 + "\tx2=" + x2 + "\tx3=" + x3);
                n--;
            }

        }
            static void MSI2()
        {
            double x1 = 0, x2 = 0, x1last, x2last, dx1 = double.MaxValue, dx2 = double.MaxValue;
            int n = 0;
            while (Math.Abs(dx1) > 0.001 && Math.Abs(dx2) > 0.001)
            {
                x1last = x1;
                x2last = x2;
                x1 = phi1(x2last);
                x2 = phi2(x1last);
                dx1 = x1 - x1last;
                dx2 = x2 - x2last;
                n++;
            }
            Console.WriteLine("x1 = " + x1);
            Console.WriteLine("x2 = " + x2);
            Console.WriteLine("dx1 = " + dx1);
            Console.WriteLine("dx2 = " + dx2);
            Console.WriteLine("n = " + n);
            Console.WriteLine((Math.Cos(x2 - 1) + x1) + " = 0.7");
            Console.WriteLine((Math.Sin(x1) - 2 * x2) + " = 1");
        }

        static void Main(string[] args)
        {
            MSI();
            //MSI2();
        }
    }
}
