using System;

namespace лаба3
{
    internal class Program
    {
        static double fi(double a0, double a1, double x)
        {
            return a0 + a1 * x;
        }

       static double fi1(double a0, double a1, double a2, double x)
        {
            return a0 + a1 * x + a2 * Math.Pow(x, 2);
        }

              static double delta(double c1, double c2, double c4, double c6)
               {
                   return 8 * (c2 * c6 - Math.Pow(c4, 2)) - c1 * (c1 * c6 - c2 * c4) + c2 * (c1 * c4 - Math.Pow(c2, 2));
               }

               static double delta1(double c1, double c2, double c3, double c4, double c5, double c6, double c7)
               {
                   return (c3 * c2 * c6 + c5 * c4 * c2 + c7 * c1 * c4 - c2 * c2 * c7 - c4 * c4 * c3 - c6 * c1 * c5);
                   //return (c2 * c3 * c6 + c1 * c7 * c5 + c3 * c4 * c5 - c3 * c3 * c7 - c2 * c5 * c5 - c1 * c4 * c6);
               }

               static double delta2(double c1, double c2, double c3, double c4, double c5, double c6, double c7)
               {
                    return (8 * c3 * c7 - 8 * c4 * c5 - c1 * c1 * c7 + c1 * c4 * c3 + c2 * c1 * c5 - c2 * c3 * c3);
               }

               static double delta3(double c1, double c2, double c3, double c4, double c5, double c6, double c7)
               {
                   return (8 * c2 * c7 + c1 * c5 * c2 + c3 * c1 * c4 - c3 * c2 * c2 - 8 * c5 * c4 - c1 * c1 * c7);
               }
        
        static void linear(double[] x, double[] y, int n)
        {
            double s1 = 0, s2 = 0, s4 = 0, s3 = 0;
            for (int i = 0; i < x.Length; i++)
            {
                s1 += x[i];
                s3 += Math.Pow(x[i], 2);
            }
            for (int i = 0; i < y.Length; i++)
            {
                s2 += y[i];
                s4 += x[i] * y[i];
            }
            double a0 = (s2 * s3 - s1 * s4) / (n * s3 - Math.Pow(s1, 2));
            double a1 = (n * s4 - s1 * s2) / (n * s3 - Math.Pow(s1, 2));
            Console.WriteLine("Линейная аппроксимация: \n");
            Console.WriteLine("s1= {0}, s2= {1}, s3= {2}, s4= {3}", s1, s2, s3, s4);
            Console.WriteLine("a0= {0}, a1= {1}", a0, a1);
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine("x = " + x[i] + "\tf(x) = " + fi(a0, a1, x[i]));
            }
        }
        static void square(double[] x, double[] y, int n)
        {
            double s1 = 0, s2 = 0, s3 = 0, s4 = 0, s5 = 0, s6 = 0, s7 = 0;
            for (int i = 0; i < x.Length; i++)
            {
                s1 += x[i];
                s3 += Math.Pow(x[i], 2);
                s5 += Math.Pow(x[i], 3);
                s6 += Math.Pow(x[i], 4);
                s7 = s7 + (x[i] * x[i] * y[i]);

            }
            for (int i = 0; i < y.Length; i++)
            {
                s2 += y[i];
                s4 += x[i] * y[i];
            }

            double a0 = delta1(s1, s2, s3, s4, s5, s6, s7) / delta(s1, s2, s4, s6);
            double a1 = delta2(s1, s2, s3, s4, s5, s6, s7) / delta(s1, s2, s4, s6);
            double a2 = delta3(s1, s2, s3, s4, s5, s6, s7) / delta(s1, s2, s4, s6);
            Console.WriteLine("Квадратичная аппроксимация: \n");
            Console.WriteLine("s1= {0}, s2= {1}, s3= {2}, s4= {3}, s5= {4}, s6= {5}, s7= {6}", s1, s2, s3, s4, s5, s6, s7);
            Console.WriteLine("a0= {0}, a1= {1} a2= {2}", a0, a1, a2);
            for(int i = 0; i < x.Length; i++)
            {
                Console.WriteLine("x = " + x[i] + "\tf(x) = " + fi1(a0, a1, a2, x[i]));
            }

        }
        static void Main(string[] args)
        {
            int n = 8;
            double[] x = new double[8] { -6, -3, 0, 3, 6, 9, 12, 15 };
            double[] y = new double[8] { 37.5, 32.3, 27, 21.8, 16.5, 11.5, 5.5, 1 };
            linear(x, y, n);
            square(x, y, n);
        }
    }
}
