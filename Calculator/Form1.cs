using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public static TextBox Display { get; set; }
        public static ListBox History { get; set; }
        // Bool, that indicates, whether an active math operation is in place.
        public static bool IsMathOperationActive { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeControls();
            InitializeNumberEvents();
            InitializeMainButtonEvents();
            InitializeExtraButtonEvents();
            InitializeMainEvents();
        }

        private void InitializeControls()
        {
            Display = DisplayBox;
            History = HistoryListBox;
        }
 
        private void InitializeNumberEvents()
        {
            var numberButtons = new Button[]
            {
                Button0,
                Button1,
                Button2,
                Button3,
                Button4,
                Button5,
                Button6,
                Button7,
                Button8,
                Button9
            };

            foreach(var button in numberButtons)
            {
                button.Click += new Number().Button_Click;
            }
        }

        private void InitializeExtraButtonEvents()
        {
            ButtonDot.Click += new Dot().Button_Click;
            ButtonC.Click += new C().Button_Click;
            ButtonDelete.Click += new Delete().Button_Click;
        }

        private void InitializeMainButtonEvents()
        {
            var mainButtons = new Button[]
            {
                ButtonDivide,
                ButtonMultiply,
                ButtonSubtract,
                ButtonAdd
            };

            foreach (var button in mainButtons)
            {
                button.Click += new MainAction().Button_Click;
            }

            ButtonEquals.Click += new Equals().Button_Click;
        }

        private void InitializeMainEvents()
        {
            Display.TextChanged += CustomEvents.Display_TextChanged;
        }



    }
}