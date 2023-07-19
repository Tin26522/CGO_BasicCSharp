using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timPhanTuLonNhat
{
    class Program
    {
        static void Main(string[] args)
        {
            


            Console.Write("Nhap so hang cua ma tran: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Nhap so cot cua ma tran: ");
            int cols = int.Parse(Console.ReadLine());

            double[,] matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Nhap gia tri tai vi tri [{i},{j}]: ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }

            double maxElement = matrix[0, 0];
            int maxRow = 0;
            int maxCol = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            Console.WriteLine("Ma tran ban vua nhap la:");
            PrintMatrix(matrix, rows, cols);

            Console.WriteLine($"Gia tri lon nhat cua ma tran la {maxElement} tai vi tri [{maxRow},{maxCol}].");
        }

        static void PrintMatrix(double[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
