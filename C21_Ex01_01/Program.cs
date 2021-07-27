using System;
using System.Linq;

namespace C21_Ex01_01
{
    internal static class Program
    {
        private static (double, double) getAverageOfZerosAndOnes(
            in string[] i_BinaryStrings)
        {
            double sumOfZeros = 0;
            double sumOfOnes = 0;

            foreach (string binaryString in i_BinaryStrings)
            {
                int amountOfZeros = binaryString.Count(i_Char => i_Char == '0');
                sumOfZeros += amountOfZeros;
                sumOfOnes += binaryString.Length - amountOfZeros;
            }

            return (sumOfZeros / i_BinaryStrings.Length,
                sumOfOnes / i_BinaryStrings.Length);
        }

        private static string binaryStringToDecimalString(in string i_String)
        {
            uint number = 0;

            for (int i = i_String.Length - 1; i >= 0; i--)
            {
                int power = i_String.Length - 1 - i;

                if (i_String[i] == '1')
                {
                    number += Convert.ToUInt32(Math.Pow(2, power));
                }
            }

            return number.ToString();
        }

        private static void getStatisticsAndPrintResults(
            in string[] i_BinaryStrings)
        {
            (double averageOfZeros, double averageOfOnes) =
                getAverageOfZerosAndOnes(i_BinaryStrings);

            string[] decimalNumberStrings = i_BinaryStrings
                .Select(i_BinaryString =>
                    binaryStringToDecimalString(i_BinaryString)).ToArray();

            getAmountOfPowerOf2(decimalNumberStrings, out int amountPowerOf2);

            getAmountOfAscendingNumbers(decimalNumberStrings,
                out int amountOfAscendingNumbers);

            printResults(averageOfZeros, averageOfOnes, amountPowerOf2,
                amountOfAscendingNumbers, decimalNumberStrings);
        }

        private static void getAmountOfPowerOf2(string[] i_DecimalNumberStrings,
            out int o_amountPowerOf2)
        {
            o_amountPowerOf2 = 0;

            foreach (string number in i_DecimalNumberStrings)
            {
                bool isPowerOf2 = Math.Log(int.Parse(number), 2) % 1 == 0;

                if (isPowerOf2)
                {
                    o_amountPowerOf2++;
                }
            }
        }

        private static void getAmountOfAscendingNumbers(
            string[] i_NumbersInDecimalStrings,
            out int o_AmountOfAscendingNumbers)
        {
            o_AmountOfAscendingNumbers = 0;

            foreach (string currentNumber in i_NumbersInDecimalStrings)
            {
                int i = 0;

                for (; i < currentNumber.Length - 1; i++)
                {
                    if (currentNumber[i] >= currentNumber[i + 1])
                    {
                        break;
                    }
                }

                if (i == currentNumber.Length - 1)
                {
                    o_AmountOfAscendingNumbers++;
                }
            }
        }

        private static void printResults(double i_AverageOfZeros,
            double i_AverageOfOnes, int i_AmountPowerOf2,
            int i_AmountOfAscendingNumbers, string[] i_DecimalNumberStrings)
        {
            Console.WriteLine(
                $"Average of zeros: {i_AverageOfZeros}, average of ones: {i_AverageOfOnes}");
            Console.WriteLine(
                $"Amount of power of 2 numbers in the input: {i_AmountPowerOf2}");
            Console.WriteLine(
                $"Amount of ascending series in the input is: {i_AmountOfAscendingNumbers}");
            Console.WriteLine(
                $"Max value in the input is: {i_DecimalNumberStrings.Max()}," +
                $" Min value in the input is: {i_DecimalNumberStrings.Min()}");
        }

        private static string[] getValidBinaryInput()
        {
            string[] inputs = new string[3];

            for (int i = 0; i < 3; i++)
            {
                bool isInputValid = false;
                string userInput;

                do
                {
                    Console.Write("Please enter a 9 bit binary number: ");
                    userInput = Console.ReadLine();
                    isInputValid = userInput?.Length == 9 &&
                                   userInput.All(i_Letter =>
                                       i_Letter == '0' || i_Letter == '1');
                    if (!isInputValid)
                    {
                        Console.WriteLine("Invalid input, try again.");
                    }
                } while (!isInputValid);

                inputs[i] = userInput;
            }

            return inputs;
        }

        public static void Main()
        {
            getStatisticsAndPrintResults(getValidBinaryInput());
        }
    }
}
