using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200443133A2
{
    class MemoryCalculator
    {
        Double memory;
        public void MemoryClear()
        {
            memory = double.NaN;
        }

        public double MemoryRecall()
        {
            return memory;
        }

        public void MemorySave(double memoryInput)
        {
            memory = memoryInput;
            
        }

        public double MemoryPlus(double memoryInput)
        {
            memory += memoryInput;
            return memory;
        }
    }
}
