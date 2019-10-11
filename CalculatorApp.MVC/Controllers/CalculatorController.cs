using CalculatorApp.MVC.Models;
using CalculatorApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.MVC.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorFacade _calculatorFacade;

        public CalculatorController(ICalculatorFacade calcalatorFacade)
        {
            _calculatorFacade = calcalatorFacade;
        }

        public IActionResult Calculate(CalculatorViewModel model)
        {
            if(!(string.IsNullOrWhiteSpace(model?.Operand) && model?.X == 0 && model?.Y == 0))
            {
                model = _calculatorFacade.GetCalculation(model);
            }

            return View(model);
        }
    }
}
