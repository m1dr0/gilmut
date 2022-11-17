using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Petrov7
{
    class Program
    {
        static int n;
        static void ReadData(ref double[,] A, ref double[] b)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите множители для {0} уравнения", i + 1);
                Console.WriteLine("Примечание: для X{0} множитель должен быть максималь-ный", i + 1);
                for (int j = 0; j < n; j++)
                {
                    Console.Write("для X{0}\t", j + 1); A[i, j] = double.Parse(Console.ReadLine());
                }
                Console.Write("для свободного члена\t"); b[i] = double.Parse(Console.ReadLine());
                Console.WriteLine();
            }
        }
        static void Простая(double[,] A, double[] B, ref double[] X)
        {
            Console.WriteLine("Метод простой итерации");
            double[] Y = new double[n];
            double N = X[0];
            double Z = 0;
            do
            {
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j)
                        {
                            Z = A[i, j];
                            A[i, j] = 0;
                            Y[i] = Счет(A, B[i], X, i);
                            A[i, j] = Z;
                        }
                    }
                for (int i = 0; i < 3; i++)
                {
                    if (N > Math.Abs(X[i] - Y[i]))
                        N = Math.Abs(X[i] - Y[i]);
                    X[i] = Y[i];
                }
            }
            while (N > 1E-5);
        }
        static void Деление(ref double[,] a, ref double b, double del, int i)
        {
            for (int j = 0; j < n; j++)
                a[i, j] = -a[i, j] / del;
            b = b / del;
        }
        static double Счет(double[,] c, double f, double[] x, int i)
        {
            double y = f;
            for (int j = 0; j < n; j++)
                y += c[i, j] * x[j];
            return y;
        }
        static void Зейдель(double[,] A, double[] B, ref double[] X)
        {
            Console.WriteLine("Метод Зейделя");
            double[] Y = new double[n];
            double N = X[0];
            double Z = 0;
            do
            {
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j)
                        {
                            Z = A[i, j];
                            A[i, j] = 0;
                            Y[i] = Счет(A, B[i], X, i);
                            A[i, j] = Z;
                            if (N > Math.Abs(X[i] - Y[i]))
                                N = Math.Abs(X[i] - Y[i]);
                            X[i] = Y[i];
                        }
                    }
            }
            while (N > 1E-5);
        }
        static void Main(string[] args)
        {
            Console.Write("Введите колчиство неизвестных\t"); n =
            int.Parse(Console.ReadLine());
            double[] X;
            double[,] A = { { 3.48, 1.61, -0.95 }, { 3.02, 6.87, -6.27 }, { 0.02, 2.03, 6.57 } };
            double[] B = { 14.76, 3.09, 32.77 };
            X = new double[n];
            ReadData(ref A, ref B);
            double Del;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < n; j++)
                    if (i == j)
                    {
                        Del = A[i, j];
                        Деление(ref A, ref B[i], Del, i);
                        X[i] = B[i];
                    }
            }
        metka1:
            Console.WriteLine("Выберите метод решения:");
            Console.WriteLine("1. Метод простой итеррации");
            Console.WriteLine("2. Метод Зейделя");
            Console.WriteLine("3. Выход");
            Console.Write("Ваш выбор:\t");
            string line = Console.ReadLine();
            if (line == "1")
                Простая(A, B, ref X);
            else if (line == "2")
                Зейдель(A, B, ref X);
            else
                goto metka2;
            Console.Write("Ответ:\t");
            for (int i = 0; i < 3; i++)
                Console.Write("\t{0:F4}\0", X[i]);
            Console.WriteLine();
            Console.WriteLine("**************************************************");
            goto metka1;
        metka2:
            Console.WriteLine("Выход");
            Console.Read();
        }
    }
}