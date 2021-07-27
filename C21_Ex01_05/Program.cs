using System;
using System.Linq;

namespace C21_Ex01_05
{
    public class Program
    {
        public static string GetValidInput()
        {
            bool isInputValid = false;
            string userInput;

            do
            {
                Console.WriteLine(
                    "Rules: Numeric letters only, Length must be 9.");
                Console.Write("Please enter a 9 char number : ");
                userInput = Console.ReadLine();
                if (userInput is { Length: 9 })
                {
                    bool isInputNumeric = int.TryParse(userInput, out int _);
                    isInputValid = isInputNumeric;
                }

                if (!isInputValid)
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            } while (!isInputValid);

            return userInput;
        }

        public static void PrintStatistics(in string i_String)
        {
            char max = i_String.Max();
            char min = i_String.Min();
            int countOfCharsInModuleOf3 = i_String.Count(i_Char =>
                int.Parse(i_Char.ToString()) % 3 == 0);
            int units = int.Parse(i_String[i_String.Length - 1].ToString());
            int countOfCharsGreaterThanUnitsNumber = i_String.Count(i_Char =>
                int.Parse(i_Char.ToString()) > units);

            Console.WriteLine("Biggest number in the string: {0}", max);
            Console.WriteLine("Smallest number in the string: {0}", min);
            Console.WriteLine("Amount of chars in the module of 3: {0}",
                countOfCharsInModuleOf3);
            Console.WriteLine("Amount of chars greater than units number: {0}",
                countOfCharsGreaterThanUnitsNumber);
        }

        public static void Main(string[] i_Args)
        {
            string input = GetValidInput();
            PrintStatistics(input);
        }
    }
}
