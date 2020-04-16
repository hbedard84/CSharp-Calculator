using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _200443133A2
{
    public partial class frm_calculator : Form
    {
        Calculator calculator = new Calculator();
        double memory;
        double result;
        string formulaLine = "";
        string activeNumberLine = "";
        bool screenReset = false;

        public frm_calculator()
        {
            InitializeComponent();
        }

        //Calculator Button Click Events - what happens when a button is clicked on calculator

        //Number Buttons
        private void btn_0_Click(object sender, EventArgs e)
        {
            InputCapture("0");
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            InputCapture("1");
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            InputCapture("2");
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            InputCapture("3");
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            InputCapture("4");
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            InputCapture("5");
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            InputCapture("6");
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            InputCapture("7");
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            InputCapture("8");
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            InputCapture("9");
        }
        // Decimal Button (.) click event
        private void btn_decimal_Click(object sender, EventArgs e)
        {
            string output = calculator.Decimal(activeNumberLine);  //validate decimal input
            InputCapture(output);  //input ".", or input "" when "." is invalid
        }
        // Plus/Minus Button  (+/-) click event
        private void btn_sign_Click(object sender, EventArgs e)
        {
            activeNumberLine = calculator.PlusMinus(activeNumberLine);
            DisplayValues();
        }

        //Memory Button Events

        //Back Button click event
        private void btn_back_Click(object sender, EventArgs e)
        {
            InputBackLine2();
        }
        // Clear Button click event
        private void btn_clear_Click(object sender, EventArgs e)
        {
            CalcReset();
        }
        // Memory Clear Button (MC) click event
        private void btn_mc_Click(object sender, EventArgs e)
        {
            calculator.MemoryClear();
            txt_memory.Clear();
            DisplayValues();
        }
        // Memory Recall Button (MR) click event
        private void btn_mr_Click(object sender, EventArgs e)
        {
            DisplayValues();
            memory = calculator.MemoryRecall();
            if (!double.IsNaN(memory))
            {
                activeNumberLine = memory.ToString();
                screenReset = true;
            }
            DisplayValues();
        }
        // Memory Save Button (MS) click event
        private void btn_ms_Click(object sender, EventArgs e)
        {
            Equals();

            if (activeNumberLine != "")
            {
                calculator.MemorySave(Convert.ToDouble(activeNumberLine));
                txt_memory.Text = "M";
            }
        }
         // Memory Plus Button (M+) click event
        private void btn_mPlus_Click(object sender, EventArgs e)
        {
            DisplayValues();
            result = calculator.Calculate(txt_display.Text);
            txt_display.Text = result.ToString();
            calculator.MemoryPlus(result);
            txt_memory.Text = "M";
            DisplayValues();
        }

        //Operator Buttons

        // Division Button (÷) click event
        private void btn_divide_Click(object sender, EventArgs e)
        {
            InputCapture("/");
        }
        //Multiplication Button (x) click event
        private void btn_multiply_Click(object sender, EventArgs e)
        {
            InputCapture("*");
        }
        //Subtraction Button (-) click event
        private void btn_subtract_Click(object sender, EventArgs e)
        {
            InputCapture("-");
        }
        //Addition Button (+) click event
        private void btn_add_Click(object sender, EventArgs e)
        {
            InputCapture("+");
        }
        //Square Root Button (sqrt) click event
        private void btn_sqrt_Click(object sender, EventArgs e)
        {
            result = calculator.SquareRoot(txt_display.Text);
            txt_display.Text = result.ToString();
            screenReset = true;
        }
        //Reciprocal Button (1/x) click event
        private void btn_invert_Click(object sender, EventArgs e)
        {
            DisplayValues();
            double invertResult = calculator.Invert(txt_display.Text);
            activeNumberLine = invertResult.ToString();
            DisplayValues();
            screenReset = true;
        }
        //Equals Button (=) click event
        private void btn_equals_Click(object sender, EventArgs e)
        {
            Equals();
        }

       /// <summary>
       /// Validates incoming input (i) from buttonclick or valid keyboard entry 
       /// and handles how it is displayed in the textbox display.
       /// </summary>
       /// <param name="i"></param>
        public void InputCapture(string i)
        {
            //Operator arrays
            
            string[] allOperators = { "+", "-", "/", "*", "^" };  //contains all possible math operators
            string[] nonNeighbourOperators = { "+", "/", "*", ".", "^", "-" };  //contains all operators which cannot be consecutive operators
            string[] nonstartingOperators = { "+", "/", "*", "^", ")" };  //contains all operators which cannot be at the start of formulas

            //Incoming input validation and handling

            //*****Note:    ActiveNumberLine consists of the inputs being entered between operator presses
            //              FormulaLine consists of the history of inputs waiting to be calculated (the formula)
            //              EG.   50*6-9+7:   FormulaLine = 50*6-9+   and ActiveLine = 7
            //              This allows of easier input validation and handling, and for +/- insertion.

            //If an OPERATOR input is pressed...
            if (allOperators.Contains(i))
            {
                //...and there's nothing in the active line...
                if (activeNumberLine == "") 
                {
                    //...and either...
                    //...there's nothing in the display and the incoming input is a nonstarting operator:
                    if (formulaLine == "" && nonstartingOperators.Contains(i))
                    {
                        return; //don't allow the input to be entered.
                    }
                    //...or there's something in the display:
                    else if (formulaLine != "")
                    {
                        string lastInput = formulaLine.Substring(formulaLine.Length - 1); //check the previous input in the display
                        //if the previous input was an operator which cannot be consecutive with the incoming input:
                        if (nonNeighbourOperators.Contains(lastInput))
                        {
                            InputBackLine1(); //remove the previous nonneighbour operator...
                        }
                        formulaLine += i;  //...and append incoming input to the end of the formula
                    }
                    //...or anything else:
                    else
                    {
                        formulaLine += i; //append incoming input to the end of the formula
                    }
                }
                //If an operator is incoming and there's something in the active line:
                else
                {
                    formulaLine += activeNumberLine + i; //append the active number and the incoming input to the formula
                }
                activeNumberLine = "";  //empty the active line
                screenReset = false;  // set display to keep current output displayed on next keypress
            }

            //If the incoming input is a BRACKET....
            else if ( i == "(" || i == ")")
            {
                //...and there's a partial formula in the current display...
                if (formulaLine != "") 
                {
                    //...and the incoming input is an OPEN BRACKET "("...
                    if (i == "(")
                    {
                        //...and there's nothing in the active line...
                        if (activeNumberLine == "")
                        {
                            string lastInput = formulaLine.Substring(formulaLine.Length - 1); //check the previous input in the display
                            //...if the previous input was an operator which cannot be consecutive with the incoming input:
                            if (nonNeighbourOperators.Contains(lastInput))
                            {
                                formulaLine += activeNumberLine + i;  //append the ( to the formula.
                            }
                            //...if the previous input was an open bracket:
                            else if (lastInput == "(")
                            {
                                formulaLine += activeNumberLine + i;  //append the ( to the formula.
                            }
                            //...otherwise:
                            else
                            {
                                formulaLine += activeNumberLine + "*" + i; //append a Multiply operator to the formula prior to appending the incoming (.
                            }
                        }
                        //...and theres something in the active line:
                        else
                        {
                            formulaLine += activeNumberLine + "*" + i; //append the active number and a Multiply operator to the formula prior to appending the incoming (.
                        }
                    }
                    //If the incoming input is a CLOSE BRACKET ")"...
                    else
                    {
                        //...and the active line is empty:
                        if (activeNumberLine == "")
                        {
                            string lastInput = formulaLine.Substring(formulaLine.Length - 1); //check the previous input
                            //if the previous input cannot be consecutive with the incoming operator:
                            if (nonNeighbourOperators.Contains(lastInput))
                            {
                                InputBackLine1(); //remove the previous operator
                            }
                            formulaLine += activeNumberLine + i;  //append the incoming ).
                        }
                        //...and the active line is not empty
                        else
                        {
                            formulaLine += activeNumberLine + i; //append the active number and the incoming operator
                        }
                    }
                }
                //if the incoming input is a bracket and there's nothing in the current formula...
                else 
                {
                    //...and there's something in the active number:
                    if (activeNumberLine != "")
                    {
                        formulaLine += activeNumberLine + "*" + i;  //append the active number and a multiply operator to the formula before adding the Bracket
                    }
                    //...and there's nothing in the active number:
                    else
                    {
                        //if the incoming input is an open bracket:
                        if (i == "(")
                        {
                            formulaLine += activeNumberLine + i;   //append the "(" to the formula
                        }
                        //if the incoming input in a closed bracket:
                        if (i == ")")
                        {
                            return;  //block the input since formulas cannot start with a closed bracket
                        }
                    }
                }

                activeNumberLine = "";  //clear the active number line
                screenReset = false;  // set display to keep current output displayed on next keypress
            }
            //If the incoming input is a NUMBER 
            else
            {
                //If display is set to be cleared on next input press
                if (screenReset == true)
                {
                    activeNumberLine = "";  //clear the active line 
                    screenReset = false;    //set screen to keep current display
                }
                //If there is a formula and the previous input was a ")":
                if (formulaLine != "" && formulaLine.Substring(formulaLine.Length - 1) == ")")
                {
                    formulaLine += "*";  //append a multiply operator to the formula
                }

                activeNumberLine += i;  //append the active line to the formula
            }

            DisplayValues();  //move active line to the formula, give focus to the display, and deselect the characters

        }

        /// <summary>
        /// Combines the formulaline and activeline into text display. 
        /// Moves the current character in the active line to the formula line, 
        /// refocuses on the display, and removes highlighting from characters.
        /// </summary>
        public void DisplayValues()
        {
            txt_display.Text = formulaLine+activeNumberLine;
            txt_display.Focus();
            txt_display.DeselectAll();
        }

        /// <summary>
        /// Removes the last character in the formula
        /// Can be called using BACK button on calculator or BACKSPACE key on keyboard
        /// </summary>
        public void InputBackLine1()
        {
            if (formulaLine != "")
            {
                formulaLine = formulaLine.Remove(formulaLine.Length - 1);
                DisplayValues();
            }
        }

        /// <summary>
        /// Removes the last character inputted before it is moved the the formula line
        /// Can be called using BACK button on calculator or BACKSPACE key on keyboard
        /// </summary>
        public void InputBackLine2()
        {
            if (activeNumberLine != "")
            {
                activeNumberLine = activeNumberLine.Remove(activeNumberLine.Length - 1);
                DisplayValues();
            }
            else
            {
                InputBackLine1();  //if there's nothing in the active line, the last character in the formula is removed
            }
        }


        /// <summary>
        /// Resets the calculator to its default state:
        /// Clear display, clear formula and active lines, clear the memory storage, and refocus on the display.
        /// Can be called using CLEAR button on calculator or ESC key on keyboard.
        /// </summary>
        public void CalcReset()
        {
            txt_display.Clear();
            formulaLine = "";
            activeNumberLine = "";
            txt_memory.Clear();
            calculator.MemoryClear();
            DisplayValues();
            
        }
        
        /// <summary>
        /// When equals button is clicked or pressed, this calculates the result of the complete formula
        /// </summary>
        public void Equals()
        {
            //First move active line to the formula, give focus to the display, and deselect the characters
            DisplayValues();

            //If there is nothing in the activeline and the last character in the formula is an invalid operator
            //Blocks user from trying to calculate incomplete formula ending in an invalid operator
            //and displays error message
            if (activeNumberLine == "")
            {
                string[] neighbourOperators = { "+", "/", "*", ".", "^", "-", "(" };

                string lastInput = formulaLine.Substring(formulaLine.Length - 1);
                if (neighbourOperators.Contains(lastInput))
                {
                    txt_display.Text = "Formula Not Complete";
                    return;      
                }
            }

            //try to complete the calculation, but catch any invalid calculation errors and display error message
            try
            {
                result = calculator.Calculate(txt_display.Text);
            }
            catch 
            {
                txt_display.Text = "Not A Formula";
                return;
            }

            //Makes dividing by zero invalid and if user attempts to divide by zero returns an error message
            if (double.IsNaN(result) || double.IsInfinity(result) || double.IsNegativeInfinity(result) || double.IsPositiveInfinity(result))
            {
                txt_display.Text = "Cannot divide by 0";
                formulaLine = "";
                activeNumberLine = "";
                return;
            }
            //otherwise displays the result from the calculation in the display
            else
            {
                activeNumberLine = result.ToString();
            }

            formulaLine = "";  //clears the formula
            screenReset = true;  //prepares display to be cleared on the next numerical key press or click (operator key press/click will not clear display and current result will become the start of new formula)

            DisplayValues();  //return focus to display
        }

        // Keyboard Keydown Events - what happens when a keyboard key is used as input

        // Boolean flag used to determine when a character other than a number or operator is entered.
        //Always true. Program handles input via InputCapture(), not user.
        public bool handledKey = true;
        
        private void txt_display_KeyDown(object sender, KeyEventArgs e)
        {
            //Number keys from second row of keyboard
            if (e.KeyCode == Keys.D1)
            {
                InputCapture("1");
            }
            if (e.KeyCode == Keys.D2)
            {
                InputCapture("2");
            }
            if (e.KeyCode == Keys.D3)
            {
                InputCapture("3");
            }
            if (e.KeyCode == Keys.D4)
            {
                InputCapture("4");
            }
            if (e.KeyCode == Keys.D5)
            {
                InputCapture("5");
            }
            if (e.KeyCode == Keys.D6)
            {
                InputCapture("6");
            }
            if (e.KeyCode == Keys.D7)
            {
                InputCapture("7");
            }
            //Keys with dual purpose as modified by holding Shift key
            if (Control.ModifierKeys == Keys.Shift)
            {
                if (e.KeyCode == Keys.D0)    //Shift+0 = )
                {
                    InputCapture(")");
                }
                if (e.KeyCode == Keys.D8)    //shift+8 = *
                {
                    InputCapture("*");
                }
                if (e.KeyCode == Keys.D9)    //Shift+9 = (
                {
                    InputCapture("(");
                }
                if (e.KeyCode == Keys.Oemplus)  // +/= key besides backspace  Shift+= = +
                {
                    InputCapture("+");
                }
            }
            else
            {
                if (e.KeyCode == Keys.D0)
                {
                    InputCapture("0");
                }
                if (e.KeyCode == Keys.D8)
                {
                    InputCapture("8");
                }
                if (e.KeyCode == Keys.D9)
                {
                    InputCapture("9");
                }
                if (e.KeyCode == Keys.Oemplus)  // "=" key besides backspace 
                {
                    Equals();
                }
            }

            //Number Pad key inputs (when numlock is on)
            if (Control.IsKeyLocked(Keys.NumLock))
            {

                if (e.KeyCode == Keys.NumPad0)
                {
                    InputCapture("0");
                }
                if (e.KeyCode == Keys.NumPad1)
                {
                    InputCapture("1");
                }
                if (e.KeyCode == Keys.NumPad2)
                {
                    InputCapture("2");
                }
                if (e.KeyCode == Keys.NumPad3)
                {
                    InputCapture("3");
                }
                if (e.KeyCode == Keys.NumPad4)
                {
                    InputCapture("4");
                }
                if (e.KeyCode == Keys.NumPad5)
                {
                    InputCapture("5");
                }
                if (e.KeyCode == Keys.NumPad6)
                {
                    InputCapture("6");
                }
                if (e.KeyCode == Keys.NumPad7)
                {
                    InputCapture("7");
                }
                if (e.KeyCode == Keys.NumPad8)
                {
                    InputCapture("8");
                }
                if (e.KeyCode == Keys.NumPad9)
                {
                    InputCapture("9");
                }
            }
            //Keyboard inputs for Operators 
            if (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
            {
                string output = calculator.Decimal(activeNumberLine);
                InputCapture(output);
            }
            if (e.KeyCode == Keys.Add)
            {
                InputCapture("+");
            }
            if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.OemQuestion)
            {
                InputCapture("/");
            }
            if (e.KeyCode == Keys.Multiply)
            {
                InputCapture("*");
            }
            if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                InputCapture("-");
            }
            if (e.KeyCode == Keys.Enter)
            {
                Equals();
            }
            if (e.KeyCode == Keys.OemOpenBrackets)
            {
                InputCapture("(");
            }
            if (e.KeyCode == Keys.Oem6)
            {
                InputCapture(")");
            } 
            if (e.KeyCode == Keys.Escape)
            {
                CalcReset();
            }
            if (e.KeyCode == Keys.Back)
            {
                InputBackLine2();
            }
        }

        private void txt_display_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            // Stop the character from being entered into the control if it is non-numerical or nonoperator.
            if (handledKey == true)
            {
                e.Handled = true;
            }
        }
    }
}
