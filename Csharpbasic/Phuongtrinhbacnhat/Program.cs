using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phuongtrinhbacnhat
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Nhap a va b");
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            if (a != 0)
            {
                double solution = -b / a;
                Console.WriteLine("Ket qua la: {0}!", solution);

            }
            else
            {
                if (b == 0)
                {
                    Console.WriteLine("phuong trinh vo so nghiem");
                }
                else
                {
                    Console.WriteLine("phuong trinh vo nhghiem");
                }
            }
        }
    }
}
