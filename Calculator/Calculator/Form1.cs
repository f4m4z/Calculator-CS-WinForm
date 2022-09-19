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
        float numInput = 0; //1st number user inputs
        float numResult = 0; //result
        bool enteredValue = false; //to prevent user from spamming operators
        bool equalPressed = false; //whether equal key has been pressed

        /* optr_str is a key component of this program
         as the first value the user inputs cannot be operated upon due to there being no 2nd value
         optr_str stores/buffers what operation was supposed to be performed (Operator_Click's switch-case)
         and ignores/queues the operation (Nums_cal's case "") while also moving the numInput variable to numResult
         freeing up the input so user can input another value.
         after the user inputs subsequent values the optr_str is set to actual operation value 
         and Num_calc performs the operation */

        string optr_str = "";


        /*calculation function
        depandant on operator selected, if no operator is selected (first input)
        it assigns input variable as first/result variable to perform operations on*/

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
            if (textBox_Input.Text == "0") textBox_Input.Clear(); //so input doesnt have 0 at start

            //clearing history after user pressed equal button
            if (equalPressed == true) textBox_History.Clear();
            equalPressed = false;

            //user has actually input something, to prevent operator spamming
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
            Button optr = (Button)sender;

            //clearing history after user pressed equal button
            if (equalPressed == true) textBox_History.Clear();
            equalPressed = false;

            //extracting number from result textbox
            getInput();
            clearInput(1);
            
            //update the input number to history
            textBox_History.AppendText(optr_str + numInput.ToString() + Environment.NewLine);


            //Determining what operator was pressed
            if (enteredValue == true) //the user has actually input a number, to prevent button spam
            {
                Nums_calc(optr_str); //actually does the operation
                                     //if this is the first input,optr_str will be blank and thus numResult will be assigned to numInput

                switch (optr.Name)
                {
                    case "buttonAdd": optr_str = "(+) ";  break;
                    case "buttonSub": optr_str = "(-) ";  break;
                    case "buttonMul": optr_str = "(x) ";  break;
                    case "buttonDiv": optr_str = "(/) ";  break;
                }
          
                enteredValue = false; //after pressing operation buttons the input is empty again
            }

            //extras
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

            Nums_calc(optr_str); //does the pending calculation, determines what type via the optr_str string previously set


            //updating history
            if(equalPressed == false)
            {
                textBox_History.AppendText(optr_str + numInput.ToString() + Environment.NewLine);
                textBox_History.AppendText("Result : " + numResult.ToString() + Environment.NewLine);
            }
            

            //resetting all the variables
            numInput = 0;
            numResult = 0;
            equalPressed = true;

            optr_str = "";

        }

    }
}
