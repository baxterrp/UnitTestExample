using Moq;
using System;
using System.Linq;
using UnitTestingMVC.Models;
using UnitTestingMVC.Services;
using Xunit;

namespace TestProj
{
    public class CalculatorFacadeTests
    {
        private readonly ICalculatorFacade _calcalatorFacade;
        private Mock<ICalculationService> _calculatorService;

        public CalculatorFacadeTests()
        {
            _calculatorService = new Mock<ICalculationService>();
            _calcalatorFacade = new CalculatorFacade(_calculatorService.Object);
        }

        [Fact]
        public void FacadeReturnsCorrectResultWithOnePlusTwo()
        {
            // Arrange
            var model = new CalculatorViewModel()
            {
                Operand = "+",
                X = 1,
                Y = 2
            };

            var expectedResult = 3;

            _calculatorService.Setup(service => service.Calculate("+", 1, 2)).Returns(3);

            // Act
            var actualResult = _calcalatorFacade.GetCalculation(model);

            // Assert
            Assert.Equal(expectedResult, actualResult.Result);
            _calculatorService.Verify(service => service.Calculate("+", 1, 2), Times.Once);
        }

        [Fact]
        public void TenMinusEightReturnsTwo()
        {
            // Arrange
            var model = new CalculatorViewModel()
            {
                Operand = "-",
                X = 10,
                Y = 8
            };

            var expectedResult = 2;

            _calculatorService.Setup(service => service.Calculate("-", 10, 8)).Returns(2);

            // Act
            var actualResult = _calcalatorFacade.GetCalculation(model);

            // Assert
            Assert.Equal(expectedResult, actualResult.Result);

            _calculatorService.Verify(service => service.Calculate(
                It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>()));
        }

        [Fact]
        public void FacadePopulatesErrorWhenDividingByZero()
        {
            // Arrange
            var model = new CalculatorViewModel()
            {
                Operand = "/",
                X = 10,
                Y = 0
            };
            _calculatorService.Setup(service => service.Calculate("/", 10, 0))
                .Throws(new InvalidOperationException("Cannot divide by zero"));

            // Act
            var result = _calcalatorFacade.GetCalculation(model);

            Assert.True(result.Errors.Any());
            Assert.Contains(result.Errors, error => error == "Cannot divide by zero");
        }
    }
}
