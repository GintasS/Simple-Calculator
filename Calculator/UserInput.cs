using System.Text.RegularExpressions;

namespace Calculator
{
    public static class UserInput
    {
        // Replace illegal user input, such as "5 + 5." .
        public static string RemoveIllegalUserInput(string input)
        {
            // If our last symbol is space and user clicked '=', add same number at the end
            // in order for a proper calculation to proceed.
            if (input[input.Length - 1] == Constants.Symbol.Space)
            {
                var number = input.Substring(0, input.IndexOf(Constants.Symbol.Space));
                input = input.Insert(input.Length, number);
            }

            // Replace non valid float value.
            input = Regex.Replace(input, Constants.Regex.MissingFloatValue, Constants.ZeroFloatValue);

            return input;
        }



    }
}
