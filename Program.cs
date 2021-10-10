using System;

using static System.Console;

namespace functions_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Clear();
            WriteLine("\nFunctions:\n");
            // RunTimesTable();
            // RunCalculateTax();
            // RunCardinalToOrdinal();
            // RunFactorial();
            
            double a = 4.5; // or use var
            double b = 2.5;
            double answer = Add(a, b);
            WriteLine($"{a} + {b} = {answer}");
            ReadLine(); // wait for user to press ENTER
        }

        static void TimesTable(byte number)
        {
            WriteLine($"This is the {number} times table:");
            for (int row = 1; row <= 12; row++)
            {
                WriteLine(
                $"{row} x {number} = {row * number}");
            }
            WriteLine();
        }

        static void RunTimesTable()
        {
            bool isNumber;
            do
            {
                Write("Enter a number between 0 and 255: ");
                isNumber = byte.TryParse(ReadLine(), out byte number);
                if (isNumber)
                {
                    TimesTable(number);
                }
                else
                {
                    WriteLine("You did not enter a valid number!");
                }
            }
            while (isNumber);
        }

        static decimal CalculateTax(decimal amount, string twoLetterRegionCode) =>
            // switch (twoLetterRegionCode.ToUpper())
            // {
            //     case "CH": // Switzerland
            //         rate = 0.08M;
            //         break;
            //     case "DK": // Denmark
            //     case "NO": // Norway
            //         rate = 0.25M;
            //         break;
            //     case "GB": // United Kingdom
            //     case "UK": // United Kingdom
            //     case "FR": // France
            //         rate = 0.2M;
            //         break;
            //     case "HU": // Hungary
            //         rate = 0.27M;
            //         break;
            //     case "OR": // Oregon
            //     case "AK": // Alaska
            //     case "MT": // Montana
            //         rate = 0.0M; break;
            //     case "ND": // North Dakota
            //     case "WI": // Wisconsin
            //     case "ME": // Maryland
            //     case "VA": // Virginia
            //         rate = 0.05M;
            //         break;
            //     case "CA": // California
            //         rate = 0.0825M;
            //         break;
            //     default: // most US states
            //         rate = 0.06M;
            //         break;
            // }
            amount * twoLetterRegionCode.ToUpper() switch
            {
                "CH" => 0.08M,
                "HU" => 0.27M,
                "DK" or "NO" => 0.25M,
                "GB" or "UK" or "FR" => 0.2M,
                "AK" or "OR" or "MT" => 0.0M,
                "ND" or "WI" or "ME" or "VA" => 0.05M,
                "CA" => 0.0825M,
                _ => 0.06M
            };

        static void RunCalculateTax()
        {
            Write("Enter an amount: ");
            string amountInText = ReadLine();
            Write("Enter a two-letter region code: ");
            string region = ReadLine();
            if (decimal.TryParse(amountInText, out decimal amount))
            {
                decimal taxToPay = CalculateTax(amount, region);
                WriteLine($"You must pay {taxToPay} in sales tax.");
            }
            else
            {
                WriteLine("You did not enter a valid amount!");
            }
        }

        /// <summary>
        /// Pass a 32-bit integer and it will be converted into its ordinal equivalent.
        /// </summary>
        /// <param name="number">Number is a cardinal value e.g. 1, 2, 3, and so on.</param>
        /// <returns>Number as an ordinal value e.g. 1st, 2nd, 3rd, and so on.</returns>
        static string CardinalToOrdinal(int number) =>
        number switch
        {
            >= 11 and <= 13 => $"{number}th",
            _ => number.ToString()[number.ToString().Length - 1] switch
            {
                '1' => $"{number}st",
                '2' => $"{number}nd",
                '3' => $"{number}rd",
                _ => $"{number}th"
            }
        };

        static void RunCardinalToOrdinal()
        {
            for (int number = 1; number <= 120; number++)
            {
                Write($"{CardinalToOrdinal(number)} ");
            }
            WriteLine();
        }

        static int Factorial(int number)
        {
            if (number < 1)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }

        static void RunFactorial()
        {
            bool isNumber;
            do
            {
                Write("Enter a number: ");
                isNumber = int.TryParse(
                ReadLine(), out int number);
                if (isNumber)
                {
                    WriteLine(
                    $"{number:N0}! = {Factorial(number):N0}");
                }
                else
                {
                    WriteLine("You did not enter a valid number!");
                }
            }
            while (isNumber);
        }

        static double Add(double a, double b)
        {
            return a * b; // deliberate bug!
        }
    }
}

