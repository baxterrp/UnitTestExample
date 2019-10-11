using System.Collections.Generic;

namespace CalculatorApp.MVC.Models
{
    public class CalculatorViewModel
    {
        public string Operand { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Result { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
