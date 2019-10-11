using UnitTestingMVC.Models;

namespace UnitTestingMVC.Services
{
    public interface ICalculatorFacade
    {
        CalculatorViewModel GetCalculation(CalculatorViewModel model);
    }
}
