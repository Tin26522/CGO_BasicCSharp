using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songuyento

{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            Console.WriteLine("Enter a number: ");
            number = Convert.ToInt32(Console.ReadLine());

            if (number < 2)
            {
                Console.WriteLine(number + " khong phai la so nguyen to");
            }
            else
            {
                int i = 2;
                bool isPrime = true;
                while (i <= Math.Sqrt(number))
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    i++;
                }

                if (isPrime)
                {
                    Console.WriteLine(number + " la so nguyen to");
                }
                else
                {
                    Console.WriteLine(number + " khong phai la so nguyen to");
                }
            }
        }
    }
}
