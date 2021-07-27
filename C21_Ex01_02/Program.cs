using System;
using System.Text;

namespace C21_Ex01_02
{
    public static class Program
    {
        public static void Main()
        {
            RunSandMachine(5);
        }

        public static void RunSandMachine(int i_Height)
        {
            StringBuilder stringBuilder = new StringBuilder();
            runSandMachineRecursive(i_Height, stringBuilder);
        }

        private static void runSandMachineRecursive(int i_Height,
            StringBuilder i_StringBuilder)
        {
            if (i_Height == 0)
            {
                return;
            }

            if (i_Height < 0)
            {
                i_Height = -i_Height;
            }

            if (i_Height % 2 == 0)
            {
                i_Height++;
            }

            if (i_Height == 1)
            {
                Console.Out.Write("*");
            }
            else
            {
                runSandMachineRecursiveElseBranch(i_Height, i_StringBuilder);
            }
        }

        private static void runSandMachineRecursiveElseBranch(int i_Height,
            StringBuilder i_StringBuilder)
        {
            drawSandMachineLine(i_Height);
            Console.Out.Write(Environment.NewLine);

            i_StringBuilder.Append(" ");

            Console.Out.Write(i_StringBuilder);
            runSandMachineRecursive(i_Height - 2, i_StringBuilder);
            Console.Out.Write(Environment.NewLine);

            i_StringBuilder.Length--;

            Console.Out.Write(i_StringBuilder);
            drawSandMachineLine(i_Height);
        }

        private static void drawSandMachineLine(
            int i_HowManyStarsInThisLine)
        {
            for (int i = 0; i < i_HowManyStarsInThisLine; i++)
            {
                Console.Out.Write("*");
            }
        }
    }
}
