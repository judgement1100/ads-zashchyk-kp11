using System;
using static System.Math;
using static System.Console;
using static System.Convert;

namespace Laba_1__ASD_
{
    class ex1
    {
        static void Main(string[] args)
        {
            double a, b;
            a = b = double.NaN;
            Console.Write("x = "); double x = ToDouble(ReadLine());
            Console.Write("y = "); double y = ToDouble(ReadLine());
            Console.Write("z = "); double z = ToDouble(ReadLine());
            a = 1 / (2 * Sin(PI + x)) + Pow(Sin((x + y) / z), 2);
            b = Cos(x * Pow(a, 2)) / (2 * y * z);
            if (double.IsNaN(a))
            {
                if (double.IsNaN(b))
                {
                    Console.WriteLine("a є 'empty plural'");
                    Console.WriteLine("b є 'empty plural'");
                }
                else
                {
                    Console.WriteLine("a є 'empty plural'");
                    Console.WriteLine("b = " + b);
                }
            }
            else
            {
                if (double.IsInfinity(b))
                {
                    Console.WriteLine("a = " + a);
                    Console.WriteLine("b є 'empty plural'");
                }
                else
                {
                    Console.WriteLine(" a = " + a);
                    Console.WriteLine("b = " + b);
                }
            }
            ReadKey();
        }
    }
}