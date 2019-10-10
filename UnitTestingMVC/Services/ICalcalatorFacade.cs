using UnitTestingMVC.Models;

namespace UnitTestingMVC.Services
{
    public interface ICalcalatorFacade
    {
        CalculatorViewModel GetCalculation(CalculatorViewModel model);
    }
}
