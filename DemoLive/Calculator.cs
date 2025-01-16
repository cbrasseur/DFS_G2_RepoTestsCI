using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLive
{
    public class Calculator
    {
        public int Add(int numberOne, int numberTwo)
        {
            return numberOne + numberTwo;
        }

        public int Subtract(int numberOne, int numberTwo)
        {
            return numberOne - numberTwo;
        }

        public int Multiply(int numberOne, int numberTwo)
        {
            return numberOne * numberTwo;
        }

        public float Divide(int numberOne, int numberTwo)
        {
            if (numberTwo == 0)
                throw new CustomException("Cannot divide by zero");

            return (float)numberOne / numberTwo;
        }
    }

    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }
    }
}
