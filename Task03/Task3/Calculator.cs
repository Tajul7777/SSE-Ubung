using System;
using Xunit;

namespace Task3
{
    public class Calculator
    {
        private IResultWriter _resultWriter;

        public Calculator(IResultWriter rw)
        {
            _resultWriter = rw;
        }

        public double Multiply(double lhs, double rhs)
        {
            var result = lhs * rhs;
            _resultWriter.WriteResult(result);
            return result;
        }

        public double Divide(double lhs, double rhs)
        {
            double result;
            if (rhs == 0)
            {
                result = double.NaN;
            }
            else
            {
                result = lhs / rhs;
            }
            _resultWriter.WriteResult(result);
            return result;
        }
    }
}
