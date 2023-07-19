using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tongDuongCheo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap kich thuoc cua ma tran vuong: ");
            int size = int.Parse(Console.ReadLine());

            double[,] matrix = new double[size, size];

            // Nhập các giá trị của ma trận từ người dùng
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"Nhap gia tri tai vi tri [{i}, {j}]: ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }

            // Tính tổng đường chéo chính
            double sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine("Ma tran vuong ban vua nhap la:");
            PrintMatrix(matrix, size);

            Console.WriteLine($"Tong cac phan tu tren duong cheo chinh la: {sum}");
        }

        static void PrintMatrix(double[,] matrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
