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

                Console.Write("\nDo you want to continue(y/n): ");
                if (askForContinue(Console.ReadLine()))
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

        static bool askForContinue(string ans)
        {
            
            bool isAgree;
            _ = (ans=="y")? isAgree= true: isAgree = false;
            return isAgree;
        }
        static public void CheckBase(string inputArray)
        {
            List<char> inputList = new List<char>();
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
                INumeralSystem numberSystem;
                if (inputArray[1] == 'x' || inputArray[1] == 'X') // if input contains only one number and is decimal
                {
                    numberSystem = new HexSystem(inputArray);
                    Console.WriteLine("Your number is in hexadecimal system! We converted it to every systems: \n");
                }
                else
                {
                    if (isOctal(inputArray.ToString())&& inputArr.Length!=1 )
                    {
                        numberSystem = new OctalSystem(inputArray);
                        Console.WriteLine("Your number is in octal system! We converted it to every systems: \n");
                    }
                    else
                    {
                        numberSystem = new DecimalSystem(inputArray);
                        Console.WriteLine("Your number is in decimal system! We converted it to other systems: \n");
                    }
                };
                
               
                numberSystem.ShowResult();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Error, please try again");
            }
        }
        static bool isOctal(string input)
        {
            //return Regex.IsMatch(numInput, @"^0[1-7][0-7]{0,6}$");
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

        static bool isFractional(string input) //check if input is fractional
        {
            bool isFraction = false;
            foreach (char d in input)
            {
                if (d == '.')
                {
                    isFraction = true;
                    break;
                }
            }
            return isFraction;
        }


    }
}
