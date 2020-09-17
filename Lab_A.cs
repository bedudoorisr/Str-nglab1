using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab_A
{
    class Program
    {
        public static void Main()
        {
            int[] indexValue = new int[2];
            string[] strValue = new string[3];
            List<string> lstSameStartAndEndValue = new List<string>();
            List<string> lstNonDigitValue = new List<string>();
            List<string> lstFinalValue = new List<string>();
            Console.Write("Enter your input: ");
            string Value = Console.ReadLine();
            Console.Write("\n");
            Char[] chValue = Value.ToCharArray();

            //adding values with same starting and ending digits to list.
            for (int i = 0; i < Value.Length; i++)
            {
                for (int j = i + 1; j < Value.Length; j++)
                {
                    if (chValue[i] == chValue[j])
                    {
                        int length = j - i + 1;
                        string subVal = Value.Substring(i, length);
                        lstSameStartAndEndValue.Add(subVal);
                    }
                }
            }

            //removing non-digits and adding to the list.
            foreach (string val in lstSameStartAndEndValue)
            {
                if (val.All(char.IsDigit))
                {
                    lstNonDigitValue.Add(val);
                }
            }

            //using regex to add value to the list having first digit less than 3 times.
            foreach (string val in lstNonDigitValue)
            {
                int count = Regex.Matches(val, val[0].ToString()).Count;
                if (count < 3)
                {
                    lstFinalValue.Add(val);
                }

            }


            //adding color and reshapign it to the expected format.
            for (int i = 0; i < lstFinalValue.Count; i++)
            {
                string val = lstFinalValue[i];
                int res = IsSubstring(val, Value);
                indexValue[0] = res;
                indexValue[1] = res + val.Length;
                Program objProgram = new Program();
                objProgram.Color_Value(Value, indexValue, val);
            }


            // total 
            var total = lstFinalValue.Sum(x => Convert.ToInt64(x));
            if (total != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe sum of your string is " + total);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
                Console.WriteLine("\nThe sum of your string is " + total);
            Console.ReadLine();
        }

        private void Color_Value(string line, int[] markers, string val)
        {
            string input = line;
            const string tokenToSplitBy = "~";
            int insertionCount = 0;

            foreach (int index in markers)
                line = line.Insert(index + insertionCount++, tokenToSplitBy);

            string[] resultArray = line.Split(new[] { tokenToSplitBy }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string result in resultArray)
            {

                if (result.Equals(val))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(result);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                    Console.Write(result);
            }
            Console.WriteLine("\n");
        }

        private static int IsSubstring(string strOutValue, string strValue)
        {
            int M = strOutValue.Length;
            int N = strValue.Length;

            for (int i = 0; i <= N - M; i++)
            {
                int j;
                for (j = 0; j < M; j++)
                    if (strValue[i + j] != strOutValue[j])
                        break;

                if (j == M)
                {
                    return i;
                }
            }

            return -1;
        }

    }
}
