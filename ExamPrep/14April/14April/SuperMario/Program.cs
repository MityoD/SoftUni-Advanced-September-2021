using System;
using System.Linq;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int marioRow = 0;
            int marioCol = 0;
            char[][] map = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j  < input.Length; j ++)
                {
                    map[i] = input.ToCharArray();
                    if (map[i][j] == 'M')
                    {
                        marioRow = i;
                        marioCol = j;
                    }
                }
            }
            while (true)
            {
                int oldMRow = marioRow;
                int oldMCol = marioCol;
                map[oldMRow][oldMCol] = '-';
                string[] command = Console.ReadLine().Split();
                string direction = command[0];
                int bRow = int.Parse(command[1]);
                int bCol = int.Parse(command[2]);
                lives--;
                map[bRow][bCol] = 'B';
                if (direction == "A")
                {
                    marioCol--;
                }
                else if (direction == "D")
                {
                    marioCol++;
                }
                else if (direction == "W")
                {
                    marioRow--;
                }
                else if (direction == "S")
                {
                    marioRow++;
                }
                if (marioRow <0 || marioRow >= map.GetLength(0))
                {
                    marioRow = oldMRow;
                }
                if (marioCol < 0 || marioCol >= map.GetLength(0))
                {
                    marioCol = oldMCol;
                }
                if (map[marioRow][marioCol] == 'B')
                {
                    lives -= 2;
                }
                else if (map[marioRow][marioCol] == 'P' )
                {
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    map[marioRow][marioCol] = '-';
                    break;
                }
                if (lives <= 0 )
                {
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    map[marioRow][marioCol] = 'X';
                    break;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join("", map[i]));
            }
        }
    }
}
