using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int wRow = 0;
            int wCol = 0;
            int bRow = 0;
            int bCol = 0;
            string rowIndex = "87654321";
            string colIndex = "abcdefgh";
            char[,] table = new char[8, 8];
            for (int i = 0; i < 8; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < 8; j++)
                {
                    table[i, j] = input[j];
                    if (table[i, j] == 'w')
                    {
                        wRow = i;
                        wCol = j;
                    }
                    else if (table[i, j] == 'b')
                    {
                        bRow = i;
                        bCol = j;
                    }
                }
            }
            while (true)
            {
                if (IsInside(wRow - 1, wCol - 1) && table[wRow - 1, wCol - 1] == 'b')
                {
                    
                    Console.WriteLine($"Game over! White capture on {colIndex[wCol - 1]}{rowIndex[wRow -1]}.");
                    break;
                }
                else if (IsInside(wRow - 1, wCol + 1) && table[wRow - 1, wCol + 1] == 'b')
                {
                    Console.WriteLine($"Game over! White capture on {colIndex[wCol + 1]}{rowIndex[wRow - 1]}.");
                    break;
                }
                table[wRow, wCol] = '-';
                if (IsInside(wRow - 1, wCol))
                {
                    wRow -= 1;
                }
                if (wRow == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {colIndex[wCol]}{rowIndex[wRow]}.");
                    break;
                }
                table[wRow, wCol] = 'w';


                if (IsInside(bRow + 1, bCol - 1) && table[bRow + 1, bCol - 1] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {colIndex[bCol - 1]}{rowIndex[bRow + 1]}.");
                    break;
                }
                else if (IsInside(bRow + 1, bCol + 1) && table[bRow + 1, bCol + 1] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {colIndex[bCol + 1]}{rowIndex[bRow + 1]}.");
                    break;
                }
                table[bRow, bCol] = '-';
                if (IsInside(bRow + 1, bCol))
                {
                    bRow += 1;
                }
                if (bRow == 7)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {colIndex[bCol]}{rowIndex[bRow]}.");
                    break;
                }
                table[bRow, bCol] = 'b';
            }

        }
            static bool IsInside(int rows, int cols)
            {
                if (rows >= 0 && rows < 8 && cols >= 0 && cols < 8)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
    }
}

