using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Library
{

    
    /// <summary>
    /// Simple calculator class that performs 4 basic arithmetic operations on integers.
    /// For simplicity division returns the integer part only.
    /// </summary>
    public class Calculator
    {
        public static int Addition(int x, int y, out string error)
        {
            error = String.Empty;
            try
            {
                checked
                {
                    return x + y;
                }
            }
            catch (OverflowException e)
            {
                error = e.Message;
            }
            return 0;

        }

        public static int Subtraction(int x, int y, out string error)
        {
            error = String.Empty;
            try
            {
                checked
                {
                    return x - y;
                }
            }
            catch (OverflowException e)
            {
                error = e.Message;
            }
            return 0;
        }

        public static int Multiplication(int x, int y, out string error)
        {
            error = String.Empty;
            try
            {
                checked
                {
                    return x * y;
                }
            }
            catch (OverflowException e)
            {
                error = e.Message;
            }
            return 0;
        }

        public static int Division(int nominator, int denominator, out string error)
        {
            error = String.Empty;
            try
            {
                checked
                {
                    return nominator / denominator;
                }
            }
            catch (DivideByZeroException e)
            {
                error = e.Message;
            }
            return 0;
        }
    }
}
