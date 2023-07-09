using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timgtmang
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] students = { "Christian", "Michael", "Camila", "Sienna", "Tanya", "Connor", "Zachariah", "Mallory", "Zoe", "Emily" };
            Console.WriteLine("Nhap Ten cua sinh vien :");
            string name = Console.ReadLine();
            //Duyệt mảng
            bool isExist = false;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Equals(name))
                {
                    Console.WriteLine("Vi tri cua ten " + name + " trong danh sach la " + (i + 1));
                    isExist = true;
                    break;
                }
            }
            if (!isExist)
            {
                Console.WriteLine("Khong tim thay ten " + name + " trong danh sach ");
            }
        }
    }
}
