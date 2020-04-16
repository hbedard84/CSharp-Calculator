using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _200443133A2
{
    class MemoryCalculator
    {
        Double memory;

        /// <summary>
        /// Clears the stored memory and sets the value to NaN (not a number) 
        /// </summary>
        public void MemoryClear()
        {
            memory = double.NaN;
        }

        /// <summary>
        /// Displays the current value of the stored memory variable
        /// </summary>
        /// <returns>memory value</returns>
        public double MemoryRecall()
        {
            return memory;
        }

        /// <summary>
        /// Saves the calculated result of the current formula as the stored memory value
        /// </summary>
        /// <param name="memoryInput"></param>
        public void MemorySave(double memoryInput)
        {
            memory = memoryInput;
        }

        /// <summary>
        /// Adds the calculated result of the current formula to the current stored memory value 
        /// </summary>
        /// <param name="memoryInput"></param>
        /// <returns>double memory = the total value of the memory storage</returns>
        public double MemoryPlus(double memoryInput)
        {
            memory += memoryInput;
            return memory;
        }
    }
}
