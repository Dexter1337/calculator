using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationLibrary
{
    public class CalculatorOperations
    {
        public double Sinus(double degree)
        {
            double radian;
            radian = Math.Sin(degree * Math.PI / 180);
            return radian;
        }
        public double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                Console.WriteLine("Division by 0 is not supported!");
                return 0;
            }
            return num1 / num2;
        }
        public double Percent(double num)
        {
            return num / 100;
        }
    }
}
