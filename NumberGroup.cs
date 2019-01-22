using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    // Class collection that will hold number buttons + dot button in this calculator.
    sealed class NumberCollection<NumberGroup>
    {
        private NumberGroup[] arr = new NumberGroup[Constant.NumberCount];

        // Define the indexer to allow client code to use [] notation.
        public NumberGroup this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }
    }

    // Class, that is a blueprint for button's collection item.
    sealed class NumberGroup : DisplaySymbol
    {
        /// <summary>
        /// Method, that handles click events on numbers(0-9)
        /// + dot button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NumberBTNClick(object sender, EventArgs e)
        {
            int index = (int)Constant.ButtonType.Number;
            ButtonText(sender, Constant.ButtonTypes[index]);
        }
    }
}