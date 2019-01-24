namespace Calculator
{
    // Class, that holds all the constant values.
    static class Constant
    {
        // Const value for all the number buttons (0-9) and plus dot button.
        public static int NumberCount { get => 11; }
        
        // Decimal format to display numbers.
        public static string DecimalFormat { get => "G20"; }

        // Mathematical symbols.
        public readonly static string[] MathSymbols = new string[]
        {
            "%", "÷", "×", "-", "+", "=", "*", "/"
        };

        // Possible button types.
        public readonly static string[] ButtonTypes = new string[]
        {
            "action", "number"
        };

        // Allowed symbols in input.
        public readonly static char[] AllowedSymbols = new char[]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            '%', '÷', '×', '-', '+', '=', '*', '/', '.', ' ',
            '(', ')'
        };

        // Regex pattern to sanitize paste data.
        public static string RegexIllegalSymbols
        {
            get => @"[^0-9%÷×\-\+=\*/. ()]";
        }

        // Calculator exceptions that we are going to display.
        public readonly static string[] CalculatorExceptions = new string[]
        {
            "Invalid input!", "Cannont divide by zero!"
        };

        // Illegal calculator results.
        public readonly static string[][] IllegalResults = new string[][]
        {
            new string[] {"NaN", CalculatorExceptions[0] },
            new string[] {"∞", CalculatorExceptions[1] }
        };

        // Symbol that is used to detect if we got an exception from a method.
        public static string ExceptionSymbol { get => "!"; }
        
        // Enum for MathSymbols.
        public enum Symbol
        {
            Percentage, Divide, Multiply, Subtract, Add, Equals,
            MultiplyMath, DivideMath
        };

        // Enum for ButtonTypes.
        public enum ButtonType
        {
            Action, Number
        };
    }
}