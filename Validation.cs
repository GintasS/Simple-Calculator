using System;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using NCalc;

namespace Calculator
{
    // Class, responsible for user input validation.
    static class Validation
    {
        /// <summary>
        /// Method, that tries to parse user input into a mathematical
        /// expression by 2 different ways.
        /// 1 way is by using datatable Compute method.
        /// 2 way is by using external library Ncalc.
        /// </summary>
        /// <param name="input">User input.</param>
        /// <returns>A string of parsed expression or
        /// an exception or a null.
        /// </returns>
        public static string TryUserInput(string input)
        {
            string answer = null;
            try
            {
                DataTable dt = new DataTable();
                answer =  Convert.ToDecimal(dt.Compute(input, 
                    String.Empty)).ToString(Constant.DecimalFormat);
            }
            catch
            {
                try
                {
                    Expression exps = new Expression(input);
                    answer = exps.Evaluate().ToString();
                }
                catch
                {                    
                    return Constant.CalculatorExceptions[0];
                }
            }
            return FindIllegalResults(answer) ?? answer;
        }

        /// <summary>
        /// Method, that detects if the result from the 
        /// mathematical expression is valid.
        /// </summary>
        /// <param name="input">Mathematical result to find from.</param>
        /// <returns>String or null.</returns>
        private static string FindIllegalResults(string input)
        {
            int length = Constant.IllegalResults.Length;
            for (int i = 0; i < length;i++)
            {
                if (input.IndexOf(Constant.IllegalResults[i][0]) != -1)
                    return Constant.IllegalResults[i][1];
            }
            return null;
        }

        /// <summary>
        /// Method, that validates user key presses on textbox.
        /// This prevents user from typing foreign characters, like 
        /// letters or special symbols.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            int found = Array.IndexOf(Constant.AllowedSymbols, e.KeyChar);

            if (Char.IsControl(e.KeyChar))
                return;
            else if (found == -1)
                e.KeyChar = '\0';        
        }

        /// <summary>
        /// Method, that replaces invalid text that was pasted into the
        /// textbox field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnTextChange(object sender, EventArgs e)
        {
            int exceptionIndex = Array.IndexOf(
                Constant.CalculatorExceptions, Form1.DisplayBox.Text);

            if (exceptionIndex == -1)
            {
                Form1.DisplayBox.Text = Regex.Replace(
                    Form1.DisplayBox.Text,
                    Constant.RegexIllegalSymbols,
                    ""
                );
            }

            Form1.DisplayBox.SelectionStart = Form1.DisplayBox.Text.Length;
            Form1.DisplayBox.SelectionLength = 0;
        }
    }
}