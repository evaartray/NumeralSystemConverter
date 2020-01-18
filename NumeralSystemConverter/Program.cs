using System;

namespace NumeralSystemConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            MainProgram();

            static string userInput()
            {
                Console.WriteLine("Type the number below:");
                string input = Console.ReadLine();

                return input;
            }

            void MainProgram()
            {
                input = userInput();
                try 
                {
                    INumeralSystem numberSystem;
                    if (input.Length == 1) // if input contains only one number and is decimal
                    {
                        numberSystem = new DecimalSystem(input);
                        Console.WriteLine("Your number is in decimal system! We converted it to every systems: \n");
                    }

                    else if (input[0] == '0' && input[1] != 'x' && input[1] != 'X' && input[1] != ',' && input[1] != '.')   //if input is octal
                    {
                        numberSystem = new OctalSystem(input);
                        Console.WriteLine("Your number is in octal system! We converted it to every systems: \n");
                    }
                    else if (input[1] == 'x' || input[1] == 'X')  // if input is hexadecimal
                    {
                        numberSystem = new HexSystem(input);
                        Console.WriteLine("Your number is in hexadecimal system! We converted it to every systems: \n");
                    }
                    else // if number is decimal
                    {
                        numberSystem = new DecimalSystem(input);
                        Console.WriteLine("Your number is in decimal system! We converted it to other systems: \n");
                    }
                    numberSystem.ShowResult();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " Error, please try again");
                }
                LoopOfMainProgram();
            }

            void LoopOfMainProgram()
            {
                while (true)
                {
                    Console.WriteLine("Do you want to try another number? \n Type 'yes' or 'exit'");
                    string answer = Console.ReadLine();
                    if (answer == "exit") { Environment.Exit(0); break; }
                    else if (answer == "yes") { Console.Clear(); MainProgram(); break; }
                    else Console.WriteLine("Wrong input");
                }

            }
        }
    }
}
