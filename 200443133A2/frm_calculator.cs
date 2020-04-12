using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _200443133A2
{
    public partial class frm_calculator : Form
    {
        Calculator calculator = new Calculator();
        double memory = 0;
        double result;

        public frm_calculator()
        {
            InitializeComponent();
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            txt_display.Text += "0";
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            txt_display.Text += "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            txt_display.Text += "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            txt_display.Text += "3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            txt_display.Text += "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            txt_display.Text += "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            txt_display.Text += "6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            txt_display.Text += "7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            txt_display.Text += "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            txt_display.Text += "9";
        }

        private void btn_decimal_Click(object sender, EventArgs e)
        {
            txt_display.Text += ".";
        }

        private void btn_sign_Click(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            string current_display = txt_display.Text;
            txt_display.Text = current_display.Remove(current_display.Length - 1);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_display.Clear();
        }

        private void btn_mc_Click(object sender, EventArgs e)
        {
            txt_memory.Clear();
            memory = 0;
        }

        private void btn_mr_Click(object sender, EventArgs e)
        {
            txt_display.Text = memory.ToString();
            txt_memory.Text = "M";
        }

        private void btn_ms_Click(object sender, EventArgs e)
        {
            result = calculator.Calculate(txt_display.Text);
            memory = result;
            txt_memory.Text = "M";
        }

        private void btn_mPlus_Click(object sender, EventArgs e)
        {
            result = calculator.Calculate(txt_display.Text);
            memory += result;
            txt_memory.Text = "M";
        }

        private void btn_divide_Click(object sender, EventArgs e)
        {
            txt_display.Text += "/";
        }

        private void btn_multiply_Click(object sender, EventArgs e)
        {
            txt_display.Text += "*";
        }

        private void btn_subtract_Click(object sender, EventArgs e)
        {
            txt_display.Text += "-";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            txt_display.Text += "+";
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
        }

        private void btn_equals_Click(object sender, EventArgs e)
        {
            result = calculator.Calculate(txt_display.Text);
            txt_display.Text = result.ToString();
        }

        //Method to allow for keyboard and numpad inputs

       /* protected void frm_calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar.Equals('0') || e.KeyChar.Equals(Keys.NumPad0))
            {
                btn_0.PerformClick();
                e.Handled = true;
            } 
        */    


            /*
            bool validKeyEntered;

            private void txt_display_keydown(object sender, KeyEventArgs e)
            {
                //invalidate all keyboard input
                validKeyEntered = false;
                //valid keyboard inputs
                if (e.KeyCode == Keys.D0)
                {
                    validKeyEntered = true;
                    txt_display.Text += "0";
                }
                if (e.KeyCode == Keys.D1)
                {
                    txt_display.Text += "1";
                }
                if (e.KeyCode == Keys.D2)
                {
                    txt_display.Text += "2";
                }
                if (e.KeyCode == Keys.D3)
                {
                    txt_display.Text += "3";
                }
                if (e.KeyCode == Keys.D4)
                {
                    txt_display.Text = "4";
                }
                if (e.KeyCode == Keys.D5)
                {
                    txt_display.Text = "5";
                }
                if (e.KeyCode == Keys.D6)
                {
                    txt_display.Text = "6";
                }
                if (e.KeyCode == Keys.D7)
                {
                    txt_display.Text = "7";
                }
                if (e.KeyCode == Keys.D8)
                {
                    txt_display.Text = "8";
                }
                if (e.KeyCode == Keys.D9)
                {
                    txt_display.Text = "9";
                }

                //numpad inputs

                if (Control.IsKeyLocked(Keys.NumLock))
                {
                    if (e.KeyCode == Keys.NumPad0)
                    {
                        txt_display.Text = "0";
                    }
                    if (e.KeyCode == Keys.NumPad1)
                    {
                        txt_display.Text = "1";
                    }
                    if (e.KeyCode == Keys.NumPad2)
                    {
                        txt_display.Text = "2";
                    }
                    if (e.KeyCode == Keys.NumPad3)
                    {
                        txt_display.Text = "3";
                    }
                    if (e.KeyCode == Keys.NumPad4)
                    {
                        txt_display.Text = "4";
                    }
                    if (e.KeyCode == Keys.NumPad5)
                    {
                        txt_display.Text = "5";
                    }
                    if (e.KeyCode == Keys.NumPad6)
                    {
                        txt_display.Text = "6";
                    }
                    if (e.KeyCode == Keys.NumPad7)
                    {
                        txt_display.Text = "7";
                    }
                    if (e.KeyCode == Keys.NumPad8)
                    {
                        txt_display.Text = "8";
                    }
                    if (e.KeyCode == Keys.NumPad9)
                    {
                        txt_display.Text = "9";
                    }
                }
                else
                {
                    MessageBox.Show("NumLock is OFF.");
                }

            }
            private void txt_display_keypress(object sender, KeyPressEventArgs e)
            {
                // Check for the flag being set in the KeyDown event.
                if (validKeyEntered == true)
                {
                    // Stop the character from being entered into the control since it is non-numerical.
                    e.Handled = false;
                }
            }*/
        
    }
}
