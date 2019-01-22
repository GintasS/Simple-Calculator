using System;

namespace Calculator
{
    // Base class for all available math actions to take
    // in this calculator.
    abstract class MathAction : DisplaySymbol
    {
        /// <summary>
        /// Button click event method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void ActionClick(object sender, EventArgs e)
        {
            int index = (int)Constant.ButtonType.Action;
            ButtonText(sender, Constant.ButtonTypes[index]);
        }
    }
}