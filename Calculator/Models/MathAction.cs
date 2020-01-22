using System;
using System.Windows.Forms;

namespace Calculator.Models
{
    // Class, that almost all form buttons will inherit from in order to subscribe for the event.
    public abstract class MathAction
    {
        public virtual void Button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            Form1.Display.Text += Constants.Symbol.Space + button.Text + Constants.Symbol.Space;
        }



    }
}