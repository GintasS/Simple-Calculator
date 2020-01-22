using NCalc;
using System.Windows.Forms;

namespace Calculator
{
    // Class, that will handle the calculation of results/display of the result.
    public static class ResultsManager
    {    
        public static string Calculate(string input)
        {
            string answer = string.Empty;

            try
            {
                answer = new Expression(input).Evaluate().ToString();
            }
            catch
            {
                answer = Constants.Exception.InvalidInput;
            }

            return answer;
        }

        // Display results(called on equals/main action buttons).
        public static string GetDisplayResults(string input)
        {
            Form1.IsMathOperationActive = false;

            input = ConvertDisplaySymbols(input);
            input = UserInput.RemoveIllegalUserInput(input);

            var answer = Calculate(input);
            answer = DetectIllegalAnswers(answer);

            input = ConvertDisplaySymbols(input, true);
            HistoryManager.AddItem(input, answer);

            if (char.IsLetter(answer[0]))
            {
                MessageBox.Show(answer);

                return Constants.DefaultDisplayValue;
            }

            return answer;
        }

        // Converts display symbols('÷', '×' } for normal ones that Ncalc can interpret.
        // Can also convert backwards, in order to display properly in history box.
        public static string ConvertDisplaySymbols(string input, bool reverseDirection = false)
        {
            foreach (var keyValuePair in Constants.ReplacableSymbols)
            {
                if (reverseDirection)
                {
                    input = input.Replace(keyValuePair.Value, keyValuePair.Key);
                }
                else
                {
                    input = input.Replace(keyValuePair.Key, keyValuePair.Value);
                }
            }

            return input;
        }

        public static string DetectIllegalAnswers(string answer)
        {
            // Check if our answer contains illegal answers, such as NaN or infinity.
            if (Constants.IllegalAnswers.ContainsKey(answer))
            {
                return Constants.IllegalAnswers[answer];
            }

            return answer;
        }



    }
}