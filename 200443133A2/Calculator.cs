using System;
using System.Collections.Generic;
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
            //split the formula into substrings, separated by operators
            string[] formula_substrings = Regex.Split(formula, @"(\(|\)|(?<!e|E)-|(?<!e|E)\+|\*|/|\s+)");

            //if substring is an operator, add it to the inputOperators list, otherwise add it to the inputNumbers list, 
            foreach (string substring in formula_substrings)
            {
                if (operators.Contains(substring)) 
                {
                    inputOperators.Add(substring);
                }
                else
                {
                    inputNumbers.Add(Convert.ToDouble(substring));
                }
            }

            /*
            //testing if substrings being added to proper arrays
            foreach (string number in inputNumbers)
            {
                MessageBox.Show(number);
            }

            foreach (string operators in inputOperators)
            {
                MessageBox.Show(operators);
            }*/

            //if no operators
            if (inputOperators.Count() == 0)
            {
                result = Convert.ToDouble(formula);
            }
            //otherwise, do math using the input lists
            
            else if (inputOperators[0] == "+")
            {
                result = inputNumbers[0] + inputNumbers[1];
            }
            else if (inputOperators[0] == "-")
            {
                result = inputNumbers[0] - inputNumbers[1];
            }
            else if (inputOperators[0] == "*")
            {
                result = inputNumbers[0] * inputNumbers[1];
            }
            else if (inputOperators[0] == "/")
            {
                result = inputNumbers[0] / inputNumbers[1];
            }

            int i = 1;
            int j = 1;
            while (i < inputOperators.Count())
            {
                if (inputOperators[i] == "+")
                {
                    result += inputNumbers[j + 1];
                }
                if (inputOperators[i] == "-")
                {
                    result -= inputNumbers[j + 1];
                }
                if (inputOperators[i] == "*")
                {
                    result *= inputNumbers[j + 1];
                }
                if (inputOperators[i] == "/")
                {
                    result /= inputNumbers[j + 1];
                }
                i++;
                j++;
            }

            inputOperators.Clear();
            inputNumbers.Clear();
            return result;
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

    }
}
