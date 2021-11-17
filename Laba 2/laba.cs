using System;
using static System.Console;

namespace ex1_laba2
{
    class laba
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter num of cols");
            int cols = Convert.ToInt16(ReadLine());
            Console.WriteLine("Enter num of rows");
            int rows = Convert.ToInt16(ReadLine());
            int[,] arr = GenerateMatrix(cols, rows);
            Console.WriteLine("Normal matrix");
            PrintMatrix_normalMethod(arr);
            Console.WriteLine("\nReversed matrix");
            PrintMatrix_HelixMethod_Reversed(arr);
            Console.WriteLine("\nResult");
            Res_Between(arr);
            ReadKey();
        }
        static int[,] GenerateMatrix(int cols, int rows)
        {
            Random rnd = new Random();
            int[,] arr = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = rnd.Next(1,10);
                }
            }
            return arr;
        }
        static void PrintMatrix_normalMethod(int[,] arr)
        {
            int len1 = arr.GetLength(0);
            int len2 = arr.GetLength(1);
            int[] indexes = new int[arr.Length];
            for (int i = 0; i < len1; i++)
            {
                for (int j = 0; j < len2; j++)
                {
                    Console.Write("{0, 3}", arr[i,j]);
                }
                Console.WriteLine();
            }
        }
        static void PrintMatrix_HelixMethod_Reversed(int[,] arr_2d)
        {
            int start_i = 0;
            int start_j = 0;
            int end_i = arr_2d.GetLength(0);
            int end_j = arr_2d.GetLength(1);
            while (start_i < end_i && start_j < end_j)
            {
                for (int j = end_j - 1; j >= start_j; j--)
                {
                    Write("[{1},{2}] ({0})\t", arr_2d[end_i - 1, j], end_i - 1, j);
                }
                end_i--;

                Console.WriteLine();
                Console.WriteLine();

                for (int i = end_i - 1; i >=  start_i; i--)
                {
                    Write("[{1},{2}] ({0})\t", arr_2d[i, start_j], i, start_j);
                }
                start_j++;

                if (start_i < end_i)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    for (int j = start_j; j < end_j; j++)
                    {
                        Write("[{1},{2}] ({0})\t", arr_2d[start_i, j], start_i, j);
                    }
                    start_i++;
                }

                if (start_j < end_j)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    for (int i = start_i; i < end_i; i++)
                    {
                        Write("[{1},{2}] ({0})\t", arr_2d[i, end_j - 1], i, end_j - 1);
                    }
                    end_j--;
                }
            }
        }
        static void Res_Between (int[,] arr)
        {
            int len1 = arr.GetLength(0);
            int len2 = arr.GetLength(1);
            int max = int.MinValue;
            int min = int.MaxValue;
            double halfSum = 0;
            for (int i = 0; i < len1; i++)
            {
                for (int j = 0; j < len2; j++)
                {
                    if ((i + j < len2 - 1) && (j > i))
                    { 
                        Console.Write("{0, 3}", arr[i, j]);
                        if (arr[i, j] > max)
                            max = arr[i, j];
                        if (arr[i, j] < min)
                            min = arr[i, j];
                    }
                }
            }
            halfSum = 1.0 * (max + min) / 2;
            Console.WriteLine("\nHalf-sum = " + halfSum);
        }
    }
}
