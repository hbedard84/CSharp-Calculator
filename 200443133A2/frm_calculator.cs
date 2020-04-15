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
        double memory = 0;
        double result;
        string formulaLine = "";
        string activeNumberInputLine = "";

        public frm_calculator()
        {
            InitializeComponent();
        }

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

        private void btn_decimal_Click(object sender, EventArgs e)
        {
            string output = calculator.Decimal(activeNumberInputLine);
            InputCapture(output);
        }

        private void btn_sign_Click(object sender, EventArgs e)
        {

            activeNumberInputLine = calculator.PlusMinus(activeNumberInputLine);
            DisplayValues();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            InputBackLine2();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            CalcReset();
        }

        private void btn_mc_Click(object sender, EventArgs e)
        {
            calculator.MemoryClear();
            txt_memory.Clear();
            DisplayValues();
        }

        private void btn_mr_Click(object sender, EventArgs e)
        {
            memory = calculator.MemoryRecall();
            if (!double.IsNaN(memory))
            {
                if (txt_display.Text != "")
                {
                    string last_char = txt_display.Text.Substring(txt_display.Text.Length - 1, 1);

                    if (last_char == "+" || last_char == "-" || last_char == "x" || last_char == "/")
                    {
                    }
                    else
                    {
                        txt_display.Text += "+";
                    }
                }

                txt_display.Text += memory.ToString();

            }
            DisplayValues();
        }

        private void btn_ms_Click(object sender, EventArgs e)
        {
            result = calculator.Calculate(txt_display.Text);
            txt_display.Text = result.ToString();
            calculator.MemorySave(result);
           
            txt_memory.Text = "M";
            DisplayValues();
        }

        private void btn_mPlus_Click(object sender, EventArgs e)
        {
            result = calculator.Calculate(txt_display.Text);
            txt_display.Text = result.ToString();
            calculator.MemoryPlus(result);
            txt_memory.Text = "M";
            DisplayValues();
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            InputCapture("/");
        }

        private void btn_multiply_Click(object sender, EventArgs e)
        {
            InputCapture("*");
        }

        private void btn_subtract_Click(object sender, EventArgs e)
        {
            InputCapture("-");
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            InputCapture("+");
        }

        private void btn_sqrt_Click(object sender, EventArgs e)
        {
            result = calculator.SquareRoot(txt_display.Text);
            txt_display.Text = result.ToString();
        }

        private void btn_invert_Click(object sender, EventArgs e)
        {
            result = calculator.Invert(txt_display.Text);
            txt_display.Text = result.ToString();
            DisplayValues();
        }

        private void btn_equals_Click(object sender, EventArgs e)
        {
            Equals();
        }

       
        bool screenReset = false;
        public void InputCapture(string i)
        {
            string[] allOperators = { "+", "-", "/", "*", "^", "(", ")" };
            string[] neighbourOperators = { "+", "/", "*", ".", "^", "-" };
            string[] startingOperators = { "+", "/", "*", "^" };
            

            if (allOperators.Contains(i))
            //If operator is pressed
            {
                if (activeNumberInputLine == "")
                {
                    if (formulaLine == "" && startingOperators.Contains(i))
                    {
                        return;
                    }
                    else if (formulaLine != "")
                    {
                        string lastInput = formulaLine.Substring(formulaLine.Length - 1); //
                        if (neighbourOperators.Contains(lastInput))
                        {
                            InputBackLine1();
                        }
                        formulaLine += i;
                    }
                }
                else
                {
                    formulaLine += activeNumberInputLine + i;
                }
                activeNumberInputLine = "";
            }
            else
            //If Anything else is pressed (numbers)
            {
                activeNumberInputLine += i;
            }

            DisplayValues();

        }

        public void DisplayValues()
        {

            txt_display.Text = formulaLine+activeNumberInputLine;
            txt_display.Focus();
            txt_display.DeselectAll();
        }

        public void InputBackLine1()
        {
            if (formulaLine != "")
            {
                formulaLine = formulaLine.Remove(formulaLine.Length - 1);
                DisplayValues();
            }
        }
        public void InputBackLine2()
        {
            if (activeNumberInputLine != "")
            {
                activeNumberInputLine = activeNumberInputLine.Remove(activeNumberInputLine.Length - 1);
                DisplayValues();
            }
            else
            {
                InputBackLine1();
            }
        }

        public void CalcReset()
        {
            txt_display.Clear();
            formulaLine = "";
            activeNumberInputLine = "";
            txt_memory.Clear();
            calculator.MemoryClear();
            DisplayValues();
            
        }
        
        public void Equals()
        {
            DisplayValues();
            result = calculator.Calculate(txt_display.Text);

            if (double.IsNaN(result) || double.IsInfinity(result) || double.IsNegativeInfinity(result) || double.IsPositiveInfinity(result))
            {
                txt_display.Text = "Cannot divide by 0";
            }
            else
            {
                activeNumberInputLine = result.ToString();
            }

            formulaLine = "";
            screenReset = true;

            DisplayValues();
        }

       


        // Boolean flag used to determine when a character other than a number or operator is entered.
        public bool handledKey = true;
        
        private void txt_display_KeyDown(object sender, KeyEventArgs e)
        {
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
            
            if (Control.ModifierKeys == Keys.Shift)
            {
               /* if (e.KeyCode == Keys.D0)
                {
                    InputCapture(")");
                }*/
                if (e.KeyCode == Keys.D8)
                {
                    InputCapture("*");
                }
               /* if (e.KeyCode == Keys.D9)
                {
                    InputCapture("(");
                }*/
                if (e.KeyCode == Keys.Oemplus)
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
                if (e.KeyCode == Keys.Oemplus)
                {
                    Equals();
                }
            }
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
            if (e.KeyCode == Keys.Decimal)
            {
                InputCapture(".");
            }
            if (e.KeyCode == Keys.OemPeriod)
            {
                InputCapture(".");
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
            if (e.KeyCode == Keys.Return)
            {
                Equals();
            }
           /* if (e.KeyCode == Keys.OemOpenBrackets)
            {
                InputCapture("("); ;
            }
            if (e.KeyCode == Keys.Oem6)
            {
                InputCapture(")"); ;
            } */
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
            if (handledKey == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        
    }
}
