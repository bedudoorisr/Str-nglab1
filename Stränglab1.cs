using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Type in a string:");

            string input = Console.ReadLine();
            long sum = 0;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsNumber(input, i))
                {

                    char bookend = input[i];
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (!Char.IsNumber(input, j))
                        {
                            break;
                        }
                        if (input[j] == bookend)
                        {
                            string pre = input.Substring(0, i);
                            string mid = input.Substring(i, j - i + 1);
                            string end = input.Substring(j + 1, input.Length - j - 1);

                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(pre);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(mid);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine(end);

                            try
                            {
                                sum += long.Parse(mid);
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("The calculator ran in to a problem due to the size of the number. \n Please press any key and try again with a string with smaller amount of numbers");
                                Console.ReadKey();
                                Main(null);
                            }
                            break;
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"The sum of your string is: {sum}");
            Console.WriteLine("Do you want to do it again? Type [Y] Yes, [N] No");

            string userAgain = Console.ReadLine().ToUpper();
            while (true)
            {
                if (userAgain == "Y")
                {

                    Main(null);

                }
                else if (userAgain == "N")
                {
                    Console.WriteLine("Goodbye! Press any key to exit.");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("You have entered an option that does not correspond to either alternative. Do you want to do it again? Type [Y] Yes, [N] No");
                    userAgain = Console.ReadLine().ToUpper();
                }
            }
        }
    }
}