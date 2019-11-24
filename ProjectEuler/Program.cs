using System;

namespace ProjectEuler
{
    public class Program
    {
        public static void Main(string[] _)
        {
            var o = new P19();
            o.Solution();
            System.Diagnostics.Debugger.Break();
        }
    }

    public class P19 : IProblem
    {
        private struct DTime
        {
            public int Year;
            public int Month;
            public int Day;

            public DTime(int year, int month, int day)
            {
                this.Year = year;
                this.Month = month;
                this.Day = day;
            }

            public DTime NextMonthFirst()
            {
                int y = this.Year;
                int m = this.Month;

                m++;
                if(m == 13)
                {
                    y++;
                    m = 1;
                }
                return new DTime(y, m, 1);
            }

            public bool IsSunday()
            {
                int day = this.Day;
                int month = this.Month;
                int year = this.Year;
                if (month == 1)
                {
                    month = 13;
                    year--;
                }
                if (month == 2)
                {
                    month = 14;
                    year--;
                }
                int q = day;
                int m = month;
                int k = year % 100;
                int j = year / 100;
                int h = q + (13 * (m + 1) / 5) + k + (k / 4) + (j / 4) + (5 * j);
                h %= 7;

                return h == 1;
            }
        }

        //public void Solution()
        //{
        //    //Calendar repeats every 28 years
        //    int T = Convert.ToInt32(Console.ReadLine());
        //    for (int j = 0; j < T; j++)
        //    {
        //        string[] startStr = Console.ReadLine().Split(' ');
        //        string[] endStr = Console.ReadLine().Split(' ');
        //        long startYear = Convert.ToInt64(startStr[0]);
        //        long endYear = Convert.ToInt64(endStr[0]);
        //        long dif = endYear - startYear;
        //        startYear = startYear % 28 + 1900;
        //        endYear = startYear + dif;

        //        DTime start = new DTime(
        //            (int)startYear,
        //            Convert.ToInt32(startStr[1]),
        //            Convert.ToInt32(startStr[2]));
        //        DTime end = new DTime(
        //            (int)endYear,
        //            Convert.ToInt32(endStr[1]),
        //            Convert.ToInt32(endStr[2]));

        //        //var diff = end.Year - start.Year;
        //        //start = new DTime(start.Year % 28 + 1900, start.Month, start.Day);
        //        //end = new DTime(start.Year + diff, end.Month, end.Day);

        //        int totalSundays = 0;
        //        if (start.IsSunday())
        //            totalSundays++;
        //        start = start.NextMonthFirst();

        //        while (start.Year < end.Year)
        //        {
        //            if (start.IsSunday())
        //                totalSundays++;
        //            start = start.NextMonthFirst();
        //        }
        //        //now start and end are in the same year
        //        while(start.Month <= end.Month)
        //        {
        //            if (start.IsSunday())
        //                totalSundays++;
        //            start = start.NextMonthFirst();
        //        }

        //        Console.WriteLine(totalSundays);
        //    }
        //}

        public bool IsSunday(long year, int month, int day)
        {
            if (month == 1)
            {
                month = 13;
                year--;
            }
            if (month == 2)
            {
                month = 14;
                year--;
            }
            int q = day;
            int m = month;
            int k = (int)(year % 100);
            long j = (year / 100);
            long h = q + (13 * (m + 1) / 5) + k + (k / 4) + (j / 4) + (5 * j);
            h %= 7;

            return h == 1;
        }
        public void Solution()
        {
            //Calendar repeats every 28 years
            int T = Convert.ToInt32(Console.ReadLine());
            for (int _ = 0; _ < T; _++)
            {
                string[] startStr = Console.ReadLine().Split(' ');
                string[] endStr = Console.ReadLine().Split(' ');
                long startYearL = Convert.ToInt64(startStr[0]);
                long endYearL = Convert.ToInt64(endStr[0]);
                int startMonth = Convert.ToInt32(startStr[1]);
                int startDay = Convert.ToInt32(startStr[2]);
                int endMonth = Convert.ToInt32(endStr[1]);
                int endDay = Convert.ToInt32(endStr[2]);

                long startYear = startYearL;
                long endYear = endYearL;

                int totalSundays = 0;
                if(startYearL < endYearL)
                {
                    if(startDay != 1)
                    {
                        startMonth++;
                    }
                    for (int i = startMonth; i <= 12; i++)
                    {
                        if(IsSunday(startYear, i, 1))
                        {
                            totalSundays++;
                        }
                    }
                    startYear++;

                    for (int i = 1; i <= endMonth; i++)
                    {
                        if(IsSunday(endYear, i, 1))
                        {
                            totalSundays++;
                        }
                    }
                    endYear--;

                    for (int i = startYear; i <= endYear; i++)
                    {
                        for (int j = 1; j <= 12; j++)
                        {
                            if(IsSunday(i, j, 1))
                            {
                                totalSundays++;
                            }
                        }
                    }
                }
                else if(startYear == endYear)
                {
                    if(startMonth < endMonth)
                    {
                        if(startDay != 1)
                        {
                            startMonth++;
                        }
                        for (int i = startMonth; i <= endMonth; i++)
                        {
                            if (IsSunday(startYear, i, 1))
                            {
                                totalSundays++;
                            }
                        }
                    }
                    else if(startMonth == endMonth)
                    {
                        if (startDay == 1)
                        {
                            if(IsSunday(startYear, startMonth, 1))
                            {
                                totalSundays++;
                            }
                        }
                    }
                }
                

                Console.WriteLine(totalSundays);
            }
        }
    }

    public interface IProblem
    {
        void Solution();
    }
}
