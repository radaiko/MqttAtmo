using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netatmo
{
    public static class Utils
    {
        public static int GetAllNumberFromString(string input)
        {
            string b = string.Empty;
            int val;

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                    b += input[i];
            }

            if (b.Length > 0)
            {
                val = int.Parse(b);
                return val;
            }
            return 0;
        }
        public static string GetAllLetterFromString(string input)
        {
            string b = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsDigit(input[i]))
                    b += input[i];
            }

            if (b.Length > 0)
                return b;
            return "";
        }
    }
}
