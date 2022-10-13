using System;

namespace лаба4
{
    internal class Program
    {

        static double InterpolateLagrange(double x, double[] xValues, double[] yValues, int size)
        {
            double lagrangePol = 0;
            for (int i = 0; i < size; i++)
            {
                double basicsPol = 1;
                for (int j = 0; j < size; j++)
                {
                    if (j != i)
                    {
                        basicsPol *= (x - xValues[j]) / (xValues[i] - xValues[j]);
                    }
                }
                lagrangePol += basicsPol * yValues[i];
            }
            return lagrangePol;

        }

        static void Main(string[] args)
        {
            int n = 8;
            int inter = 7;
            double[] x = new double[8] { -6, -3, 0, 3, 6, 9, 12, 15 };
            double[] y = new double[8] { 37.5, 32.3, 27, 21.8, 16.5, 11.5, 5.5, 1 };
            Console.WriteLine("Точка для интерполяции = {0}", inter);
            Console.WriteLine("y = {0}", InterpolateLagrange(inter, x, y, n));
        }
    }
}
