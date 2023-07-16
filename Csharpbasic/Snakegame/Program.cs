using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snakegame
{
    class Program
    {
        // Parameter
        public Random rand = new Random();
        public ConsoleKeyInfo keypress = new ConsoleKeyInfo();
        int score, headX, headY, fruitX, fruitY, nTail;
        int[] TailX = new int[100];
        int[] TailY = new int[100];
        const int height = 20;
        const int width = 60;
        const int panel = 10;
        bool gameOver, reset, isprinted, horizontal, vertical;
        string dir, pre_dir;
        ConsoleColor wallColor = ConsoleColor.Green;
        ConsoleColor fruitColor = ConsoleColor.Red;
        ConsoleColor headColor = ConsoleColor.Yellow;
        ConsoleColor bodyColor = ConsoleColor.White;

        //Hien thi man hinh bat dau
        void ShowBanner()
        {
            Console.SetWindowSize(width, height + panel);
            Console.CursorVisible = false;
            Console.WriteLine("===SNAKE GAME===");
            Console.WriteLine("Huong dan choi game: ");
            Console.WriteLine("- Nhan phim bat ky de choi");
            Console.WriteLine("- Nhan phim P de tam dung choi");
            Console.WriteLine("- Nhan phim R de choi lai van moi");
            Console.WriteLine("- Nhan phim Q de ngung choi");
            keypress = Console.ReadKey();
            if (keypress.Key == ConsoleKey.Q) Environment.Exit(0);
        }

        //Cai dat thong so ban dau game
        void Setup()
        {
            dir = "RIGHT"; pre_dir = "";
            score = 0; nTail = 0;
            gameOver = reset = isprinted = false;
            headX = 30;
            headY = 10;
            randomQua();
        }

        //Sinh ngau nhien diem an qua
        void randomQua()
        {
            fruitX = rand.Next(1, width - 1);
            fruitY = rand.Next(1, height - 1);
        }

        //Cap nhat man hinh khi thao tac
        void Update()
        {
            while (!gameOver)
            {
                CheckInput();
                Logic();
                Render();

                if (reset) break;
                Thread.Sleep(100);
            }
            if (gameOver) Lose();
        }

        //Dieu khien phim
        void CheckInput()
        {
            while (Console.KeyAvailable)
            {
                keypress = Console.ReadKey();
                pre_dir = dir;
                switch (keypress.Key)
                {
                    case ConsoleKey.LeftArrow: dir = "LEFT"; break;
                    case ConsoleKey.RightArrow: dir = "RIGHT"; break;
                    case ConsoleKey.DownArrow: dir = "DOWN"; break;
                    case ConsoleKey.UpArrow: dir = "UP"; break;

                    case ConsoleKey.P: dir = "STOP"; break;
                    case ConsoleKey.Q: Environment.Exit(0); break;
                }
            }
        }

        //Kiem tra phim nhan dieu huong
        void Logic()
        {
            int preX = TailX[0], preY = TailY[0];
            int tempX, tempY;

            if (dir != "STOP")
            {
                TailX[0] = headX; TailY[0] = headY;

                for (int i = 1; i < nTail; i++)
                {
                    tempX = TailX[i]; tempY = TailY[i];
                    TailX[i] = preX; TailY[i] = preY;
                    preX = tempX; preY = tempY;
                }
            }
            switch (dir)
            {
                case "LEFT": headX--; break;
                case "RIGHT": headX++; break;
                case "UP": headY--; break;
                case "DOWN": headY++; break;
                case "STOP":
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("===SNAKE GAME===");
                            Console.WriteLine("Dang tam dung choi game!");
                            Console.WriteLine("- Nhan phim P de tiep tuc choi");
                            Console.WriteLine("- Nhan phim R de choi lai van moi");
                            Console.WriteLine("- Nhan phim Q de ngung choi");

                            keypress = Console.ReadKey();
                            if (keypress.Key == ConsoleKey.Q) Environment.Exit(0);
                            if (keypress.Key == ConsoleKey.R)
                            {
                                reset = true; break;
                            }
                            if (keypress.Key == ConsoleKey.P)
                                break;
                        }
                    }
                    dir = pre_dir; break;
            }

            if (headX <= 0 || headX >= width - 1 || headY <= 0 || headY >= height - 1)
                gameOver = true;
            else gameOver = false;

            if (headX == fruitX && headY == fruitY)
            {
                score += 2;
                nTail++;
                randomQua();
            }

            if (((dir == "LEFT" && pre_dir != "UP") && (dir == "LEFT" && pre_dir != "DOWN")) || ((dir == "RIGHT" && pre_dir != "UP") && (dir == "RIGHT" && pre_dir != "DOWN")))
                horizontal = true;
            else horizontal = false;

            if (((dir == "UP" && pre_dir != "LEFT") && (dir == "UP" && pre_dir != "RIGHT")) || ((dir == "DOWN" && pre_dir != "LEFT") && (dir == "DOWN" && pre_dir != "RIGHT")))
                vertical = true;
            else vertical = false;

            for (int i = 1; i < nTail; i++)
            {
                if (headX == TailX[i] && headY == TailY[i])
                {
                    if (horizontal || vertical) gameOver = false;
                    else gameOver = true;
                }
                if (fruitX == TailX[i] && fruitY == TailY[i])
                    randomQua();
            }
        }

        //Hien thi thay doi man hinh
        void Render()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height - 1)
                        Console.ForegroundColor = wallColor;
                    else if (j == 0 || j == width - 1)
                        Console.ForegroundColor = wallColor;
                    else if (fruitX == j && fruitY == i)
                    {
                        Console.ForegroundColor = fruitColor;
                        Console.Write("?");
                    }
                    else if (headX == j && headY == i)
                    {
                        Console.ForegroundColor = headColor;
                        Console.Write("0");
                    }
                    else
                    {
                        isprinted = false;
                        for (int k = 0; k < nTail; k++)
                        {
                            if (TailX[k] == j && TailY[k] == i)
                            {
                                Console.ForegroundColor = bodyColor;
                                Console.Write("o");
                                isprinted = true;
                            }
                        }
                        if (!isprinted) Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Diem cua ban: " + score);
        }

        //Xy ly game thua
        void Lose()
        {
            Console.WriteLine("===SNAKE GAME===");
            Console.WriteLine("Ban da thua!");
            Console.WriteLine("- Nhan phim R de choi lai van moi");
            Console.WriteLine("- Nhan phim Q de ngung choi");

            while (true)
            {
                keypress = Console.ReadKey();
                if (keypress.Key == ConsoleKey.Q) Environment.Exit(0);
                if (keypress.Key == ConsoleKey.R)
                {
                    reset = true; break;
                }
            }
        }

        static void Main(string[] args)
        {
            Program snakegame = new Program();
            snakegame.ShowBanner();
            while (true)
            {
                snakegame.Setup();
                snakegame.Update();
                Console.Clear();
            }
        }
    }
}
