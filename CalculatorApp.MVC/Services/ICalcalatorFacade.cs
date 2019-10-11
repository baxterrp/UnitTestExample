using CalculatorApp.MVC.Models;

namespace CalculatorApp.MVC.Services
{
    public interface ICalculatorFacade
    {
        CalculatorViewModel GetCalculation(CalculatorViewModel model);
    }
}
