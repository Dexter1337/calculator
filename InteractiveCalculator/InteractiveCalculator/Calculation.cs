using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculationLibrary;
using static Calculator.Calculation;

namespace Calculator
{
    internal class Calculation
    {
        internal interface IOperation
        {
            double Call(params double[] args);
        }
        CalculatorOperations library = new CalculatorOperations();
        internal Dictionary<string, IOperation> operations;
        internal List<string> oneArgumentOperation = new List<string>();
        internal static int CountArguments(string arguments)
        {
            arguments = arguments.Trim();
            if (arguments.Length == 0)
            {
                return 0;
            }
            return arguments.Split().Length;
        }
        internal Calculation()
        {
            oneArgumentOperation.Add("sinus");
            oneArgumentOperation.Add("cosinus");
            oneArgumentOperation.Add("tangens");
            oneArgumentOperation.Add("cotangens");
            oneArgumentOperation.Add("%");

            operations = new Dictionary<string, IOperation>();
            operations.Add("+", new Operation((a, b) => a + b));
            operations.Add("-", new Operation((a, b) => a - b));
            operations.Add("*", new Operation((a, b) => a * b));
            operations.Add("/", new Operation(library.Divide));
            operations.Add("sinus", new Operation(library.Sinus));
            operations.Add("%", new Operation(library.Percent));
        }
    }
    internal class Operation : IOperation
    {
        Func<double, double, double> operation;
        private Func<double, double> sinus;

        public Operation(Func<double, double, double> operation)
        {
            this.operation = operation;
        }

        public Operation(Func<double, double> sinus)
        {
            this.sinus = sinus;
        }
        public double Call(params double[] args)
        {
            if (args.Length == 1)
            {
                return sinus(args[0]);
            }
            else
            {
                return operation(args[0], args[1]);
            }
        }   
    }
}
