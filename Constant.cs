namespace Calculator
{
    // Class, that holds all the constant values.
    sealed class Constant
    {
        // Const value for all the number buttons (0-9) and plus dot button.
        public static int NumberCount { get => 11; }
        
        // Exception if our mathemtical expression parsing went wrong.
        public static string CalculatorException { get => "Invalid input!"; }

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

        private Constant() {}
    }
}