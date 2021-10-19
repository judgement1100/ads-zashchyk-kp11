using System;
using static System.Console;
using static System.Convert;
namespace ex2
{
    class ex2
    {
        static bool isLeapYear(int year)
        {
            return (year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0));
        }
        static int GetRemainingDaysInYear(int month, int day, bool isLeapYear)
        {
            int[] daysUpToMonth = new int[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
            int[] daysUpToMonthLeapYear = new int[] { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335 };
            if (isLeapYear)
            {
                return 366 - (daysUpToMonthLeapYear[month - 1] + day);
            }
            else
            {
                return 365 - (daysUpToMonth[month - 1] + day);
            }
        }
        static int GetDaysInYearTillDate(int month, int day, bool isLeapYear)
        {
            int[] daysUpToMonth = new int[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
            int[] daysUpToMonthLeapYear = new int[] { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335 };
            if (isLeapYear)
            {
                return daysUpToMonthLeapYear[month - 1] + day;
            }
            else
            {
                return daysUpToMonth[month - 1] + day;
            }
        }
        static int GetDiffInDaysInSameYear(int month1, int day1, int month2, int day2, bool isLeapYear)
        {
            int[] daysUpToMonth = new int[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
            int[] daysUpToMonthLeapYear = new int[] { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335 };
            if (isLeapYear)
            {
                return daysUpToMonthLeapYear[month2 - 1] - daysUpToMonthLeapYear[month1 - 1] + (day2 - day1);
            }
            else
            {
                return daysUpToMonth[month2 - 1] - daysUpToMonth[month1 - 1] + (day2 - day1);
            }
        }
        static bool IsDate1AfterDate2(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            if (y1 > y2)
            {
                return true;
            }
            else
                return false;
        }
        static bool IsCorrectDate(int day, int month, int year)
        {
            if ((month == 1) || (month == 3) || (month == 5) || (month == 7) || (month == 8) || (month == 10) || (month == 12))
            {
                if (day <= 31)
                {
                    return true;
                }
                else
                    return false;
            }
            if ((month == 4) || (month == 6) || (month == 9) || (month == 11))
            {
                if (day <= 30)
                {
                    return true;
                }
                else
                    return false;
            }
            if (month == 2)
            {
                if (isLeapYear(year))
                {
                    if (day <= 29)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    if (day <= 28)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            else
                return false;
        }

        static void Main(string[] args)
        {
            int[] daysUpToMonth = new int[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
            int[] daysUpToMonthLeapYear = new int[] { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335 };
            int d1, m1, y1, d2, m2, y2;
            bool a = true;

            Console.Write("Enter day1: "); d1 = ToInt32(ReadLine());
            Console.Write("Enter month1: "); m1 = ToInt32(ReadLine());
            Console.Write("Enter year1: "); y1 = ToInt32(ReadLine());
            Console.Write("Enter day2: "); d2 = ToInt32(ReadLine());
            Console.Write("Enter month2: "); m2 = ToInt32(ReadLine());
            Console.Write("Enter year2: "); y2 = ToInt32(ReadLine());
            try
            {
                if (!IsCorrectDate(d1, m1, y1) && !IsCorrectDate(d2, m2, y2))
                {
                    Console.WriteLine("Error");
                    a = false;
                    ReadKey();
                    Environment.Exit(0);
                }
                if (y1 == y2)
                {
                    Console.Write(GetDiffInDaysInSameYear(m1, d1, m2, d2, isLeapYear(y1)));
                    Console.WriteLine(" day(s)");
                }
                else
                {
                    bool swappedDates = false;
                    if (IsDate1AfterDate2(d1, m1, y1, d2, m2, y2))
                    {
                        int tmpDay, tmpMonth, tmpYear;
                        tmpDay = d1;
                        tmpMonth = m1;
                        tmpYear = y1;
                        d1 = d2;
                        m1 = m2;
                        y1 = y2;
                        d2 = tmpDay;
                        m2 = tmpMonth;
                        y2 = tmpYear;
                        swappedDates = true;
                    }
                    int resultDays = 0;
                    int yearCounter = 0;                                                              //*****
                    resultDays = GetRemainingDaysInYear(m1, d1, isLeapYear(y1));
                    y1++;
                    while (y1 < y2)
                    {
                        y1++;
                        yearCounter++;
                    }
                    resultDays += GetDaysInYearTillDate(m2, d2, isLeapYear(y2));
                    if (resultDays >= 365)
                    {
                        resultDays -= 365;
                        yearCounter++;
                    }
                    //*****
                    if (swappedDates == false)
                    {
                        resultDays = resultDays * (IsDate1AfterDate2(d1, m1, y1, d2, m2, y2) ? -1 : 1);
                        yearCounter = yearCounter * (IsDate1AfterDate2(d1, m1, y1, d2, m2, y2) ? -1 : 1);
                    }
                    else
                    {
                        resultDays = resultDays * (IsDate1AfterDate2(d1, m1, y1, d2, m2, y2) ? 1 : -1);
                        yearCounter = yearCounter * (IsDate1AfterDate2(d1, m1, y1, d2, m2, y2) ? 1 : -1);
                    }

                    Console.Write(resultDays + "day(s) ");
                    Console.Write(yearCounter + "year(s) ");
                }
                Console.WriteLine();
            }
            catch (Exception err)
            {
                if (a == true)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(err.Message);
                    ReadKey();
                }
            }
            ReadKey();
        }
    }
}
