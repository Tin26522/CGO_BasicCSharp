using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docso
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap so can doc (tu 0--->999):");
            int number = int.Parse(Console.ReadLine());

            if (number < 0 || number > 999)
            {
                Console.WriteLine("So khong hop le ! ");
                return;
            }

            string result = "";

            if (number < 10)
            {
                result = sonhohon10(number);
            }
            else if (number < 20)
            {
                result = sonhohon20(number);
            }
            else if (number < 100)
            {
                int tens = number / 10;
                int ones = number % 10;

                result = sochiahetcho10(tens) + " " + sonhohon10(ones);
            }
            else
            {
                int hundreds = number / 100;
                int remaining = number % 100;

                result = sonhohon10(hundreds) + " hundred";

                if (remaining != 0)
                {
                    result += " and " + ReadNumber(remaining);
                }
            }

            Console.WriteLine(result);
        }

        public static string sonhohon10(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "";
            }
        }

        public static string sonhohon20(int number)
        {
            switch (number)
            {
                case 10:
                    return "ten";
                case 11:
                    return "eleven";
                case 12:
                    return "twelve";
                case 13:
                    return "thirteen";
                case 14:
                    return "fourteen";
                case 15:
                    return "fifteen";
                case 16:
                    return "sixteen";
                case 17:
                    return "seventeen";
                case 18:
                    return "eighteen";
                case 19:
                    return "nineteen";
                default:
                    return "";
            }
        }

        public static string sochiahetcho10(int tens)
        {
            switch (tens)
            {
                case 2:
                    return "twenty";
                case 3:
                    return "thirty";
                case 4:
                    return "forty";
                case 5:
                    return "fifty";
                case 6:
                    return "sixty";
                case 7:
                    return "seventy";
                case 8:
                    return "eighty";
                case 9:
                    return "ninety";
                default:
                    return "";
            }
        }

        public static string ReadNumber(int number)
        {
            if (number < 10)
            {
                return sonhohon10(number);
            }
            else if (number < 20)
            {
                return sonhohon20(number);
            }
            else if (number < 100)
            {
                int tens = number / 10;
                int ones = number % 10;

                return sochiahetcho10(tens) + " " + sonhohon10(ones);
            }

            return "";
        }
    }
}
