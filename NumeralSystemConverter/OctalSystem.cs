using System;
using System.Collections.Generic;
using System.Text;

namespace NumeralSystemConverter
{
    class OctalSystem: INumeralSystem
    {
        public double octNumber { get; private set; }

        public OctalSystem(string hexNumber)
        {
            octNumber = double.Parse(hexNumber);
        }

        public string octalToDecimal()
        {
            int num = (int)octNumber;
            double decValue = 0;

            int baseToPowerNum = 1;     // initalising i.e 8^1 

            int temp = num;
            while (temp > 0)
            {
                int lastDigit = temp % 10;
                if (lastDigit > 8) throw new IndexOutOfRangeException();
                temp /= 10;

                // Multiplying last digit with base and saving it
                decValue += lastDigit * baseToPowerNum;

                baseToPowerNum *= 8;
            }
            string result = decValue.ToString();


            //double fractional = octNumber - (double)num;
            double fractional = octNumber - Math.Truncate(octNumber);
            //double fractional = octNumber % 1;

            if (fractional != 0) result += (',');

            // Conversion of fractional part
            int Limit = 5;       //limit of digits after point
            while (true && Limit > 0)
            {
                Limit--;
                fractional *= 8;
                int fractionalBit = (int)fractional;
                if (fractional == 0) break;
                else
                {
                    result += fractionalBit;
                    fractional -= fractionalBit;
                }
            }
            return result;

        }
        public void ShowResult()
        {
            Console.WriteLine("In octal: " + octNumber);
            Console.WriteLine("In decimal: " + octalToDecimal());
            string Result = octalToDecimal();
            DecimalSystem dec = new DecimalSystem(Result);
            Console.WriteLine(dec.DecimalToBinary());
            Console.WriteLine(dec.DecimalToHex());
        }
    }
    
}
