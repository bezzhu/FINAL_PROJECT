using System;

namespace Calculator
{

    class Calculator
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Calculator!");

            double num1 = GetNumber("Enter the first number: ");
            double num2 = GetNumber("Enter the second number: ");

            string operation = GetOperator("Choose an operation (+, -, *, /): ");

            double result;

            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    Console.WriteLine($"Result: {num1} + {num2} = {result}");
                    break;

                case "-":
                    result = num1 - num2;
                    Console.WriteLine($"Result: {num1} - {num2} = {result}");
                    break;

                case "*":
                    result = num1 * num2;
                    Console.WriteLine($"Result: {num1} * {num2} = {result}");
                    break;

                case "/":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        Console.WriteLine($"Result: {num1} / {num2} = {result}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid operation. Please use +, -, *, or /.");
                    break;
            }
        }

        static double GetNumber(string str)
        {
            double number;
            while (true)
            {
                Console.Write(str);
                string input = Console.ReadLine();

                if (double.TryParse(input, out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
        static string GetOperator(string str)
        {
            while (true)
            {
                Console.Write(str);
                string operation = Console.ReadLine();

                if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
                {
                    return operation;
                }
                else
                {
                    Console.WriteLine("Invalid operator. Please enter one of +, -, *, /.");
                }
            }
        }
    }

}
