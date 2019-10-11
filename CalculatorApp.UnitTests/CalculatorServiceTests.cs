using CalculatorApp.MVC.Services;
using System;
using Xunit;

namespace CalculatorApp.UnitTests
{
    public class CalculatorServiceTests
    {
        private readonly ICalculationService _calculatorService;

        public CalculatorServiceTests()
        {
            _calculatorService = new CalculatorService();
        }

        [Fact]
        public void OnePlusTwoReturnsThree()
        {
            // Arrange
            var x = 1;
            var y = 2;
            var expectedResult = 3;
            var operand = "+";

            // Act
            var actualResult = _calculatorService.Calculate(operand, x, y);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ThreeMinusTwoReturnsOne()
        {
            // Arrange
            var x = 3;
            var y = 2;
            var expectedResult = 1;
            var operand = "-";

            // Act
            var actualResult = _calculatorService.Calculate(operand, x, y);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ThreeTimesTwoReturnsSix()
        {
            // Arrange
            var x = 3;
            var y = 2;
            var expectedResult = 6;
            var operand = "*";

            // Act
            var actualResult = _calculatorService.Calculate(operand, x, y);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TwelveDividedByTwoReturnsSix()
        {
            // Arrange
            var x = 12;
            var y = 2;
            var expectedResult = 6;
            var operand = "/";

            // Act
            var actualResult = _calculatorService.Calculate(operand, x, y);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void CalculateThrowsExceptionWhenDividingByZero()
        {
            // Arrange
            var x = 12;
            var y = 0;
            var operand = "/";

            // Act
            Action action = () => _calculatorService.Calculate(operand, x, y);

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(action);
            Assert.Equal("Cannot divide by zero", ex.Message);
        }

        [Theory]
        [InlineData("?")]
        [InlineData("1")]
        [InlineData("#")]
        [InlineData("^")]
        [InlineData("wioaefjawefjc")]
        [InlineData("0")]
        public void CalculateThrowsExceptionWHenGivenINvalidOperand(string invalidOperand)
        {
            // Arrange
            var x = 12;
            var y = 2;

            // Act
            Action action = () => _calculatorService.Calculate(invalidOperand, x, y);

            // Assert
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal($"{invalidOperand} is not a valid operand", ex.Message);
        }
    }
}
