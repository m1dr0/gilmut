using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace курсач
{
    class Program
    {
        static void InputOutputData(ref double[,] A, ref double[] b, int n)
        {

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Введите множители для {0} уравнения", i + 1);
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write("для X{0}\t", j + 1);
                        A[i, j] = double.Parse(Console.ReadLine());
                    }
                    Console.Write("для свободного члена\t");
                    b[i] = double.Parse(Console.ReadLine());
                    Console.WriteLine();
                }

            int iter = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A[i, j] + "*x{0} ", iter++);
                    Console.Write(j < n-1 ? "+ " : "");
                }
                iter = 1;
                Console.WriteLine("= " + b[i]);
            }
        }
        static void SimpleIteration(double[,] A, double[] B, ref double[] X, int n)
        {
            Console.WriteLine("Метод простой итерации");
            double[] Y = new double[n];
            double N = X[0];
            double Z = 0;
            do
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j)
                        {
                            Z = A[i, j];
                            A[i, j] = 0;
                            Y[i] = Count(A, B[i], X, i, n);
                            A[i, j] = Z;
                        }
                    }
                for (int i = 0; i < n; i++)
                {
                    if (N > Math.Abs(X[i] - Y[i]))
                        N = Math.Abs(X[i] - Y[i]);
                    X[i] = Y[i];
                }
            }
            while (N > 1E-5);
        }
        static void Divide(ref double[,] a, ref double b, double del, int i, int n)
        {
            for (int j = 0; j < n; j++)
                a[i, j] = -a[i, j] / del;
            b = b / del;
        }
        static double Count(double[,] c, double f, double[] x, int i, int n)
        {
            double y = f;
            for (int j = 0; j < n; j++)
                y += c[i, j] * x[j];
            return y;
        }
        static void Main(string[] args)
        {
        checkpoint:
            Console.Write("Введите количество неизвестных:\t");
            try
            {
                int n = int.Parse(Console.ReadLine());
                double[] X = new double[n];
                double[,] A = new double[n, n];
                double[] B = new double[n];
                InputOutputData(ref A, ref B, n);
                double Del;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                        if (i == j)
                        {
                            Del = A[i, j];
                            Divide(ref A, ref B[i], Del, i, n);
                            X[i] = B[i];
                        }
                }
                SimpleIteration(A, B, ref X, n);
                Console.Write("Ответ:");
                for (int i = 0; i < n; i++)
                    Console.Write("\t{0:F4}\0", X[i]);
            }
            catch
            {
                Console.WriteLine("Неверный ввод!");
                goto checkpoint;
            }
            Console.WriteLine();
            Console.Read();
        }
    }
}