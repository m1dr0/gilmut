using System;

namespace лаба6
{
    internal class Program
    {
        static void StartProgramm()
        {
            Console.WriteLine("1.Метод Эйлера системы");
            Console.WriteLine("2.Метод Рунге-Кутта для системы");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    TestEulerCoupledODE();
                    break;
                case 2:
                    run();
                    break;
                default:
                    StartProgramm();
                    break;

            }
            Console.WriteLine();
            Console.ReadLine();
            StartProgramm();
        }

        static double fi(double x, double y, double z)
        { 
            return -2 * y * x + z; 
        }

        static double tu(double x, double y, double z)
        { 
            return 3 * y - 2 * z; 
        }


        static void TestEulerCoupledODE()
        {
            double x = 0, y = 5.0, z = 10.0;  //нач условия
            double h = 0.1;                  //шаг
            double k0, k1, k2, k3;
            double l0, l1, l2, l3;

            for (double i = 0 + h; i <= 1; i = i + h)
            {

                k0 = fi(x, y, z) * h;
                l0 = tu(x, y, z) * h;
                k1 = fi(x + h / 2, y + k0 / 2, z + l0 / 2) * h;
                l1 = tu(x + h / 2, y + k0 / 2, z + l0 / 2) * h;
                k2 = fi(x + h / 2, y + k1 / 2, z + l1 / 2) * h;
                l2 = tu(x + h / 2, y + k1 / 2, z + l1 / 2) * h;
                k3 = fi(x + h, y + k2, z + l2) * h;
                l3 = tu(x + h, y + k2, z + l2) * h;
                y = y + (k0 + 2 * k1 + 2 * k2 + k3) / 6;
                z = z + (l0 + 2 * l1 + 2 * l2 + l3) / 6;
            }
            Console.WriteLine("y = {0} z = {1}", y, z);
        }

        static void run()
        {
            double x = 0, y = 5.0, z = 10.0;  //нач условия
            double h = 0.1;                  //шаг
            double k0, k1, k2, k3;
            double l0, l1, l2, l3;

            for (double i = 0 + h; i <= 1; i = i + h)
            {

                k0 = fi(x, y, z) * h;
                l0 = tu(x, y, z) * h;
                k1 = fi(x + h / 2, y + k0 / 2, z + l0 / 2) * h;
                l1 = tu(x + h / 2, y + k0 / 2, z + l0 / 2) * h;
                k2 = fi(x + h / 2, y + k1 / 2, z + l1 / 2) * h;
                l2 = tu(x + h / 2, y + k1 / 2, z + l1 / 2) * h;
                k3 = fi(x + h, y + k2, z + l2) * h;
                l3 = tu(x + h, y + k2, z + l2) * h;
                y = y + (k0 + 2 * k1 + 2 * k2 + k3) / 6;
                z = z + (l0 + 2 * l1 + 2 * l2 + l3) / 6;
            }
            Console.WriteLine("y = {0} z = {1}", y, z);
        }


        static void Main(string[] args)
        {
            StartProgramm();
        }
    }
}