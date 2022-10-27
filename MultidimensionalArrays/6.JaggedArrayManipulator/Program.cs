using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(double.Parse).ToArray();  
            }
            for (int i = 0; i < rows - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] *= 2;
                        matrix[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] /= 2;                        
                    }
                    for (int j = 0; j < matrix[i + 1].Length; j++)
                    {
                        matrix[i + 1][j] /= 2;
                    }
                }

            }
            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                /*	•	"Add {row} {column} {value}" - add {value} to the element at the given indexes, if they are valid
	•	"Subtract {row} {column} {value}" - subtract {value} from the element at the given indexes, if they are valid
*/
                string[] commandArgs = command.Split();
                string action = commandArgs[0];
                int rowIndex = int.Parse(commandArgs[1]);
                int colIndex = int.Parse(commandArgs[2]);
                int value = int.Parse(commandArgs[3]);
                if (rowIndex >= 0 && rowIndex < rows && colIndex >= 0 && colIndex < matrix[rowIndex].Length)
                {
                    if (action == "Add")
                    {
                        matrix[rowIndex][colIndex] += value;
                    }
                    else if (action == "Subtract")
                    {
                        matrix[rowIndex][colIndex] -= value;

                    }
                }
                else
                {
                    continue;
                }                
            }
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }
    }
}
