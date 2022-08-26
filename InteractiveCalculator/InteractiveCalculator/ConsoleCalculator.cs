using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Calculator.Calculation;

namespace InteractiveCalculator
{
    internal class ConsoleCalculator
    {
        static Calculation calculation;
        public static void Main()
        {
            double res = 0;
            calculation = new Calculation();
            Console.Write("op: ");
            string operation = Console.ReadLine();
            operation = operation.Trim().ToLower();
            Console.Write("args: ");
            string arguments = Console.ReadLine();
            arguments = arguments.Trim();

            if (CountArguments(arguments) == 0 || CountArguments(arguments) > 2)
            {
                Console.WriteLine("Incorrect input");
                return;
            }
            if (calculation.oneArgumentOperation.Contains(operation))
            {
                if (CountArguments(arguments) != 1)
                {
                    Console.WriteLine("Incorrect input");
                    return;
                }
                else
                    res = calculation.operations[operation].Call(Double.Parse(arguments));
            }
            else
            {
                if (CountArguments(arguments) != 2)
                {
                    Console.WriteLine("Incorrect input");
                    return;
                }
                else
                    res = calculation.operations[operation].Call(Double.Parse(arguments.Split()[0]), Double.Parse(arguments.Split()[1]));
            }
            Console.WriteLine(res);
        }
    }
}
