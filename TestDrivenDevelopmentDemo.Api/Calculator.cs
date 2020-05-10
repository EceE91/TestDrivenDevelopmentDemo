using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentDemo.Api
{
    public class Calculator: ICalculatorService
    {
        public double Add(double value1, double value2)
        {
            return value1 + value2;
        }

        public double Subtract(double value1, double value2)
        {
            return value1 - value2;
        }

        public double Multiply(double value1, double value2)
        {
            return value1 * value2;
        }

        public double Divide(double value1, double value2)
        {
            if (value2 == 0.0)
                throw new InvalidOperationException("Argument cannot be zero");

            return value1 / value2;
        }
    }
}
