using System.Windows.Forms;

namespace Calculator
{
    abstract class DisplaySymbol
    {
        /// <summary>
        /// Method, that adds user clicked button's text to the textbox.
        /// </summary>
        public static void ButtonText(object sender, string type)
        {
            Button temp = sender as Button;
            int index = (int)Constant.ButtonType.Action;

            // Determine button type and act accordingly.
            if (type == Constant.ButtonTypes[index])
                Form1.DisplayBox.Text += " " + temp.Text + " ";
            else
                Form1.DisplayBox.Text += temp.Text;
        }
    }
}