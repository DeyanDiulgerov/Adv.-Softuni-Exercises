using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _02.Rally_Racing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int racingNumber = int.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int carRow = 0;
            int carCol = 0;
            int kilometers = 0;

            string command = Console.ReadLine();

            while (true)
            {
                if(command == "End")
                {
                    Console.WriteLine($"Racing car {racingNumber} DNF.");
                    matrix[carRow, carCol] = 'C';
                    break;
                }
                matrix[carRow, carCol] = '.';

                carRow = MoveRow(carRow, command);
                carCol = MoveCol(carCol, command);

                if (matrix[carRow, carCol] == 'T')
                {
                    matrix[carRow, carCol] = '.';
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if(matrix[row, col] == 'T')
                            {
                                carRow = row;
                                carCol = col;
                                kilometers += 30;
                            }
                        }
                    }

                    matrix[carRow, carCol] = 'C';

                    command = Console.ReadLine();


                    continue;
                }
                else if(matrix[carRow, carCol] == 'F')
                {
                    Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                    matrix[carRow, carCol] = 'C';
                    kilometers += 10;
                    break;
                }

                kilometers += 10;
                matrix[carRow, carCol] = 'C';

                command = Console.ReadLine();
            }

            Console.WriteLine($"Distance covered {kilometers} km.");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static bool IsInMatrix(int row, int col, int rows, int cols)
        {
            if(col >= 0 && col < cols && row >= 0 && row < rows)
            {
                return true;
            }
            return false;
        }

        public static int MoveRow(int row, string command)
        {
            if (command == "up")
                return row - 1;
            if (command == "down")
                return row + 1;
            return row;
        }

        public static int MoveCol(int col, string command)
        {
            if (command == "left")
                return col - 1;
            if (command == "right")
                return col + 1;
            return col;
        }
    }
}
