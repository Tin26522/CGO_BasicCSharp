using System;
using System.Collections.Generic;

namespace TicTacToe1
{
    public enum FIELD { FLD_EMPTY = ' ', FLD_X = 'X', FLD_O = 'O' }

    public class Cell
    {
        FIELD fieldState = FIELD.FLD_EMPTY;

        public Cell()
        {
            fieldState = FIELD.FLD_EMPTY;
        }

        public FIELD GetFieldState()
        {
            return fieldState;
        }

        public bool IsEmpty()
        {
            return fieldState == FIELD.FLD_EMPTY;
        }

        public void MarkField(Player player)
        {
            if (IsEmpty())
            {
                if (player.GetSign() == 'X')
                    fieldState = FIELD.FLD_X;
                else
                    fieldState = FIELD.FLD_O;
            }
        }
    }

    public class Board
    {
        public const int BOARD_SIZE = 3;
        public Cell[,] board;

        public Board()
        {
            board = new Cell[BOARD_SIZE, BOARD_SIZE];
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    board[i, j] = new Cell();
                }
            }
        }

        public void PrintBoard()
        {
            int fieldNumber = 1;
            Console.WriteLine("┌───┬───┬───┐");
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (board[i, j].IsEmpty())
                        Console.Write("│ " + fieldNumber + " ");
                    else
                    {
                        char sign = (char)(board[i, j].GetFieldState());
                        Console.ForegroundColor = (sign == 'X') ? ConsoleColor.Blue : ConsoleColor.Red;
                        Console.Write("│ " + sign + " ");
                        Console.ResetColor();
                    }
                    fieldNumber++;
                }
                Console.WriteLine("│");
                if (i < BOARD_SIZE - 1) Console.WriteLine("├───┼───┼───┤");
            }
            Console.WriteLine("└───┴───┴───┘");
        }

        public void PutMark(Player player, int fieldNumber)
        {
            int verticalY = (fieldNumber - 1) / BOARD_SIZE;
            int horizontalX = (fieldNumber - 1) % BOARD_SIZE;
            if (board[verticalY, horizontalX].IsEmpty())
                board[verticalY, horizontalX].MarkField(player);
            else
            {
                Console.WriteLine("This place is taken. Select the field again: ");
                PutMark(player, player.TakeTurn(this));
            }
        }

        public bool IsFieldEmpty(int i)
        {
            int verticalY = (i - 1) / BOARD_SIZE;
            int horizontalX = (i - 1) % BOARD_SIZE;
            return board[verticalY, horizontalX].IsEmpty();
        }
    }

    public class Player
    {
        char sign;

        public Player(char playerSign)
        {
            sign = playerSign;
        }

        public char GetSign()
        {
            return sign;
        }

        public virtual int TakeTurn(Board gameBoard)
        {
            return int.Parse(Console.ReadLine());
        }

        private bool CheckRowCol(FIELD c1, FIELD c2, FIELD c3)
        {
            return (c1 != FIELD.FLD_EMPTY) && (c1 == c2) && (c2 == c3);
        }

        private bool CheckRowsForWin(Board gameBoard)
        {
            for (int i = 0; i < Board.BOARD_SIZE; i++)
            {
                if (CheckRowCol(gameBoard.board[i, 0].GetFieldState(),
                        gameBoard.board[i, 1].GetFieldState(),
                        gameBoard.board[i, 2].GetFieldState()))
                    return true;
            }
            return false;
        }

        private bool CheckColumnsForWin(Board gameBoard)
        {
            for (int i = 0; i < Board.BOARD_SIZE; i++)
            {
                if (CheckRowCol(gameBoard.board[0, i].GetFieldState(),
                        gameBoard.board[1, i].GetFieldState(),
                        gameBoard.board[2, i].GetFieldState()))
                    return true;
            }
            return false;
        }

        private bool CheckDiagonalsForWin(Board gameBoard)
        {
            return (CheckRowCol(gameBoard.board[0, 0].GetFieldState(),
                    gameBoard.board[1, 1].GetFieldState(),
                    gameBoard.board[2, 2].GetFieldState()) ||
                    CheckRowCol(gameBoard.board[0, 2].GetFieldState(),
                    gameBoard.board[1, 1].GetFieldState(),
                    gameBoard.board[2, 0].GetFieldState()));
        }

        public bool CheckWin(Board gameBoard)
        {
            return (CheckRowsForWin(gameBoard) || CheckColumnsForWin(gameBoard) || CheckDiagonalsForWin(gameBoard));
        }
    }

    public class AIPlayer : Player
    {
        public AIPlayer(char playerSign) : base(playerSign)
        {
        }

        public override int TakeTurn(Board gameBoard)
        {
            List<int> emptyFields = new List<int>();
            for (int i = 1; i <= Board.BOARD_SIZE * Board.BOARD_SIZE; i++)
            {
                if (gameBoard.IsFieldEmpty(i))
                    emptyFields.Add(i);
            }

            Random random = new Random();
            int randomIndex = random.Next(emptyFields.Count);
            return emptyFields[randomIndex];
        }
    }

    public class TicTacToe
    {
        public void Play()
        {
            int moveCounter = 0;
            Board gameBoard = new Board();

            Player playerX = new Player('X');
            Player playerO = new Player('O');
            Player currentPlayer = playerX;

            bool play = true;
            while (play)
            {
                Console.WriteLine("===== Tic Tac Toe Game Menu =====");
                Console.WriteLine("1. Human vs. Human");
                Console.WriteLine("2. Human vs. Robot");
                Console.WriteLine("3. Robot vs. Robot");
                Console.Write("Enter your choice (1-3): ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        playerX = new Player('X');
                        playerO = new Player('O');
                        break;
                    case 2:
                        playerX = new Player('X');
                        playerO = new AIPlayer('O');
                        break;
                    case 3:
                        playerX = new AIPlayer('X');
                        playerO = new AIPlayer('O');
                        break;
                    case 4:
                        play = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        continue;
                }

                if (play)
                {
                    moveCounter = 0;
                    gameBoard = new Board();
                    currentPlayer = playerX;

                    while (play)
                    {
                        gameBoard.PrintBoard();
                        Console.WriteLine("Player: {0} Enter the field in which you want to put the character: ", currentPlayer.GetSign());

                        try
                        {
                            gameBoard.PutMark(currentPlayer, currentPlayer.TakeTurn(gameBoard));
                            moveCounter++;

                            if (currentPlayer.CheckWin(gameBoard))
                            {
                                gameBoard.PrintBoard();
                                Console.WriteLine("Player: {0} won!", currentPlayer.GetSign());
                                play = false;
                            }
                            else if (CheckDraw(moveCounter))
                            {
                                gameBoard.PrintBoard();
                                Console.WriteLine("DRAW");
                                play = false;
                            }
                            else
                            {
                                currentPlayer = (currentPlayer == playerX) ? playerO : playerX;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Input. Please enter a number between 1-9!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
            }
        }

        private bool CheckDraw(int turnCounter)
        {
            return turnCounter == Board.BOARD_SIZE * Board.BOARD_SIZE;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.Play();
            Console.WriteLine("Goodbye!");
        }
    }
}
