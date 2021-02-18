using System;

namespace Zadanie1
{
    class Program
    {
        private const char sym1 = '>';
        private const char sym2 = '#';
        private const int numberOfRepeat = 20;

        static void Main(string[] args)
        {
            int numberOfLine = getNumberOfLines();

            WriteFirstTypeLines(numberOfLine);
            WriteSecondTypeLines(numberOfLine);
        }

        private static int getNumberOfLines()
        {
            return numberOfRepeat / 2;
        }

        private static void WriteSecondTypeLines(int numberOfRepeat)
        {
            for (int i = 0; i < numberOfRepeat / 2; i++)
            {
                WriteSecondTypeLine();
            }
        }

        private static void WriteFirstTypeLines(int numberOfRepeat)
        {
            for (int i = 0; i < numberOfRepeat / 2; i++)
            {
                WriteFirstTypeLine();
            }
        }

        private static void WriteFirstTypeLine()
        {
            WriteSymbol(sym1, numberOfRepeat);
            WriteSymbol(sym2, numberOfRepeat);
            WriteEndline();
        }

        private static void WriteSecondTypeLine()
        {
            WriteSymbol(sym2, numberOfRepeat);
            WriteSymbol(sym1, numberOfRepeat);
            WriteEndline();
        }

        static void WriteSymbol(Char symbol, int times)
        {
            for (int j = 0; j < times; j++)
            {
                Console.Write(symbol);
            }
        }

        static void WriteEndline()
        {
            Console.WriteLine();
        }
    }
}
