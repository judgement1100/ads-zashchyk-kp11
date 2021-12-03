using System;
using static System.Console;

namespace ASD_Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.Write("m = ");
            int m = Convert.ToInt16(ReadLine());
            Console.Write("n = ");
            int n = Convert.ToInt16(ReadLine());

            int[,] arr = new int[m, n];

            Console.WriteLine("Original matrix");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        if (i + j != n - 1)
                        {
                            BackgroundColor = ConsoleColor.Red;
                            arr[i, j] = rnd.Next(-9, 10);
                            Write($"{arr[i, j],3}");
                            BackgroundColor = ConsoleColor.Black;
                            continue;
                        }
                    }
                    if (i + j == n - 1)
                    {
                        if (i != j)
                        {
                            BackgroundColor = ConsoleColor.Red;
                            arr[i, j] = rnd.Next(-9, 10);
                            Write($"{arr[i, j],3}");
                            BackgroundColor = ConsoleColor.Black;
                            continue;
                        }
                        else
                        {
                            arr[i, j] = rnd.Next(-5, 5);
                            Write($"{arr[i, j],3}");
                        }
                    }
                    else
                    {
                        arr[i, j] = rnd.Next(-5, 5);
                        Write($"{arr[i, j],3}");
                    }
                }
                Console.WriteLine();
            }
            int[] mainDiagonale = new int[m - 1];
            int[] AdditionalDiagonale = new int[n - 1];
            int counter1 = 0, counter2 = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        if (i + j != n - 1)
                        {
                            mainDiagonale[counter1] = arr[i, j];
                            counter1++;
                        }
                    }
                    if (i + j == n - 1)
                    {
                        if (i != j)
                        {
                            AdditionalDiagonale[counter2] = arr[i, j];
                            counter2++;
                        }
                    }
                }
            }
            Console.WriteLine("Sorted matrix");
            mainDiagonale = Sort1(mainDiagonale);
            AdditionalDiagonale = Sort2(AdditionalDiagonale);
            PrintSortedMatrix(arr, mainDiagonale, AdditionalDiagonale);
        }
        static void PrintSortedMatrix(int[,] arr, int[] mainDiag, int[] addDiag)
        {
            int m = arr.GetLength(0);
            int n = arr.GetLength(1);
            int counterMain = 0;
            int counterAdd = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        if (i + j != n - 1)
                        {
                            arr[i, j] = mainDiag[counterMain];
                            Write($"{arr[i, j],3}");
                            counterMain++;
                            continue;
                        }
                    }
                    if (i + j == n - 1)
                    {
                        if (i != j)
                        {
                            arr[i, j] = addDiag[counterAdd];
                            Write($"{arr[i, j],3}");
                            counterAdd++;
                            continue;
                        }
                        else
                            Write($"{arr[i, j],3}");
                    }
                    else
                    {
                        Write($"{arr[i, j],3}");
                    }
                }
                Console.WriteLine();
            }
        }
        static int[] Sort1(int[] mainDiag)
        {
            int n = mainDiag.Length;
            int start = 0;
            int end = n - 1;
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = start; i < end; i++)
                {
                    if (mainDiag[i] > mainDiag[i + 1])
                    {
                        int tmp = mainDiag[i];
                        mainDiag[i] = mainDiag[i + 1];
                        mainDiag[i + 1] = tmp;
                        sorted = false;
                    }
                }
                if (sorted)
                    break;
                end--;
                for (int i = end - 1; i >= start; i--)
                {
                    if (mainDiag[i] > mainDiag[i + 1])
                    {
                        int tmp = mainDiag[i];
                        mainDiag[i] = mainDiag[i + 1];
                        mainDiag[i + 1] = tmp;
                        sorted = false;
                    }
                }
                start++;
            }
            return mainDiag;
        }
        static int[] Sort2(int[] addDiag)
        {
            int n = addDiag.Length;
            int start = 0;
            int end = n - 1;
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = start; i < end; i++)
                {
                    if (addDiag[i] < addDiag[i + 1])
                    {
                        int tmp = addDiag[i];
                        addDiag[i] = addDiag[i + 1];
                        addDiag[i + 1] = tmp;
                        sorted = false;
                    }
                }
                if (sorted)
                    break;
                end--;
                for (int i = end - 1; i >= start; i--)
                {
                    if (addDiag[i] < addDiag[i + 1])
                    {
                        int tmp = addDiag[i];
                        addDiag[i] = addDiag[i + 1];
                        addDiag[i + 1] = tmp;
                        sorted = false;
                    }
                }
                start++;
            }
            return addDiag;
        }
    }
}
