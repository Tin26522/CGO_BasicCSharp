using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapxepmang

{
    class Program
    {
        

        public static int[] increase(int [] arr)
        {
            int i, j, tmp;
            for (i = 0; i < arr.Length; i++)
            {
                for (j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        
                        tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
                }
            }
            return arr;


        }
        public static void decrease(int[] arr)
        {




        }
        static void Main(string[] args)
        {
            //Nhập mảng 
          
            Console.WriteLine("Nhap so luong phan tu");
            int n = int.Parse(Console.ReadLine());
            int[] arrnumber = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap gia tri thu {0}: ", i);
                arrnumber[i] = int.Parse(Console.ReadLine());
            }
            foreach (int item in arrnumber)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(increase(arrnumber));
        }
    }
}
