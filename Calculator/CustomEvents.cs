using System;

namespace Calculator
{
    // Class, that will handle custom button events.
    public static class CustomEvents
    {
        public static void Display_TextChanged(object sender, EventArgs e)
        {
            string text = Form1.Display.Text;

            // If user deleted everything from a display, set 0 to the display.
            // If user entered something else(except dot), remove that zero.
            if (text.Length == 0)
            {
                Form1.Display.Text = Constants.DefaultDisplayValue;
            }
            else if (text.Length == 2)
            {
                if (text[0] == Constants.DefaultDisplayValue[0] && text[1] != Constants.Symbol.Dot)
                {
                    Form1.Display.Text = text.Remove(0, 1);
                }
            }

            // Set cursor on the display to be after the text.
            Form1.Display.SelectionStart = Form1.Display.Text.Length;
            Form1.Display.SelectionLength = 0;
        }



    }
}