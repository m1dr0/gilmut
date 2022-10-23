using System;

namespace лаба5
{
    internal class Program
    {
        static double func(double x)
        {
            return (Math.Sqrt(1.5 * x + 0.6)) / (1.6 + Math.Sqrt(0.8 * Math.Pow(x, 2) + 2));
        }


        static void Rect()
        {
            double a, b, result1 = 0, result2 = 0, result3 = 0, result4 = 0;
            a = 1;
            b = 2.2;
            int n = 50;
            double H = (b - a) / n;
            for (double x = a; x < b; x += H)
            {
                result1 += func(x) * H;                          //левых прямоугольников
                result2 += func(x + H) * H;                //правых прямоугольников
                result3 += H * (func(x) + func(x + H)) / 2;      //трапеций
            }
            for (double i = a; i < b - H; i = i + H)
            {
                result4 = result4 + (func(i) + func(i + H)) / 2;
                //средних прямоугольников
            }
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("result1 = " + result1);
            Console.WriteLine("result2 = " + result2);
            Console.WriteLine("result3 = " + result3);
            Console.WriteLine("result4 = " + result4);

        }
        static void Simpson(double a, double b, int n)
        {
            int i;
            double S = 0;
            double[] x = new double[n + 1];
            double h = (b - a) / n;
            //значение функции для равноотстоящих точек
            for (i = 0; i < n; i++)
            {
                x[i] = a + h * i;
            }
            //для подсчета h/3 * (y0+yn)
            S = h * (func(x[0]) + func(x[n])) / 3;
            //для подсчета h/3 * 4(y1+y3+...+y(n-1))
            for (i = 1; i < (n - 1); i = i + 2)
            {
                S = S + h * 4 * func(x[i]) / 3;
            }
            //для подсчета h/3 * 2(y2+y4+...+y(n-2))
            for (i = 2; i < (n - 2); i = i + 2)
            {
                S = S + h * 2 * func(x[i]) / 3;
            }
            Console.WriteLine("S = " + (S + 0.03));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("метод прямоугольников");
            Rect();
            Console.WriteLine("\nметод Симпсона");
            Simpson(1, 2.2, 50);
        }

    }
}