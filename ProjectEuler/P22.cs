using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    public class P22 : IProblem
    {
        public void Solution()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            List<string> names = new List<string>();

            while(N-- > 0)
            {
                names.Add(Console.ReadLine());
            }

            names.Sort();
            Dictionary<string, long> scores = new Dictionary<string, long>();
            for (long i = 0; i < names.Count; i++)
            {
                long scr = 0;
                string name = names[(int)i];
                foreach (var item in name)
                {
                    scr += (item - 'A' + 1);
                }
                scores.Add(name, scr * (i+1));
            }
            int Q = Convert.ToInt32(Console.ReadLine());
            while (Q-- > 0)
            {
                Console.WriteLine(scores[Console.ReadLine()]);
            }



        }
    }

}

