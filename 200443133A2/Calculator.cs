using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200443133A2
{
    class Calculator
    {
        decimal result;
        //char array
       

        public decimal Calculate(String formula)
        {
            //convert formula to Char Array
            //Foreach item in Char Array, check if number or operator
            //If number add to new number string variable
            //if operator add operator to operator string array and add new number var to  number string array
            //Null New number and start over
            result = Convert.ToDecimal(formula);
            return result;
        }

        public decimal SquareRoot(String formula)
        {
           double resultInput = Convert.ToDouble(Calculate(formula));
           result = Convert.ToDecimal(Math.Sqrt(resultInput));
           return result;
        }

        public decimal Invert(String formula)
        {
            result = Convert.ToDecimal(Calculate(formula));
            result = 1 / result;
            return result;
        }

    }
}
