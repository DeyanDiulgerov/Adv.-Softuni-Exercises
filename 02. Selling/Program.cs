using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Selling
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int heroRow = 0;
            int heroCol = 0;

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if(matrix[row, col] == 'S')
                    {
                        heroRow = row;
                        heroCol = col;
                    }
                }
            }

            double money = 0;

            var command = Console.ReadLine();

            while (true)
            {
                matrix[heroRow, heroCol] = '-';

                heroRow = MoveRow(heroRow, command);
                heroCol = MoveCol(heroCol, command);
                if(IsInMatrix(heroRow, heroCol, n, n) == false)
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                if(char.IsDigit(matrix[heroRow, heroCol]))
                {
                    money += char.GetNumericValue(matrix[heroRow, heroCol]);
                    matrix[heroRow, heroCol] = '-';
                }
                if (matrix[heroRow, heroCol] == 'O')
                {
                    matrix[heroRow, heroCol] = '-';

                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if(matrix[row, col] == 'O')
                            {
                                heroRow = row;
                                heroCol = col;

                                matrix[heroRow, heroCol] = 'S';
                            }
                        }
                    }
                }

                matrix[heroRow, heroCol] = 'S';

                if(money >= 50)
                {
                    Console.WriteLine($"Good news! You succeeded in collecting enough money!");
                    break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Money: {money}");

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
            if (row >= 0 && row < rows && col >= 0 & col < cols)
                return true;

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
