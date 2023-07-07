using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cannangcothe
{
    class Program
    {
        static void Main(string[] args)
        {
            double height;
            double weight;
            Console.WriteLine("Nhap chieu cao cua ban : ");
            height = float.Parse(Console.ReadLine());
            Console.WriteLine("Nhap can nang cua ban : ");
            weight = float.Parse(Console.ReadLine());
            //tinh bmi
            double bmi = weight / Math.Pow(height, 2);
            bmi = Math.Round(bmi, 1);
            //hien thi 

            Console.Write("BMI: " + bmi);

            if (bmi < 18)
                Console.WriteLine(" Underweight");
            else if (bmi < 25.0)
                Console.WriteLine(" Normal");
            else if (bmi < 30.0)
                Console.WriteLine(" Overweight");
            else
                Console.WriteLine(" Obese");
        }
    }
}
