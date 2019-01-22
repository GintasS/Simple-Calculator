using System;
using System.Windows.Forms;
using System.Data;
using NCalc;

namespace Calculator
{
    // Class, responsible for user input validation.
    sealed class Validation
    {
        /// <summary>
        /// Method, that tries to parse user input into a mathematical
        /// expression by 2 different ways.
        /// 1 way is by suing datatable Compute method.
        /// 2 way is by using external library Ncalc.
        /// </summary>
        /// <param name="input">User input.</param>
        /// <returns>A string of parsed expression or a null,
        /// if parsing went wrong.
        /// </returns>
        public static string TryUserInput(string input)
        {
            try
            {
                DataTable dt = new DataTable();

                return Convert.ToDecimal(dt.Compute(input, 
                    String.Empty)).ToString(Constant.DecimalFormat);
            }
            catch
            {
                try
                {
                    Expression exps = new Expression(input);

                    return exps.Evaluate().ToString();
                }
                catch
                {
                    Form1.DisplayBox.Text = Constant.CalculatorException;
                }
            }
            return null;
        }

        private Validation() { }
    }
}
