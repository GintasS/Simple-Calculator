using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        // Display box is a textbox where user puts input data.
        public static TextBox DisplayBox { get; set; }

        // HistoryBox is for displaying previous mathematical
        // expressions.
        public static ListBox HistoryBox { get; set; }

        // A collection that holds all the number buttons.
        private NumberCollection<NumberGroup> AllNumbers;
 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayBox = Display;
            HistoryBox = HistoryListBox;

            InitNumberButtons();
            InitMainActionButtons();
            InitAdditionalButtons();
            InitSpecialButtons();
        }

        /// <summary>
        /// Method, that initalizes all the number buttons(0-9).
        /// </summary>
        private void InitNumberButtons()
        {
            Button[] NumberButtons = new Button[]
            {
                BTN0, BTN1, BTN2, BTN3, BTN4, BTN5,
                BTN6, BTN7, BTN8, BTN9, DotBTN
            };

            AllNumbers = new NumberCollection<NumberGroup>();
            for (int i = 0; i < Constant.NumberCount; i++)
            {
                AllNumbers[i] = new NumberGroup();
                NumberButtons[i].Click += AllNumbers[i].NumberBTNClick;
            }
        }

        /// <summary>
        /// Method, that initializes all the main action buttons
        /// (divide,multiply,subtract,add,equals).
        /// </summary>
        private void InitMainActionButtons()
        {
            // Main math buttons.
            AddBTN.Click += new AddAction().ActionClick;
            SubtractBTN.Click += new SubtractAction().ActionClick;
            MultiplyBTN.Click += new MultiplyAction().ActionClick;
            DivideBTN.Click += new DivideAction().ActionClick;
            EqualBTN.Click += EqualsAction.ActionClick;
        }

        /// <summary>
        /// Method, that initializes special buttons, like clear everything,
        /// clear last action and etc.
        /// </summary>
        private void InitSpecialButtons()
        {
            // Special buttons.
            CEBTN.Click += new CEAction().ActionClick;
            CBTN.Click += new CAction().ActionClick;
            DeleteOneBTN.Click += new DeleteAction().ActionClick;
        }

        /// <summary>
        /// Method, that initializes additional buttons, like square,
        /// square root or plus minus.
        /// </summary>
        private void InitAdditionalButtons()
        {
            // Additional buttons.
            PlusMinusBTN.Click += new PlusMinusAction().ActionClick;
            PercentageBTN.Click += new PercentageAction().ActionClick;
            SquareRootBTN.Click += new SquareRootAction().ActionClick;
            SquareBTN.Click += new SquareAction().ActionClick;
            FractionBTN.Click += new FractionAction().ActionClick;

            DisplayBox.KeyPress += Validation.OnKeyPress;
            DisplayBox.TextChanged += Validation.OnTextChange;
        }
    }
}