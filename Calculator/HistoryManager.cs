namespace Calculator
{
    // Class, that handles history box.
    public static class HistoryManager
    {
        public static void AddItem(string input, string answer)
        {
            // Check if our answer contains illegal answers, such as NaN or infinity.
            var history = ResultsManager.DetectIllegalAnswers(answer);

            if (char.IsLetter(answer[0]) == false)
            {
                history = input + Constants.Symbol.Space + Constants.Symbol.Equals + 
                    Constants.Symbol.Space + answer;
            }

            Form1.History.Items.Add(history);
        }



    }
}