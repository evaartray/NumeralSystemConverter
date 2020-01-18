using System;
using System.Collections.Generic;
using System.Text;

namespace NumeralSystemConverter
{
    class DecimalSystem : INumeralSystem
    {
        protected double decimalNumber {get; private set;}

        public DecimalSystem(string userInput)
        {
            decimalNumber = double.Parse(userInput);
        }

        public void ShowResult()
        {
            Console.WriteLine("In decimal: " + decimalNumber + "\n" + DecimalToBinary() + "\n" + DecimalToHex() + "\n" + DecimalToOctal());
        }

        private string DecimalToAnySystem(int Base)
        {
            string result = string.Empty;

            int Integral = (int)decimalNumber;

            double fractional = decimalNumber - Integral;

            if (Integral < 0) throw new System.IndexOutOfRangeException();  //denying negative numbers

            while (Integral > 0)
            {
                int rem = Integral % Base;

                // Append 0 in binary 
                result += (char)(rem + '0');
                //binary = rem.ToString() + binary;

                Integral /= Base;
            }
            result = Reverse(result);

            // Point before fractional 
            if (fractional != 0) result += ('.');

            // Conversion of fractional part to binary
            int Limit = 7;       //limit of digits after point
            while (true && Limit > 0)
            {
                Limit--;
                // Find next bit in fraction 
                fractional *= Base;
                int fract_bit = (int)fractional;
                if (fractional == 0) break;
                else
                {
                    result += fract_bit;
                    fractional -= fract_bit;
                }
            }
            return result;
        }

        public string DecimalToBinary()
        {
            return "In binary: " + DecimalToAnySystem(2);
        }
        public string DecimalToOctal()
        {
            return "In octal: " + DecimalToAnySystem(8);
        }
        public string DecimalToHex()
        {
            string result = string.Empty;

            int Integral = (int)decimalNumber;

            double fractional = decimalNumber - Integral;

            result += string.Format("{0:X}", Integral); //decimal to hex convertion integral part

            if (fractional != 0) result += ('.');

            // Conversion of fractional part to hex
            int Limit = 7;       //limit of digits after point
            while (true && Limit > 0)
            {
                Limit--;
                fractional *= 16;
                int fractionalBit = (int)fractional;
                if (fractional == 0) break;
                else
                {
                    result += string.Format("{0:X}", fractionalBit);
                    fractional -= fractionalBit;
                }
            }
            return "In hexadecimal: " + result;
        }

        private string Reverse(string input)
        {
            char[] temparray = input.ToCharArray();
            int left, right = 0;
            right = temparray.Length - 1;

            for (left = 0; left < right; left++, right--)
            {
                // Swap values of left and right  
                char temp = temparray[left];
                temparray[left] = temparray[right];
                temparray[right] = temp;
            }
            return string.Join("", temparray);
        }
    }
}

