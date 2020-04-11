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
        String memory = "";

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
            memory = "";
        }

        private void btn_mr_Click(object sender, EventArgs e)
        {
            txt_display.Text = memory;
        }

        private void btn_ms_Click(object sender, EventArgs e)
        {
            //Run equals method
            //memory = result from equals method
            txt_memory.Text = "M";
        }

        private void btn_mPlus_Click(object sender, EventArgs e)
        {
            //Run equals method
            //memory = memory + result from equals method
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
            //run equals method
            //run sqrt method
        }

        private void btn_invert_Click(object sender, EventArgs e)
        {
            //run equals method
            //run invert method
        }

        private void btn_equals_Click(object sender, EventArgs e)
        {
            //run equals method
        }
    }
}
