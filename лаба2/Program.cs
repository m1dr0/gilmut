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

        static void Main(string[] args)
        {
            MSI();
            Console.ReadLine();
        }
    }
}
