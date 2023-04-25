using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int beaverRow = 0;
            int beaverCol = 0;

            int totalBranches = 0;
            int overallTotalBranches = 0;
            int branchesMissing = 0;
            var ourBranches = new List<char>();
            int fishCount = 0;

            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                    else if (char.IsLower(matrix[row, col]))
                    {
                        totalBranches++;
                        overallTotalBranches++;
                    }
                }
            }


            var command = Console.ReadLine();

            while (command != "end" && totalBranches > 0)
            {
                var newWoodCount = 0;
                matrix[beaverRow, beaverCol] = '-';

                if(ValidPosition(beaverRow, beaverCol, n, n, command) == false)
                {
                    ourBranches.RemoveAt(ourBranches.Count - 1);
                    branchesMissing++;
                    matrix[beaverRow, beaverCol] = 'B';

                    command = Console.ReadLine();
                    continue;
                }

                beaverRow = ValidMoveRow(beaverRow, n, command);
                beaverCol = ValidMoveCol(beaverCol, n, command);

                if (matrix[beaverRow, beaverCol] == '-')
                {
                    matrix[beaverRow, beaverCol] = 'B';
                    command = Console.ReadLine();
                    continue;
                }

                if (char.IsLower(matrix[beaverRow, beaverCol]))
                {
                    ourBranches.Add(matrix[beaverRow, beaverCol]);
                    totalBranches--;
                }

                else if(matrix[beaverRow, beaverCol] == 'F')
                {
                    matrix[beaverRow, beaverCol] = '-';
                    fishCount++;
                    if(beaverRow == 0)
                    {
                        beaverRow = n - 1;
                    }
                    else if(beaverRow == n - 1)
                    {
                        beaverRow = 0;
                    }
                    else if(beaverCol == 0)
                    {
                        beaverCol = n - 1;
                    }
                    else if(beaverCol == n - 1)
                    {
                        beaverCol = 0;
                    }
                    else
                    {
                        switch (command)
                        {
                            case "up":
                                beaverRow = 0;
                                break;
                            case "down":
                                beaverRow = n - 1;
                                break;
                            case "left":
                                beaverCol = 0;
                                break;
                            case "right":
                                beaverCol = n - 1;
                                break;
                        }
                    }
                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        ourBranches.Add(matrix[beaverRow, beaverCol]);
                        totalBranches--;
                    }
                    matrix[beaverRow, beaverCol] = '-';               
                }    
                else
                {
                    matrix[beaverRow, beaverCol] = 'B';
                    command = Console.ReadLine();
                    continue;
                }
                matrix[beaverRow, beaverCol] = 'B';

                command = Console.ReadLine();
            }

            if (ourBranches.Count() + branchesMissing >= overallTotalBranches)
            {
                Console.WriteLine($"The Beaver successfully collect {ourBranches.Count()} wood branches: {string.Join(", ", ourBranches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch." +
                    $" There are {overallTotalBranches - (ourBranches.Count() + branchesMissing)} branches left.");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write((char)matrix[row, col]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        public static bool ValidPosition(int row, int col, int rows, int cols, string command)
        {
            if (command == "up" && row - 1 >= 0)
            {
                return true;
            }
            if (command == "down" && row + 1 < rows)
            {
                return true;
            }
            if (command == "left" && col - 1 >= 0)
            {
                return true;
            }
            if (command == "right" && col + 1 < cols)
            {
                return true;
            }
            return false;
        }

        public static int ValidMoveRow(int row, int rows, string command)
        {
            if(command == "up" && row - 1 >= 0)
            {
                return row - 1;
            }
            if(command == "down" && row + 1 < rows)
            {
                return row + 1;
            }
            return row;
        }

        public static int ValidMoveCol(int col, int cols, string command)
        {
            if (command == "left" && col - 1 >= 0)
            {
                return col - 1;
            }
            if (command == "right" && col + 1 < cols)
            {
                return col + 1;
            }
            return col;
        }
    }
}
