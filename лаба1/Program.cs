using System;

namespace laba1
{
    class Program
    {
        static void MPD()
        {
            double a = -10, b = 10, n = 0, e = 0.0001, x;
            while (Math.Abs(b - a) > e)
            {
                x = (a + b) / 2;
                if (func(a) * func(x) > 0) a = x;
                else b = x;
                n++;
            }
            x = (a + b) / 2;
            Console.WriteLine("x = " + x + "\nn = " + n + "\nF(x) = " + func(x));
        }

        static void MH()
        {
            double x = -10, p, e = 0.0001, n = 0, x1 = 10, c;
            Console.WriteLine("Начальный x = " + x);
            do
            {
                p = x;
                x = x1;
                x1 -= func(x) * (x - p) / (func(x) - func(p));
                c = x1 - x;
                n++;
            } while (Math.Abs(c) > e);
            Console.WriteLine("x1 = " + x1 + "\nn = " + n + "\nF(x) = " + func(x) + "c = " + c);
        }

        static void MC()
        {
            double x = -10, e = 0.0001, n = 0, x1 = 0, c = double.MaxValue;
            while (c > e)
            {
                x1 = x - (func(x) / pr(x));
                c = Math.Abs(x1 - x);
                x = x1;
                n++;
            }
            Console.WriteLine("x1 = " + x1 + "\nn = " + n + "\nF(x) = " + func(x) + "c = " + c + "pr = " + pr(x));
        }

        static void MSI()
        {
            double x = -1, e = 0.0001, n = 0, x1 = 0, c = double.MaxValue;
            while (c > e)
            {
                x1 = fi(x);
                c = Math.Abs(x1 - x);
                x = x1;
                n++;
            }
            Console.WriteLine("x1 = " + x1 + "\nn = " + n + "\nF(x) = " + func(x) + "c = " + c + "fi = " + fi(x));
        }

        static double fi(double x)
        {
            return -((Math.Pow(x, 3) + 1) / 3);
        }

        static double pr(double x)
        {
            return Math.Pow(x, 2) * 3 + 2;
        }

        static double func(double x)
        {
            return Math.Pow(x, 3) + 4*x - 6;
        }
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("1 - Метод половинного деления\n" +
                "2 - Метод Хорд\n" +
                "3 - Метод касательных\n" +
                "4 - Метод простых итераций");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (n)
                {
                    case 1:
                        MPD();
                        break;
                    case 2:
                        MH();
                        break;
                    case 3:
                        MC();
                        break;
                    case 4:
                        MSI();
                        break;
                }
                Console.WriteLine();
            }
        }
    }

}

