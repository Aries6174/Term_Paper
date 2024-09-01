using System; // Common C# habit and etiquette

class Program
{
    static void Main()
    {
        bool running = true; // Starting loop for the while statement
        Console.WriteLine("Thank you for using the Calculator made in C#.\n"); // Introduction

        // Beginning of the Calculator, asks for the user which operation and so on.
        while (running)
        {
            try
            {
                Console.Write(@"
                What Operation would you like to use:
                1.) Addition
                2.) Subtraction
                3.) Multiplication
                4.) Division
                5.) SquareRoot
                0.) Exit
                
                -> ");

                string choice = Console.ReadLine()!; // ReadLine is Input

                if (!int.TryParse(choice, out int number) || number < 0 || number > 5) // Checks if the input is not null and is a string that CAN BE CONVERTED TO INTEGER. C# does not have a ReadInteger input somehow.
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 5.");
                    continue;
                }

                //Switch case for easier typing on all potential possibilities.
                switch (number)
                {
                    case 0:
                        running = false;
                        break;
                    //all four cases must be together for the meantime since all of them require 2 operands
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        Console.Write("Enter the first Operand: ");
                        string input1 = Console.ReadLine()!;

                        if (!int.TryParse(input1, out int op1))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                            continue;
                        }

                        Console.Write("Enter the second Operand: ");
                        string input2 = Console.ReadLine()!;

                        if (!int.TryParse(input2, out int op2))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                            continue;
                        }

                        try
                        {
                            //Switching on which operand will be used
                            int result = number switch
                            {
                                1 => Add(op1, op2),
                                2 => Sub(op1, op2),
                                3 => Mul(op1, op2),
                                4 when op2 != 0 => Div(op1, op2),
                                4 => throw new DivideByZeroException("Cannot divide by zero."),
                                _ => throw new InvalidOperationException("Unexpected operation.")
                            };

                            Console.WriteLine($"The result is {result}");
                        }
                        catch (DivideByZeroException ex) //Divided by 0
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        catch (Exception ex) //If a possible exception happens
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    //SquareRoot only requires 1 operand 
                    case 5:
                        Console.Write("Enter the number to find the square root: ");
                        string sqrtInput = Console.ReadLine()!;

                        if (!double.TryParse(sqrtInput, out double x))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            continue;
                        }

                        try
                        {
                            if (x < 0)
                            {
                                throw new ArgumentException("Cannot compute the square root of a negative number.");
                            }

                            double sqrtResult = basicSqrt(x);
                            Console.WriteLine($"The square root is {sqrtResult}");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        break;
                    default:
                        Console.WriteLine("Please choose a valid operation number.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        Console.WriteLine("\nGoodbye\n");
    }

    // Methods for the calculator. (Addition, Subtraction, etc.)
    static int Add(int x, int y) => x + y;
    static int Sub(int x, int y) => x - y;
    static int Mul(int x, int y) => x * y;
    static int Div(int x, int y) => x / y;
    static double basicSqrt(double x) => Math.Sqrt(x);
}
