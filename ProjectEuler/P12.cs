using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    public class P12 : IProblem
    {
        private static Dictionary<int, int> NumOfDivisors = new Dictionary<int, int> { { 1, 1 } };
        public void Solution()
        {
            int T = Convert.ToInt32(Console.ReadLine());

            while (T-- > 0)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                int triNo = 0;
                for (int i = 1; ; i++)
                {
                    triNo += i;
                    if(this.CountDivisors(triNo) > N)
                    {
                        Console.WriteLine(triNo);
                        break;
                    }
                }
            }
        }
        public int CountDivisors(int num)
        {
            if (NumOfDivisors.ContainsKey(num))
            {
                return NumOfDivisors[num];
            }

            int count = 2;
            int end = (int)Math.Sqrt(num) ;
            for (int i = 2; i <= end; i++)
            {
                if (num % i == 0)
                {
                    count++;
                    count++;
                }
            }
            if (end * end == num)
                count--;
            NumOfDivisors.Add(num, count);
            return count;
        }
    }
}

