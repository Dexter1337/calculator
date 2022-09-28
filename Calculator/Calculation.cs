using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Calculator.Calculation;
using CalculationLibrary;


namespace Calculator
{
    internal class Calculation
    {
        CalculatorOperations library = new  CalculatorOperations();
        internal interface IOperation
        {
            double Call(params double[] args);
        }
        internal Dictionary<string, IOperation> operations;
        internal List<string> oneArgumentOperation = new List<string>(); 
        internal Calculation()
        {
            
            oneArgumentOperation.Add("sinus");
            oneArgumentOperation.Add("cosinus");
            oneArgumentOperation.Add("tangens");
            oneArgumentOperation.Add("cotangens");
            oneArgumentOperation.Add("percent");

            operations = new Dictionary<string, IOperation>();
            operations.Add("+", new Operation((a, b) => a + b));
            operations.Add("-", new Operation((a, b) => a - b));
            operations.Add("*", new Operation((a, b) => a * b));
            operations.Add("/", new Operation(library.Divide));
            operations.Add("sinus", new Operation(library.Sinus));
            operations.Add("percent", new Operation(library.Percent));          
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
