using System;
using System.Collections.Generic;
using System.Text;

namespace NumeralSystemConverter
{
    class HexSystem : INumeralSystem
    {
        public string hexNumber { get; set; }

        public HexSystem(string newHexNumber)
        {
            this.hexNumber = newHexNumber;
        }

        public double HexToDec()
        {
            double result = 0;
            string FractionalPart = string.Empty;
            string IntegralPart;

            if (hexNumber.Contains(','))        //splitting fraction input
            {
                string[] SplittedNumber = hexNumber.Split(',');

                IntegralPart = SplittedNumber[0];
                FractionalPart = SplittedNumber[1];
            }
            else IntegralPart = hexNumber;

            int count = IntegralPart.Length - 1;
            for (int i = 0; i < IntegralPart.Length; i++)
            {
                int temp = 0;
                switch (IntegralPart[i])
                {
                    case 'x': break;
                    case 'A': temp = 10; break;
                    case 'B': temp = 11; break;
                    case 'C': temp = 12; break;
                    case 'D': temp = 13; break;
                    case 'E': temp = 14; break;
                    case 'F': temp = 15; break;
                    default: temp = -48 + (int)IntegralPart[i]; break;      // -48 because of ASCII
                }

                result += temp * (int)(Math.Pow(16, count));
                count--;
            }

            // Converting fractional part
            if (FractionalPart != string.Empty)
            {
                string tempResult = result.ToString();
                tempResult += '.';
                for (int i = 0; i < 16; ++i)
                {
                    double FractionalValue = result - Math.Truncate(result);     //determining integral part to use only fractional
                    FractionalValue = FractionalValue * 16;
                    int digit = (int)FractionalValue;

                    tempResult += digit.ToString("X");

                    FractionalValue = FractionalValue - digit;

                    if (FractionalValue == 0)
                    {
                        break;
                    }
                    tempResult = result.ToString();
                }
            }
            return result;
        }

        public void ShowResult()
        {
            Console.WriteLine("In hexadecimal: " + hexNumber);
            Console.WriteLine("In decimal: " + HexToDec());
            double result = HexToDec();
            DecimalSystem decimalSystem = new DecimalSystem(result.ToString());
            Console.WriteLine(decimalSystem.DecimalToBinary());
            Console.WriteLine(decimalSystem.DecimalToOctal());
        }
    }
}
