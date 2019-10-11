using System;
using UnitTestingMVC.Models;

namespace UnitTestingMVC.Services
{
    public class CalculatorFacade : ICalculatorFacade
    {
        private readonly ICalculationService _calculatorService;

        public CalculatorFacade(ICalculationService calculationService)
        {
            _calculatorService = calculationService;
        }
        public CalculatorViewModel GetCalculation(CalculatorViewModel model)
        {
            var returnModel = new CalculatorViewModel
            {
                X = 0,
                Y = 0,
                Operand = string.Empty
            };

            try
            {
                var result = _calculatorService.Calculate(model.Operand, model.X, model.Y);
                returnModel.Result = result;
            }
            catch (InvalidOperationException ex)
            {
                returnModel.Errors.Add(ex.Message);
            }
            catch (ArgumentException ex)
            {
                returnModel.Errors.Add(ex.Message);
            }

            return returnModel;
        }
    }
}
