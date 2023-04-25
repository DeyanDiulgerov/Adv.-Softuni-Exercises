using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Re_volt
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var countOfCommands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            var heroRow = 0;
            var heroCol = 0;
            var counter = 0;
            bool won = false;

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (matrix[row, col] == 'f')
                    {
                        heroRow = row;
                        heroCol = col;
                    }
                }
            }

            var command = Console.ReadLine();
            while (counter < countOfCommands)
            {
                counter++;
                matrix[heroRow, heroCol] = '-';
                heroRow = MoveRow(heroRow, command);
                heroCol = MoveCol(heroCol, command);

                if (IsInMatrix(heroRow, heroCol, n, n) == false)
                {
                    switch (command)
                    {
                        case "up":
                            heroRow = n - 1;
                            break;
                        case "down":
                            heroRow = 0;
                            break;
                        case "left":
                            heroCol = n - 1;
                            break;
                        case "right":
                            heroCol = 0;
                            break;
                    }
                    matrix[heroRow, heroCol] = 'f';
                }
                else if (matrix[heroRow, heroCol] == 'B')
                {
                    //matrix[heroRow, heroCol] = '-';
                    heroRow = MoveRow(heroRow, command);
                    heroCol = MoveCol(heroCol, command);

                    // Repeat IsInMatrix ???
                }
                else if (matrix[heroRow, heroCol] == 'T')
                {
                    switch (command)
                    {
                        case "up":
                            command = "down";
                            break;
                        case "down":
                            command = "up";
                            break;
                        case "left":
                            command = "right";
                            break;
                        case "right":
                            command = "left";
                            break;
                    }

                    heroRow = MoveRow(heroRow, command);
                    heroCol = MoveCol(heroCol, command);
                    //matrix[heroRow, heroCol] = 'f';
                }
                else if (matrix[heroRow, heroCol] == 'F')
                {
                    //counter++;
                    won = true;
                    Console.WriteLine("Player won!");
                    break;
                }
                if (counter >= countOfCommands)
                {
                    break;
                }
                command = Console.ReadLine();
            }

            matrix[heroRow, heroCol] = 'f';

            if (won == false)
                Console.WriteLine("Player lost!");

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
            if (row >= 0 && row < rows && col >= 0 && col < cols)
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
