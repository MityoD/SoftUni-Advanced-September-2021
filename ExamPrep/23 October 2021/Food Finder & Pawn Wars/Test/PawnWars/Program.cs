using System;

namespace PawnWars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];
            int wRow = 0;
            int wCol = 0;
            int bRow = 0;
            int bCol = 0;
            for (int i = 0; i < 8; i++)
            {
                string lines = Console.ReadLine();
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = lines[j];
                    if (board[i, j] == 'w')
                    {
                        wRow = i;
                        wCol = j;

                    }
                    if (board[i, j] == 'b')
                    {
                        bRow = i;
                        bCol = j;
                    }
                }
            }

            string rows = "87654321";
            string cols = "abcdefgh";
         
            while (true)
            {

                if (WCanAttack(wRow, wCol, board, rows, cols))
                {   

                    break;
                }
                board[wRow, wCol] = '-';
                wRow--;
                board[wRow, wCol] = 'w';

                if (wRow == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {cols[wCol]}{rows[wRow]}.");
                    break;
                }
             
                if (BCanAttack(bRow, bCol, board, rows, cols))
                {
                    break;
                }
                board[bRow, bCol] = '-';
                
                bRow++;
                if (bRow == 7)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {cols[bCol]}{rows[bRow]}.");
                    break;

                }
                board[bRow, bCol] = 'b';


            }
        }



        private static bool IsInside(int row, int col) => row >= 0 && row < 8 && col >= 0 && col < 8;


        private static bool BCanAttack(int row, int col, char[,] board, string rows, string cols)
        {
            if (IsInside(row + 1, col - 1) && board[row + 1, col - 1] != '-')
            {
                row = row + 1;
                col = col - 1;
                Console.WriteLine($"Game over! Black capture on {cols[col]}{rows[row]}.");

                return true;
            }
            else if (IsInside(row + 1, col + 1) && board[row + 1, col + 1] != '-')
            {
                row = row + 1;
                col = col + 1;

                Console.WriteLine($"Game over! Black capture on {cols[col]}{rows[row]}.");

                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool WCanAttack(int row, int col, char[,] board, string rows, string cols)
        {
            if (IsInside(row - 1, col - 1) && board[row - 1, col - 1] != '-')
            {
                row = row - 1;
                col = col - 1;
                Console.WriteLine($"Game over! White capture on {cols[col]}{rows[row]}.");
                return true;
            }
            else if (IsInside(row - 1, col + 1) && board[row - 1, col + 1] != '-')
            {
                row = row - 1;
                col = col + 1;
                Console.WriteLine($"Game over! White capture on {cols[col]}{rows[row]}.");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
