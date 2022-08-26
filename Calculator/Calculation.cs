﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Calculator.Calculation;

namespace Calculator
{
    internal class Calculation
    {
        public interface IOperation
        {
            double Call(params double[] args);
        }

        static double res = 0;
        public Dictionary<string, IOperation> operations;
        public List<string> oneArgumentOperation = new List<string>();
        public static int CountArguments(string arguments)
        {
            arguments = arguments.Trim();
            if (arguments.Length == 0)
            {
                return 0;
            }
            return arguments.Split().Length;
        }
        public Calculation()
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
            operations.Add("/", new Operation(Divide));
            operations.Add("sinus", new Operation(Sinus));
            operations.Add("percent", new Operation(Percent));          
        }
        private static double Sinus(double degree)
        {
            double radian;
            radian = Math.Sin(degree * Math.PI / 180);
            return radian;
        }
        public static double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                Console.WriteLine("Division by 0 is not supported!");
                return 0;
            }
            return num1 / num2;
        }
        public static double Percent(double num)
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