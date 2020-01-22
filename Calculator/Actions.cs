using Calculator.Models;
using System;
using System.Windows.Forms;

namespace Calculator
{
    // Every number button(0-9) button will take this class.
    public sealed class Number : MathAction
    {
        public override void Button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            Form1.Display.Text += button.Text;
        }
    }

    // Dot(.)
    public sealed class Dot : MathAction
    {
        public override void Button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            string text = Form1.Display.Text;

            // Prevent adding dot, if we're not near a number.
            if (char.IsDigit(text[text.Length - 1]) == false)
            {
                return;
            }

            Form1.Display.Text += button.Text;
        }
    }

    // Every main action: subtract(-), add(+), divide(/), multiply(*)
    // will take this class.
    public sealed class MainAction : MathAction 
    {
        public override void Button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var text = Form1.Display.Text;

            if (char.IsDigit(text[text.Length - 1]) == false && 
                text[text.Length - 1] != Constants.Symbol.Dot)
            {
                // Allow user to change main action sign(e.g from subtraction(-) to add(+)).
                Form1.Display.Text = text.Substring(0, text.IndexOf(Constants.Symbol.Space)) + 
                    Constants.Symbol.Space + button.Text + text.Substring(text.LastIndexOf(Constants.Symbol.Space));

                return;
            }
            else if (Form1.IsMathOperationActive)
            {               
                // Display partial result to prevent long expressions, handle user input.
                Form1.Display.Text = ResultsManager.GetDisplayResults(Form1.Display.Text);        
            }

            Form1.Display.Text += Constants.Symbol.Space + button.Text + Constants.Symbol.Space;
            Form1.IsMathOperationActive = true;
        }
    }

    // Equals(=).
    public sealed class Equals : MathAction
    {
        public override void Button_Click(object sender, EventArgs e)
        {
            Form1.Display.Text = ResultsManager.GetDisplayResults(Form1.Display.Text);
        }
    }

    // Clear(C).
    public sealed class C : MathAction
    {
        public override void Button_Click(object sender, EventArgs e)
        {
            Form1.Display.Text = Constants.DefaultDisplayValue;
        }
    }

    // Delete(←).
    public sealed class Delete : MathAction
    {
        public override void Button_Click(object sender, EventArgs e)
        {
            Form1.Display.Text = Form1.Display.Text.Remove(Form1.Display.Text.Length - 1, 1);
        }
    }



}