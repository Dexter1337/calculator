using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Calculator.Calculation;

namespace Calculator
{
    internal class Calculation
    {
        internal interface IOperation
        {
            double Call(params double[] args);
        }

        internal Dictionary<string, IOperation> operations;
        internal List<string> oneArgumentOperation = new List<string>();
        private static int CountArguments(string arguments)
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
            operations.Add("/", new Operation(Divide));
            operations.Add("sinus", new Operation(Sinus));
            operations.Add("cosinus", new Operation(Cosinus));
            operations.Add("tangens", new Operation(Tangens));
            operations.Add("cotangens", new Operation(Cotangens));
            operations.Add("%", new Operation(Percent));        
        }
        private static double Sinus(double degree)
        {
            double radian;
            radian = Math.Sin(degree * Math.PI / 180);
            return radian;
        }
        private static double Cosinus(double degree)
        {
            double radian;
            radian = Math.Cos(degree * Math.PI / 180);
            return radian;
        }
        private static double Tangens(double degree)
        {
            double radian;
            radian = Math.Tan(degree * Math.PI / 180);
            return radian;
        }
        private static double Cotangens(double degree)
        {
            double radian;
            radian = 1 / Math.Tan(degree * Math.PI / 180);
            return radian;
        }
        private static double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                Console.WriteLine("Division by 0 is not supported!");
                return 0;
            }
            return num1 / num2;
        }
        private static double Percent(double num)
        {
            return num / 100;
        }
    }
    class Operation : IOperation
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
