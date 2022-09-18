using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Calculator
{

    public partial class MainWindow : Form
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        //declaring essential variables
        public float numInput = 0; //1st number user inputs
        public float numResult = 0; //result
        public bool enteredValue = false; //to prevent user from spamming operators
        public bool equalPressed = false;
        public string optr_str = "";


        public float Nums_calc(string a)
        {
             switch (a)
                {
                    case "(+) ": numResult = (numResult + numInput); break;
                    case "(-) ": numResult = (numResult - numInput); break;
                    case "(x) ": numResult = (numResult * numInput); break;
                    case "(/) ": numResult = (numResult / numInput); break;
                    case "": numResult = numInput; break;

                }

            return numResult;

        }



        public void getInput()
        {

            numInput = Convert.ToInt32(textBox_Input.Text);
            
        }
        public void clearInput(int a)
        {
            switch (a)
            {
                case 1: textBox_Input.Clear(); textBox_Input.AppendText("0"); break;
                case 2: textBox_History.Clear(); textBox_Input.Clear(); textBox_Input.AppendText("0"); break;
            }
        }

        //number buttons
        public void Num_Click(object sender, EventArgs e)
        {
            Button digit = (Button)sender;
            if (textBox_Input.Text == "0") textBox_Input.Clear();
            if (equalPressed == true) textBox_History.Clear();
            equalPressed = false;
            enteredValue = true;

            switch (digit.Name)
            {
                case "button1":
                    textBox_Input.AppendText("1"); break;

                case "button2":
                    textBox_Input.AppendText("2"); break;

                case "button3":
                    textBox_Input.AppendText("3"); break;

                case "button4":
                    textBox_Input.AppendText("4"); break;

                case "button5":
                    textBox_Input.AppendText("5"); break;

                case "button6":
                    textBox_Input.AppendText("6"); break;

                case "button7":
                    textBox_Input.AppendText("7"); break;

                case "button8":
                    textBox_Input.AppendText("8"); break;

                case "button9":
                    textBox_Input.AppendText("9"); break;

                case "button0":
                    textBox_Input.AppendText("0"); break;


            }

        }


        //operator buttons
        public void Operator_Click(object sender, EventArgs e)
        {
            //extracting number from result textbox
            if (equalPressed == true) textBox_History.Clear();
            equalPressed = false;
            getInput();
            clearInput(1);

            //Determining what operator was pressed
            Button optr = (Button)sender;
            
            textBox_History.AppendText(optr_str + numInput.ToString() + Environment.NewLine);
            

            if (enteredValue == true)
            {
                Nums_calc(optr_str);

                switch (optr.Name)
                {
                    case "buttonAdd": optr_str = "(+) ";  break;
                    case "buttonSub": optr_str = "(-) ";  break;
                    case "buttonMul": optr_str = "(x) ";  break;
                    case "buttonDiv": optr_str = "(/) ";  break;
                }
          
                enteredValue = false;
            }

            textBox_Sign.Clear();
            textBox_Sign.AppendText(optr_str);

        }

        public void Utility_Click(object sender, EventArgs e)
        {

        }

        //equal - result button
        public void Equal_Click(object sender, EventArgs e)
        {
            //initializing
            getInput();
            clearInput(1);

            Nums_calc(optr_str);


            //updating history
            textBox_History.AppendText(optr_str + numInput.ToString() + Environment.NewLine);
            textBox_History.AppendText("Result : " + numResult.ToString() + Environment.NewLine);

            numInput = 0;
            numResult = 0;
            equalPressed = true;
            
            optr_str = "";

        }

    }
}
