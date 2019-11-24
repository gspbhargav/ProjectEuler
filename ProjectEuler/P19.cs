using System;

namespace ProjectEuler
{

    public class P19 : IProblem
    {
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
                if (startYearL < endYearL)
                {
                    if (startDay != 1)
                    {
                        startMonth++;
                    }
                    for (int i = startMonth; i <= 12; i++)
                    {
                        if (IsSunday(startYear, i, 1))
                        {
                            totalSundays++;
                        }
                    }
                    startYear++;

                    for (int i = 1; i <= endMonth; i++)
                    {
                        if (IsSunday(endYear, i, 1))
                        {
                            totalSundays++;
                        }
                    }
                    endYear--;

                    for (long i = startYear; i <= endYear; i++)
                    {
                        for (int j = 1; j <= 12; j++)
                        {
                            if (IsSunday(i, j, 1))
                            {
                                totalSundays++;
                            }
                        }
                    }
                }
                else if (startYear == endYear)
                {
                    if (startMonth < endMonth)
                    {
                        if (startDay != 1)
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
                    else if (startMonth == endMonth)
                    {
                        if (startDay == 1)
                        {
                            if (IsSunday(startYear, startMonth, 1))
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
}
