using System;
using System.Linq;

namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] map = new char[rows][];
            for (int i = 0; i < rows; i++)
            {   
                map[i] = Console.ReadLine().ToCharArray();
            }
            int heroRow = 0;
            int heroCol = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'A')
                    {
                        heroRow = i;
                        heroCol = j;
                    }
                }
            }
            while (true)
            {
                string[] data = Console.ReadLine().Split();
                string direction = data[0];
                int orcRow = int.Parse(data[1]);
                int orcCol = int.Parse(data[2]);
                map[orcRow][orcCol] = 'O';
                map[heroRow][heroCol] = '-';
                if (direction == "up" && heroRow - 1 >= 0)
                {
                    heroRow -= 1;
                }
                else if (direction == "down" && heroRow + 1 < map.Length )
                {
                    heroRow += 1;
                }
                else if (direction == "left" && heroCol - 1 >= 0)
                {
                    heroCol -= 1;
                }
                else if (direction == "right" && heroCol + 1 < map[heroRow].Length)
                {
                    heroCol += 1;
                }
                armor--;
                if (map[heroRow][heroCol] == 'O')
                {
                    armor -= 2;
                }
                if (armor <= 0)
                {
                    map[heroRow][heroCol] = 'X';
                    Console.WriteLine($"The army was defeated at {heroRow};{heroCol}.");
                    break;
                }
                if (map[heroRow][heroCol] == 'M')
                {
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    map[heroRow][heroCol] = '-';
                    break;
                }
                map[heroRow][heroCol] = 'A';
            }
            foreach (var item in map)
            {
                Console.WriteLine(string.Join("", item));
            }
        }
    }
}
