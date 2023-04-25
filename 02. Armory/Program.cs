using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Armory
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int armyRow = 0;
            int armyCol = 0;
            double swordRevenue = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            var command = Console.ReadLine();

            while (swordRevenue < 65)
            {
                matrix[armyRow, armyCol] = '-';

                armyRow = MoveRow(armyRow, n, command);
                armyCol = MoveCol(armyCol, n, command);

                if (ValidPosition(armyRow, armyCol, n, n) == false)
                {
                    Console.WriteLine("I do not need more swords!");
                    break;
                }

                if (char.IsDigit(matrix[armyRow, armyCol]))
                {
                    swordRevenue += char.GetNumericValue(matrix[armyRow, armyCol]);
                    matrix[armyRow, armyCol] = '-';
                }
                else if(matrix[armyRow, armyCol] == 'M')
                {
                    matrix[armyRow, armyCol] = '-';
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if(matrix[row, col] == 'M')
                            {
                                armyRow = row;
                                armyCol = col;
                                matrix[armyRow, armyCol] = 'A';
                            }
                        }
                    }
                }

                matrix[armyRow, armyCol] = 'A';

                if(swordRevenue >= 65)
                {
                    break;
                }

                command = Console.ReadLine();
            }
            
            if(swordRevenue >= 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {swordRevenue} gold coins.");

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
            if(col < 0 || col >= rows)
            {
                return false;
            }
            return true;
        }

        public static int MoveRow(int row, int rows, string command)
        {
            if(command == "up"/* && row - 1 >= 0*/)
            {
                return row - 1;
            }
            if(command == "down"/* && row + 1 < rows*/)
            {
                return row + 1;
            }
            return row;
        }

        public static int MoveCol(int col, int cols, string command)
        {
            if (command == "left"/* && col - 1 >= 0*/)
            {
                return col - 1;
            }
            if (command == "right"/* && col + 1 < cols*/)
            {
                return col + 1;
            }
            return col;
        }
    }
}
