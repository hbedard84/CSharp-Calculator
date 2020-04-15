using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _200443133A2
{
    class Calculator : MemoryCalculator
    {
        double result;
        
        string[] operators = { "+", "*", "/", "-" , "(", ")" };
        List<double> inputNumbers = new List<double>();
        List<string> inputOperators = new List<string>();
        

        public double Calculate(string formula)
        {
            DataTable dt = new DataTable();
            var bedmasCalculate = dt.Compute(formula, "");
            result = Convert.ToDouble(bedmasCalculate);

            return result;
        }

        public string Decimal(string input)
        {
            //MessageBox.Show(input);
            string output;
            if ( input.Contains(".") ) {
                output = "";
            } 
            else 
            {
                output = ".";
            }

            return output;
        }

        public double SquareRoot(String formula)
        {
           double resultInput = Calculate(formula);
           result = Math.Sqrt(resultInput);
           return result;
        }

        public double Invert(String formula)
        {
            result = Calculate(formula);
            result = 1 / result;
            return result;
        }

        public string PlusMinus(String activeNumber)
        {
            string newActiveNumber = "";
            if (activeNumber != "")
            {
                newActiveNumber = Convert.ToString((Convert.ToDecimal(activeNumber) * -1));
            }

            return newActiveNumber;
        }

    }
}
