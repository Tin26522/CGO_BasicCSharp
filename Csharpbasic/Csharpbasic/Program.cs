using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpbasic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập Tên Của Bạn: ");
            string hoten = Console.ReadLine();
            Console.WriteLine("Tên của bạn là " + hoten) ;

        }
    }
}
