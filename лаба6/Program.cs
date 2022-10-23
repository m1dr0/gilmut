using System;

namespace лаба6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            f1(1.4, 2.2, 0.1, 5);
            Console.WriteLine("\n\n\n");
            f2(1.4, 2.2, 0.1, 5);

        }
        static double f(double i, double y)
        {
            return i + Math.Cos(y / 2.25);
        }

        static void f1(double x0, double y0, double h, double xn)//Метод Эйлера для ОДУ
        {
            for (double i = x0 + h; i <= xn; i = i + h)
            {
                Console.WriteLine("прих={0} , y={1}", i, (y0 + h * f(i, y0)));
                y0 = +y0 + h * f(i, y0);
            }
        }
        static void f2(double x0, double y0, double h, double xn)//Метод Рунге-Кутта для ОДУ
        {
            double k0, k1, k2, k3;
            for (double i = x0 + h; i <= xn; i = i + h)
            {
                k0 = f(i, y0);
                k1 = f(i + h / 2, y0 + h * k0 / 2);
                k2 = f(i + h / 2, y0 + h * k1 / 2);
                k3 = f(i + h / 2, y0 + h * k2 / 2);
                Console.WriteLine("при х={0} , y={1}", i, (y0 + 1 / 6 * h * (k0 + 2 * k1 + 2 * k2 + k3)));
                y0 = y0 + h * f(i, y0);
            }
        }

    }
}