using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            int snakeRow = 0;
            int snakeCol = 0;
            for (int i = 0; i < size; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();

                for (int j = 0; j < row.Length; j++)
                {
                    field[i, j] = row[j];
                    if (field[i, j] == 'S')
                    {
                        snakeRow = i;
                        snakeCol = j;
                    }
                }
            }

            int foodEaten = 0;

            int newRow = 0;
            int newCol = 0;
            bool IsNotInside = false;
            bool gameOver = false;

            while (foodEaten < 10)
            {

                string command = Console.ReadLine();
                field[snakeRow, snakeCol] = '.';
                MoveCommand(command);
                if (IsNotInside)
                {
                    Console.WriteLine("Game over!");
                    gameOver = true;
                    break;
                }
                if (field[snakeRow, snakeCol] == '*')
                {
                    foodEaten++;
                }
                else if (field[snakeRow, snakeCol] == 'B')
                {
                    field[snakeRow, snakeCol] = '.';

                    int nextRow = 0;
                    int nextCol = 0;
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (field[i, j] == 'B')
                            {
                                nextRow = i;
                                nextCol = j;
                            }
                        }
                    }
                    snakeRow = nextRow;
                    snakeCol = nextCol;

                }
                field[snakeRow, snakeCol] = 'S';


            }
            if (!gameOver)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodEaten}");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }

            void MoveCommand(string command)
            {
                if (command == "down")
                {
                    newRow = snakeRow + 1;
                    newCol = snakeCol;
                }
                else if (command == "up")
                {
                    newRow = snakeRow - 1;
                    newCol = snakeCol;
                }
                else if (command == "left")
                {
                    newRow = snakeRow;
                    newCol = snakeCol - 1;
                }
                else if (command == "right")
                {
                    newRow = snakeRow;
                    newCol = snakeCol + 1;
                }
                if (IsInside(newRow, newCol, size))
                {
                    snakeRow = newRow;
                    snakeCol = newCol;
                }
                else
                {
                    IsNotInside = true;
                }

            }

        }
        private static bool IsInside(int row, int col, int size)
        => row >= 0 && row < size && col >= 0 && col < size;
    }
}
