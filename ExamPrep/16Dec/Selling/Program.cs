using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[,] bakery = new char[rows, rows];
            int myRow = 0;
            int myCol = 0;
            for (int i = 0; i < rows; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    bakery[i, j] = input[j];
                    if (input[j] == 'S')
                    {
                        myRow = i;
                        myCol = j;
                    }
                }
            }
            int money = 0;
            bool isInside = true;

            //int newRow = myRow;
            //int newCol = myCol;
            while (money < 50 && isInside)
            {
                string command = Console.ReadLine();
                bakery[myRow, myCol] = '-';
                if (command == "up")
                {
                    myRow -= 1;
                }
                else if (command == "down")
                {
                    myRow += 1;
                }
                else if (command == "left")
                {
                    myCol -= 1;
                }
                else if (command == "right")
                {
                    myCol += 1;
                }
                if (myRow < 0 || myCol < 0 || myRow >= rows || myCol >= rows)
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    Console.WriteLine($"Money: {money}");
                    isInside = false;
                    break;
                }
                if (bakery[myRow, myCol] == 'O')
                {
                    bakery[myRow, myCol] = 'S';
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < rows; j++)
                        {
                            if (bakery[i, j] == 'O')
                            {
                                bakery[myRow, myCol] = '-';
                                myRow = i;
                                myCol = j;
                                bakery[myRow, myCol] = 'S';
                            }
                        }
                    }
                    //continue;
                }
                else if (bakery[myRow, myCol] == '-')
                {
                    continue;
                }
                else
                {
                    money += int.Parse(bakery[myRow, myCol].ToString());
                }

                bakery[myRow, myCol] = 'S';
            }
            if (isInside)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
                Console.WriteLine($"Money: {money}");
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write(bakery[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
