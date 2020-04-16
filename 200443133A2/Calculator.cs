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
       
        /// <summary>
        /// Uses DataTable to perform math calculations using Order of Operations: Brackets, Division, Multiply, Addition, Subtraction
        /// </summary>
        /// <param name="formula">string from the formula line</param>
        /// <returns>double result = answer resulting from the formula calculation</returns>
        public double Calculate(string formula)
        {
            DataTable calculations = new DataTable();
            var bedmasCalculate = calculations.Compute(formula, "");
            result = Convert.ToDouble(bedmasCalculate);

            return result;
        }

        /// <summary>
        /// Blocks consecutive decimals or more than one decimal from being entered in a single numerical input
        /// EG.  "6.8.7" or "0..98" is not allowed. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Decimal(string input)
        {
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

        /// <summary>
        /// Calculates the square root of the value
        /// </summary>
        /// <param name="formula"></param>
        /// <returns>double result = square root of the parameter formula</returns>
        public double SquareRoot(String formula)
        {
           double resultInput = Calculate(formula);  //calculates the result of the formula in the formala line
           result = Math.Sqrt(resultInput);   //calculates the square root of the result from the formula line
           return result;
        }

        /// <summary>
        /// Calculates the reciprocal of the value
        /// </summary>
        /// <param name="formula"></param>
        /// <returns>double invertResult = the reciprocal of the value</returns>
        public double Invert(String formula)
        {
            result = Calculate(formula);    //calculates the result of the formula in the formula line
            double invertResult = 1 / result;   //inverts number to calculate the reciprocal of the formula's result
            return invertResult;
        }

        /// <summary>
        /// Changes the value of the active number to the opposite sign
        /// EG -9 = 9 or 7 = -7
        /// Can be called by clicking +/- button on calculator after active number is inputted
        /// </summary>
        /// <param name="activeNumber"></param>
        /// <returns>string newActiveNumber = the value of the active number multiplied by negative 1</returns>
        public string PlusMinus(String activeNumber)
        {
            string newActiveNumber = "";
            if (activeNumber != "")
            {
                newActiveNumber = Convert.ToString((Convert.ToDouble(activeNumber) * -1));  //Multiply active number by -1 to flip the sign of the active number
            }

            return newActiveNumber;
        }

    }
}
