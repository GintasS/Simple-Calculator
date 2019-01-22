using System;

namespace Calculator
{
    // All base actions: add, subtract, divide, multiply, equals.
    sealed class AddAction : MathAction { }
    sealed class SubtractAction : MathAction { }
    sealed class DivideAction : MathAction { }
    sealed class MultiplyAction : MathAction { }

    // Equals
    sealed class EqualsAction : MathAction
    {
        public static new void ActionClick(object sender, EventArgs e) =>       
            Helper.DisplayResult();        
    }
    
    // Plus Minus
    sealed class PlusMinusAction : MathAction
    {
        public override void ActionClick(object sender, EventArgs e)
        {
            if (Form1.DisplayBox.Text[0] == '-')
                Helper.DeleteOneChar(0);
            else if (Form1.DisplayBox.Text[0] != '-')
            {
                int index = (int)Constant.Symbol.Subtract;
                Form1.DisplayBox.Text = Form1.DisplayBox.Text.Insert(0, 
                    Constant.MathSymbols[index]);             
            }
        }
    }

    // Special actions: clear previous number and clear the whole textbox.
    sealed class CEAction : MathAction
    {
        public override void ActionClick(object sender, EventArgs e)
        {
            if (Form1.DisplayBox.Text.Length == 0)
                return;

            int space = Form1.DisplayBox.Text.LastIndexOf(" ");

            Form1.DisplayBox.Text = Form1.DisplayBox.Text.Remove(
                space + 1,
                Form1.DisplayBox.Text.Length - space - 1
            );
        }
    }

    sealed class CAction : MathAction
    {
        public override void ActionClick(object sender, EventArgs e) =>
            Form1.DisplayBox.Text = "";
    }

    sealed class DeleteAction : MathAction
    {
        public override void ActionClick(object sender, EventArgs e)
        {
            if (Form1.DisplayBox.Text.Length == 0)
                return;

            Helper.DeleteOneChar(Form1.DisplayBox.Text.Length - 1);
        }
    }

    // Additional actions: percentage, square, square root, fraction.
    sealed class SquareAction : MathAction
    {
        public override void ActionClick(object sender, EventArgs e)
        {
            string text = Form1.DisplayBox.Text;
            string answer = Validation.TryUserInput(text + " * " + text);

            if (answer != null)
                Form1.DisplayBox.Text = answer;
        }
    }

    sealed class SquareRootAction : MathAction
    {
        public override void ActionClick(object sender, EventArgs e)
        {
            string answer = Validation.TryUserInput(Form1.DisplayBox.Text) 
                ?? null;

            if (answer != null)
            {
                double input = (double)Convert.ToDecimal(answer);
                Form1.DisplayBox.Text = Math.Sqrt(input).ToString();
            }
        }
    }

    sealed class FractionAction : MathAction
    {
        public override void ActionClick(object sender, EventArgs e)
        {
            string answer = Validation.TryUserInput("1 / " + 
                Form1.DisplayBox.Text);

            if (answer != null)
                Form1.DisplayBox.Text = answer;
        }
    }

    sealed class PercentageAction : MathAction
    {
        public override void ActionClick(object sender, EventArgs e)
        {
            int index = (int)Constant.Symbol.Percentage;
            Form1.DisplayBox.Text += " " + Constant.MathSymbols[index] + " ";
        }
    }
}