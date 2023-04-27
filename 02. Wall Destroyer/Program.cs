
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Wall_Destroyer
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int vankoRow = 0;
            int vankoCol = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }

            var createdHoles = 1;
            var rodsHit = 0;
            bool gotElectrocuted = false;

            string command = Console.ReadLine();

            while (command != "End")
            {
                matrix[vankoRow, vankoCol] = '*';

                vankoRow = MoveRow(vankoRow, command);
                vankoCol = MoveCol(vankoCol, command);

                if (ValidPosition(vankoRow, vankoCol, n, n) == false)
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
                    vankoRow = MoveRow(vankoRow, command);
                    vankoCol = MoveCol(vankoCol, command);
                    matrix[vankoRow, vankoCol] = 'V';
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    if (matrix[vankoRow, vankoCol] == 'R')
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

                        rodsHit++;
                        vankoRow = MoveRow(vankoRow, command);
                        vankoCol = MoveCol(vankoCol, command);
                        matrix[vankoRow, vankoCol] = 'V';
                        Console.WriteLine("Vanko hit a rod!");
                        command = Console.ReadLine();
                        continue;
                    }
                    else if (matrix[vankoRow, vankoCol] == 'C')
                    {
                        matrix[vankoRow, vankoCol] = 'E';
                        createdHoles++;
                        gotElectrocuted = true;
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {createdHoles} hole(s).");
                        break;
                    }
                    else if (matrix[vankoRow, vankoCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                        matrix[vankoRow, vankoCol] = 'V';
                        command = Console.ReadLine();
                        continue;

                    }

                    createdHoles++;
                    matrix[vankoRow, vankoCol] = 'V';

                    command = Console.ReadLine();
                }               
            }

            if(gotElectrocuted == false)
            {
                Console.WriteLine($"Vanko managed to make {createdHoles} hole(s) and he hit only {rodsHit} rod(s).");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static bool ValidPosition(int row, int col, int rows, int cols)
        {
            if(row < 0 || row >= rows)
            {
                return false;
            }
            if(col < 0 || col >= cols)
            {
                return false;
            }
            return true;
        }

        public static int MoveRow(int row, string movement)
        {
            if(movement == "up")
            {
                return row - 1;
            }
            if(movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if(movement == "left")
            {
                return col - 1;
            }
            if(movement == "right")
            {
                return col + 1;
            }

            return col;
        }
    }
}
