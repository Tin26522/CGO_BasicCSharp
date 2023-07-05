using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGO_chuyendoitiente
{
    class Program
    {
        static void Main(string[] args)
        
    {
        double rate = 23000;

        Console.Write(" Nhap gia tri USD: ");
        double usdAmount = double.Parse(Console.ReadLine());

        double vndAmount = usdAmount * rate;

        Console.WriteLine(" Gia tri tuong ung VND: " + vndAmount);
    }
}
}
