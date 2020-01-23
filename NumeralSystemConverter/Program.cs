using System;
using System.Collections.Generic;

namespace NumeralSystemConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Please enter a number: ");
                string input = Console.ReadLine();
                
                CheckBase(input);

                Console.Write("\nDo you want to continue? (y/n)");
                if (AskForContinue(Console.ReadLine()))
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }
        }

        static bool AskForContinue(string ans)
        {
            bool isAgree;
            _ = (ans=="y")? isAgree= true: isAgree = false;
            return isAgree;
        }
        static public void CheckBase(string inputArray) 
        {
            List<char> inputList = new List<char>(); // check if an input is fraction
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i]=='.')
                {
                    break;
                }
                else
                {
                    inputList.Add(inputArray[i]);
                }
            }

            char[] inputArr = inputList.ToArray();
            try
            {
                INumeralSystem numeralSystem;
                if (inputArray[1] == 'x' || inputArray[1] == 'X') // if an input is hexadecimal
                {
                    numeralSystem = new HexSystem(inputArray);
                    Console.WriteLine("Your number is in hexadecimal system! We converted it to every systems: \n");
                }
                else
                {
                    if (isOctal(inputArray.ToString())&& inputArr.Length!=1) // if an input is octal
                    {
                        numeralSystem = new OctalSystem(inputArray);
                        Console.WriteLine("Your number is in octal system! We converted it to every systems: \n");
                    }
                    else
                    {
                        numeralSystem = new DecimalSystem(inputArray); // if an input is decimal
                        Console.WriteLine("Your number is in decimal system! We converted it to other systems: \n");
                    }
                }
                numeralSystem.ShowResult();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\nWrong input, please try again");
            }
        }

        static bool isOctal(string input) // test for octal input
        {
            bool testOctal = true;
            int n;
            if (input[0] != '0')
            {
                return false;
            }
            else
            {
                foreach (var item in input)
                {
                    bool checkNum = int.TryParse(item.ToString(), out n);
                    if ( checkNum && n>7)
                    {
                        testOctal = false;
                        break;
                    }
                }
            }
            return testOctal;
        }
    }
}
