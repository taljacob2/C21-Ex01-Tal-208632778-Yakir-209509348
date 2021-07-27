using System;

namespace C21_Ex01_03
{
    internal static class Program
    {
        public static void Main()
        {
            inputIntAndRunSandMachine();
        }

        private static void inputIntAndRunSandMachine()
        {
            Console.Out.WriteLine("Please input a number: (sign ignored)");

            if (!int.TryParse(Console.ReadLine(), out int height))
            {
                Console.Out.WriteLine("Bad format...");
                inputIntAndRunSandMachine();
                return;
            }

            C21_Ex01_02.Program.RunSandMachine(height);
        }
    }
}
