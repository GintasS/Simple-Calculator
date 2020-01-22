using System.Collections.Generic;

namespace Calculator
{
    // Class, that holds all the constant values.
    public struct Constants
    {
        // All symbols(both mathematical and normal ones) used in this application.
        public struct Symbol
        {
            public static char Percentage = '%';
            public static char DivisionDisplay = '÷';
            public static char DivisionMath = '/';
            public static char MultiplicationDisplay = '×';
            public static char MultiplicationMath = '*';
            public static char Subtraction = '-';
            public static char Addition = '+';
            public static char Equals = '=';
            public static string Fraction = "1/";
            public static string NaN = "NaN";
            public static char Infinity = '∞';
            public static char Space = ' ';
            public static char Dot = '.';
        }

        public struct Exception
        {
            public static string InvalidInput = "Invalid input!";
            public static string DivideByZero = "Cannont divide by zero!";
        }

        public struct Regex
        {
            public static string MissingFloatValue = @"[.]+(.[^0-9 ]+)?";
        }


        // Symbols, that we'll need to replace in order for Ncalc to work.
        public readonly static Dictionary<char, char> ReplacableSymbols = new Dictionary<char, char>()
        {
            { '÷', '/' },
            { '×', '*' },
        };

        // Ncalc answers, that we're going to replace with meaningful text.
        public readonly static Dictionary<string, string> IllegalAnswers = new Dictionary<string, string>()
        {
            { Symbol.Infinity.ToString(), Exception.DivideByZero },
            { Symbol.NaN, Exception.InvalidInput },
        };

        // Calculator will have 0 as a starting/default value.
        public static string DefaultDisplayValue = "0";
        public static string ZeroFloatValue = ".0";



    }
}