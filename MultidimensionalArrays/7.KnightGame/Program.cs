using System;

namespace _7.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] table = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    table[i, j] = input[j];
                }
            }
            if (n < 3)
            {
                Console.WriteLine("0");
                Environment.Exit(0);
            }
            int counter = 0;

            while (true)
            {
                int maxAttacks = 0;
                int kRow = 0;
                int kCol = 0;
                for (int row = 0; row < table.GetLength(0); row++)
                {
                    for (int col = 0; col < table.GetLength(1); col++)
                    {
                        int currentAttacks = 0;
                        if (table[row, col] != 'K')
                        {
                            continue;
                        }
                        if (IsInside(table, row - 2, col - 1) && table[row - 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInside(table, row - 2, col + 1) && table[row - 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInside(table, row - 1, col + 2) && table[row - 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInside(table, row - 1, col - 2) && table[row - 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInside(table, row + 1, col + 2) && table[row + 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInside(table, row + 1, col - 2) && table[row + 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInside(table, row + 2, col + 1) && table[row + 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }
                        if (IsInside(table, row + 2, col - 1) && table[row + 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }                        
                        if (currentAttacks > maxAttacks)
                        {
                            maxAttacks = currentAttacks;
                            kRow = row;
                            kCol = col;
                        }

                    }

                }
                if (maxAttacks == 0)
                {
                    Console.WriteLine(counter);
                    break;
                }
                else
                {
                    table[kRow, kCol] = '0';
                    counter++;
                    ;
                }

            }
        }

        private static bool IsInside(char[,] table, int row, int col)
        {
            return row >= 0 && row < table.GetLength(0) && col >= 0 && col < table.GetLength(1);
        }
    }
}
