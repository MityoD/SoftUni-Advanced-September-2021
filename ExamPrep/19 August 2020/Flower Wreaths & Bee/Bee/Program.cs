using System;
using System.Linq;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int size = int.Parse(Console.ReadLine());
            bool beeGotLost = false;
            char[,] field = new char[size, size];
            int beeRow = 0;
            int beeCol = 0;
            for (int i = 0; i < size; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();

                for (int j = 0; j < row.Length; j++)
                {
                    field[i, j] = row[j];
                    if (field[i, j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                    }
                }
            }
            int flowersDone = 0;

            int newRow = 0;
            int newCol = 0;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                field[beeRow, beeCol] = '.';
                MoveCommand(command);
               
                if (field[beeRow, beeCol] == 'O')
                {
                    field[beeRow, beeCol] = '.';

                    MoveCommand(command);
                }
                field[beeRow, beeCol] = 'B';
                if (beeGotLost)
                {
                    field[beeRow, beeCol] = '.';
                    break;
                }
            }

            if (flowersDone >= 5)
            {
            Console.WriteLine($"Great job, the bee managed to pollinate {flowersDone} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowersDone} flowers more");
            }


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
                    newRow = beeRow + 1;
                    newCol = beeCol;
                }
                else if (command == "up")
                {
                    newRow = beeRow - 1;
                    newCol = beeCol;
                }
                else if (command == "left")
                {
                    newRow = beeRow;
                    newCol = beeCol - 1;
                }
                else if (command == "right")
                {
                    newRow = beeRow;
                    newCol = beeCol + 1;
                }
                if (IsInside(newRow, newCol, size))
                {
                    beeRow = newRow;
                    beeCol = newCol;
                }
                else
                {
                    Console.WriteLine("The bee got lost!");
                    beeGotLost = true;
                }
                if (!beeGotLost && field[beeRow, beeCol] == 'f')
                {
                    flowersDone++;
                    field[beeRow, beeCol] = '.';
                }
               



            }
        }
        private static bool IsInside(int row, int col, int size)
        => row >= 0 && row < size && col >= 0 && col < size;
    }
}
