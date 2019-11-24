using System;

namespace ProjectEuler
{
    public class P17 : IProblem
    {
        public void Solution()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T-- > 0)
            {
                string N = Console.ReadLine().PadLeft(14, '0');
                //01 Trillion 234 Billion 567 Million 8910 Thousand 111213
                //012 Billion 345 Million 678 Thousand remaining

                string Trillion = Double(N[0].ToString() + N[1]);
                string Billion = Triple(N[2].ToString() + N[3] + N[4]);
                string Million = Triple(N[5].ToString() + N[6] + N[7]);
                string Thousand = Triple(N[8].ToString() + N[9] + N[10]);
                string final = Triple(N[11].ToString() + N[12] + N[13]);
                string toReturn = "";
                if (Trillion != null)
                    toReturn += Trillion + " " + nameof(Trillion) + " ";
                if (Billion != null)
                    toReturn += Billion + " " + nameof(Billion) + " ";
                if (Million != null)
                    toReturn += Million + " " + nameof(Million) + " ";
                if (Thousand != null)
                    toReturn += Thousand + " " + nameof(Thousand) + " ";
                if (final != null)
                    toReturn += final;
                if (toReturn == "")
                    toReturn = "Zero";
                Console.WriteLine(toReturn);

            }
        }
        public static string Triple(string x)
        {
            if (x.Length != 3)
                throw new Exception("expected 3");
            if (x.Equals("000"))
                return null;

            if (x[0] == '0')
                return Double(x[1].ToString() + x[2]);

            return Single(x[0]) + " Hundred " + Double(x[1].ToString() + x[2]);


        }
        public static string Single(char x)
        {
            switch (x)
            {
                case '1': return "One";
                case '2': return "Two";
                case '3':return "Three";
                case '4':return "Four";
                case '5':return "Five";
                case '6':return "Six";
                case '7':return "Seven";
                case '8':return "Eight";
                case '9':return "Nine";
                case '0':return null;
            }
            return null;
        }

        public static string Double(string x)
        {
            if (x.Length != 2)
                throw new Exception("2 expected");
            if (x[0] == '0')
                return Single(x[1]);
            if(x[0] == '1')
            {
                switch (x[1])
                {
                    case '1': return "Eleven";
                    case '2': return "Twelve";
                    case '3': return "Thirteen";
                    case '4': return "Fourteen";
                    case '5': return "Fifteen";
                    case '6': return "Sixteen";
                    case '7': return "Seventeen";
                    case '8': return "Eighteen";
                    case '9': return "Nineteen";
                    case '0': return "Ten";
                }
            }
            if(x[1] == '0')
            {
                switch (x[0])
                {
                    case '1': return "Ten";
                    case '2': return "Twenty";
                    case '3': return "Thirty";
                    case '4': return "Forty";
                    case '5': return "Fifty";
                    case '6': return "Sixty";
                    case '7': return "Seventy";
                    case '8': return "Eighty";
                    case '9': return "Ninety";
                    case '0': return null;
                }
            }
            return Double(x[0] + "0") + " " + Single(x[1]);
        }
    }
}

