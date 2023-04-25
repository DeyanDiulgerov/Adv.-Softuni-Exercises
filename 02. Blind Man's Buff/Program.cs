using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace TEST
{
    public class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = size[0];
            int m = size[1];

            char[,] matrix = new char[n, m];

            var heroRow = 0;
            var heroCol = 0;

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (matrix[row, col] == 'B')
                    {
                        heroRow = row;
                        heroCol = col;
                    }
                }
            }

            int points = 0;
            int movesMade = 0;


            var command = Console.ReadLine();

            while (command != "Finish")
            {
                if (points >= 3)
                {
                    break;
                }

                matrix[heroRow, heroCol] = '-';

                heroRow = MoveRow(heroRow, command);
                heroCol = MoveCol(heroCol, command);

                if (IsInMatrix(heroRow, heroCol, n, m) == false || matrix[heroRow, heroCol] == 'O')
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

                    matrix[heroRow, heroCol] = 'B';
                    command = Console.ReadLine();
                    continue;
                }

                if (matrix[heroRow, heroCol] == 'P')
                {
                    points++;
                    movesMade++;
                    matrix[heroRow, heroCol] = '-';
                }
                else if (matrix[heroRow, heroCol] == '-')
                {
                    movesMade++;
                }

                matrix[heroRow, heroCol] = 'B';
                command = Console.ReadLine();
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {points} Moves made: {movesMade}");
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
