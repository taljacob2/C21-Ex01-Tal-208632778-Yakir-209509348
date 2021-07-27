using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace C21_Ex01_04
{
    internal class Program
    {
        public static void StringAnalysis(in string i_String)
        {
            if (isContainingOnlyEnglishLetters(i_String))
            {
                int amountOfUpperCase = i_String.Count(char.IsUpper);

                Console.WriteLine(
                    $"Amount of uppercase characters: {amountOfUpperCase}");
                Console.WriteLine(
                    IsPalindrome(i_String)
                        ? "The string is a palindrome."
                        : "The string is not a palindrome.");
            }
            else
            {
                bool isModuleOf4 = int.Parse(i_String) % 4 == 0;

                Console.WriteLine(isModuleOf4
                    ? "The Number is a module of 4."
                    : "The string is not a module of 4.");
            }
        }

        public static string GetValidInput()
        {
            bool isInputValid = false;
            string userInput;

            do
            {
                Console.WriteLine(
                    "Rules: Letters or a number only, Length must be 8 chars.");
                Console.Write("Please enter a 8 char string : ");
                userInput = Console.ReadLine();
                if (userInput is { Length: 8 })
                {
                    bool isInputNumeric = int.TryParse(userInput, out int _);
                    isInputValid = isContainingOnlyEnglishLetters(userInput) ||
                                   isInputNumeric;
                }

                if (!isInputValid)
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            } while (!isInputValid);

            return userInput;
        }

        public static bool IsPalindrome(in string i_String)
        {
            return i_String.Length == 0 ||
                   isPalRec(i_String, 0, i_String.Length - 1);
        }

        private static bool isPalRec(in string i_String, int i_LeftIndex,
            int i_RightIndex)
        {
            bool returnValue = true;

            // If first and last character do not match.
            if (i_String[i_LeftIndex] != i_String[i_RightIndex])
            {
                returnValue = false;
            }

            // If there are more than two characters,
            // check if middle substring is also palindrome or not.
            else if (i_LeftIndex < i_RightIndex + 1)
            {
                returnValue = isPalRec(i_String, i_LeftIndex + 1,
                    i_RightIndex - 1);
            }

            return returnValue;
        }

        private static bool isContainingOnlyEnglishLetters(in string i_String)
        {
            return Regex.IsMatch(i_String, "^[a-zA-Z]*$");
        }

        public static void Main(string[] i_Args)
        {
            string input = GetValidInput();
            StringAnalysis(input);
        }
    }
}
