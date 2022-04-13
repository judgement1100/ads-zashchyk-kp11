using System;
using System.Collections.Generic;
using static System.Console;
using static System.Convert;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Would you like to see example? (enter 'yes' or 'no')");
                string answer = ReadLine();
                if (answer == "yes")
                {
                    string[] myArr = new string[5] { "a1234bc", "m1234df", "k1111lh", "k1222lg", "k9999ff" };
                    Console.WriteLine("Your lines:");
                    PrintArray(myArr);
                    string[] sortedArr = MySort(myArr);
                    Console.WriteLine("Sorted:");
                    PrintArray(sortedArr);
                }
                else if (answer == "no")
                {
                    Console.WriteLine("How many lines do you want to have?");
                    bool repeat = true;
                    int numOfLines = 0;
                    while (repeat)
                    {
                        try
                        {
                            numOfLines = Convert.ToInt32(ReadLine());
                            repeat = false;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Try again!");
                        }
                    }
                    string[] myArr = new string[numOfLines];
                    Console.WriteLine($"Enter {numOfLines} line(s) such as <X0000XX> (X - letter, 0 - number)");
                    for (int i = 0; i < numOfLines; i++)
                    {
                        string line = ReadLine();
                        if (CheckIfLinesAreCorrect(line))
                        {
                            myArr[i] = line;
                        }
                        else
                        {
                            Console.WriteLine("Try again. This result will be deleted.");
                            i--;
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Your lines:");
                    PrintArray(myArr);
                    string[] sortedArr = MySort(myArr);
                    Console.WriteLine("Sorted:");
                    PrintArray(sortedArr);
                }
                Console.WriteLine();
                Console.WriteLine("If you want to stop program enter 'stop', else enter sth else");
                if (ReadLine() == "stop")
                {
                    isRunning = false;
                }
            }
        }
        static bool CheckIfLinesAreCorrect(string string_line)
        {
            if (string_line.Length == 7)
            {
                if (char.IsLetter(string_line[0]))
                {
                    int counter = 1;
                    for (int j = 1; j <= 4; j++)
                    {
                        if (char.IsNumber(string_line[j]))
                        {
                            counter++;
                            if (counter == 4)
                            {
                                if (char.IsLetter(string_line[5]) && char.IsLetter(string_line[6]))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return false;
        }
        static void PrintArray(string[] myArr)
        {
            for (int i = 0; i < myArr.Length; i++)
            {
                Console.WriteLine(myArr[i]);
            }
            Console.WriteLine();
        }
        static string[] MySort (string[] myArr)
        {
            string[] sortedArr = new string[myArr.Length];
            Array.Copy(myArr, sortedArr, myArr.Length);
            bool sorted = false;
            for (int j = 1; j < sortedArr.Length; j++)
            {
                for (int i = 0; i < sortedArr.Length - j; i++)
                {
                    int counter = 0;
                    if (sortedArr[i][counter] < sortedArr[i + 1][counter])
                    {
                        string tmp = sortedArr[i];
                        sortedArr[i] = sortedArr[i + 1];
                        sortedArr[i + 1] = tmp;
                        counter++;
                    }
                    else if (sortedArr[i][counter] == sortedArr[i + 1][counter])
                    {
                        while (!sorted)
                        {
                            if (counter < 6)
                            {
                                counter++;
                                if (sortedArr[i][counter] > sortedArr[i + 1][counter])
                                {
                                    sorted = true;
                                    continue;
                                }
                                else if (sortedArr[i][counter] < sortedArr[i + 1][counter])
                                {
                                    string tmp = sortedArr[i];
                                    sortedArr[i] = sortedArr[i + 1];
                                    sortedArr[i + 1] = tmp;
                                    sorted = true;
                                }
                            }
                            else
                            {
                                sorted = true;
                            }
                        }
                        sorted = false;
                    }
                    
                }
            }
            return sortedArr;
        }
        
    }
}
