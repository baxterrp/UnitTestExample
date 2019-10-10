using System;

namespace UnitTestingMVC.Services
{
    public class CalculatorService : ICalculationService
    {
        public double Calculate(string operand, double x, double y)
        {
            switch (operand)
            {
                case "+":return x + y;
                case "-":return x - y;
                case "*":return x * y;
                case "/":
                    if (y == 0)
                    {
                        throw new InvalidOperationException("Cannot divide by zero");
                    }

                    return x / y;
                default: throw new ArgumentException($"{operand} is not a valid operand");
            }
        }
    }
}
