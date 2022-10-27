using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[,] shop = new char[rows, rows];
            int aRow = 0;
            int aCol = 0;

            for (int i = 0; i < rows; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < rows; j++)
                {
                    shop[i, j] = line[j];
                    if (shop[i, j] == 'A')
                    {
                        aRow = i;
                        aCol = j;
                    }

                }
            }

            int totalCoins = 0;
            bool hadLeft = false;
            while (totalCoins < 65)
            {
                shop[aRow, aCol] = '-';
                string command = Console.ReadLine();
                if (command == "up")
                {
                    aRow--;
                }
                else if (command == "down")
                {
                    aRow++;
                }
                else if (command == "left")
                {
                    aCol--;
                }
                else if (command == "right")
                {
                    aCol++;
                }
                if (!IsInside(aRow, aCol, rows))
                {
                    hadLeft = true;
                    break;
                }

                if (shop[aRow, aCol] == 'M')
                {
                    shop[aRow, aCol] = 'A';
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < rows; j++)
                        {
                            if (shop[i, j] == 'M')
                            {
                                shop[aRow, aCol] = '-';
                                aRow = i;
                                aCol = j;
                                shop[aRow, aCol] = 'A';
                            } 
                        }
                    }
                }

                else if (shop[aRow, aCol] == '-')
                {
                    shop[aRow, aCol] = 'A';
                    continue;
                }
                else
                {
                    int coins = int.Parse(shop[aRow, aCol].ToString());
                    shop[aRow, aCol] = 'A';
                    totalCoins += coins;
                }

                //Console.WriteLine("-----******");
                //for (int i = 0; i < rows; i++)
                //{
                //    for (int j = 0; j < rows; j++)
                //    {
                //        Console.Write(shop[i,j]);
                //    }
                //    Console.WriteLine();
                //}
                //Console.WriteLine("-----*******");
            }

            if (hadLeft == true)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {totalCoins} gold coins.");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write(shop[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(int aRow, int aCol, int rows) => aRow >= 0 && aRow < rows && aCol >= 0 && aCol < rows; 
    }
}
