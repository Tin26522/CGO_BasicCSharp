using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hienthihinhhoc
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Print the rectangle");
                Console.WriteLine("2. Print the square triangle (top-left)");
                Console.WriteLine("3. Print the square triangle (top-right)");
                Console.WriteLine("4. Print the square triangle (bottom-left)");
                Console.WriteLine("5. Print the square triangle (bottom-right)");
                Console.WriteLine("6. Print the isosceles triangle");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        PrintRectangle();
                        break;
                    case 2:
                        PrintSquareTriangleTopLeft();
                        break;
                    case 3:
                        PrintSquareTriangleTopRight();
                        break;
                    case 4:
                        PrintSquareTriangleBottomLeft();
                        break;
                    case 5:
                        PrintSquareTriangleBottomRight();
                        break;
                    case 6:
                        PrintIsoscelesTriangle();
                        break;
                    case 0:
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Console.WriteLine();
            } while (choice != 0);
        }

        public static void PrintRectangle()
        {
            int width, height;
            Console.WriteLine("Enter the width of the rectangle: ");
            width = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the height of the rectangle: ");
            height = int.Parse(Console.ReadLine());

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintSquareTriangleTopLeft()
        {
            int n;
            Console.WriteLine("Enter the number of rows: ");
            n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintSquareTriangleTopRight()
        {
            int n;
            Console.WriteLine("Enter the number of rows: ");
            n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write("  ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintSquareTriangleBottomLeft()
        {
            int n;
            Console.WriteLine("Enter the number of rows: ");
            n = int.Parse(Console.ReadLine());

            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintSquareTriangleBottomRight()
        {
            int n;
            Console.WriteLine("Enter the number of rows: ");
            n = int.Parse(Console.ReadLine());

            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write("  ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintIsoscelesTriangle()
        {
            int n;
            Console.WriteLine("Enter the number of rows: ");
            n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write("  ");
                }
                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
