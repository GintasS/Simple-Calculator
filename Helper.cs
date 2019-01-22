﻿using System;
using System.Globalization;

namespace Calculator
{
    // Helper class that helps calculator with some additional functionality.
    sealed class Helper
    {
        /// <summary>
        /// Method, that displays math equation result to the textbox and puts it into 
        /// history listbox.
        /// </summary>
        public static void DisplayResult()
        {
            string input = Form1.DisplayBox.Text;
            input = PercentageSymbol(Form1.DisplayBox.Text) ?? input;
            input = ConvertForeignSymbols(input);

            string answerText = Validation.TryUserInput(input) ?? null;
            if (!String.IsNullOrWhiteSpace(answerText))
            {
                int index = (int)Constant.Symbol.Equals;
                Form1.HistoryBox.Items.Add(Form1.DisplayBox.Text + " " +
                    Constant.MathSymbols[index] + " " + answerText);

                Form1.DisplayBox.Text = answerText;
            }
            else
            {
                Form1.DisplayBox.Text = Constant.CalculatorException;
            }
        }

        /// <summary>
        /// Method, that replaces "foreign" math symbols with whose
        /// that DataTable/Ncalc understands.
        /// </summary>
        /// <param name="input">A string to replace symbols.</param>
        /// <returns>A string that's possibly altered.</returns>
        private static string ConvertForeignSymbols(string input)
        {
            int findIndex1 = (int)Constant.Symbol.Multiply,
                findIndex2 = (int)Constant.Symbol.Divide,
                replaceIndex1 = (int)Constant.Symbol.MultiplyMath,
                replaceindex2 = (int)Constant.Symbol.DivideMath;

            input = input.Replace(Constant.MathSymbols[findIndex1],
                Constant.MathSymbols[replaceIndex1]);

            input = input.Replace(Constant.MathSymbols[findIndex2],
                Constant.MathSymbols[replaceindex2]);

            return input;
        }

        /// <summary>
        /// Method, that converts percentage symbol with a math
        /// expression.
        /// </summary>
        /// <param name="input">A string to replace percentage symbol.</param>
        /// <returns>A string with a mathematical expression or a null.</returns>
        private static string PercentageSymbol(string input)
        {
            int index = input.IndexOf('%');

            if (index != -1)
            {
                decimal percent = Decimal.Parse(input.Substring(0,
                    index), NumberStyles.AllowExponent | NumberStyles.Float);

                percent = percent / 100;

                return percent + " * " + input.Substring(index + 2,
                    input.Length - index - 2);
            }
            return null;
        }

        /// <summary>
        /// Method, that deletes one character from a textbox field.
        /// </summary>
        /// <param name="index1">Index to start deleting from.</param>
        public static void DeleteOneChar(int index1)
        {
            Form1.DisplayBox.Text = Form1.DisplayBox.Text.Remove(
                index1, 1
            );
        }

        private Helper() { }
    }
}