using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // n = size of the territory/matrix
            // we create our matrix from the input
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            // We find our character
            var beeRow = 0;
            var beeCol = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            //We start moving around the field
            string command = Console.ReadLine();

            int polinatedFlowers = 0;

            while (command != "End")
            {
                matrix[beeRow, beeCol] = '.';
                beeRow = MoveRow(beeRow, command);
                beeCol = MoveCol(beeCol, command);

                if(!ValidPosition(beeRow, beeCol, n, n))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }


                if(matrix[beeRow, beeCol] == 'f')
                {
                    polinatedFlowers++;
                }

                if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow = MoveRow(beeRow, command);
                    beeCol = MoveCol(beeCol, command);
                    if (!ValidPosition(beeRow, beeCol, n, n))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        polinatedFlowers++;
                    }
                }

                matrix[beeRow, beeCol] = 'B';
                command = Console.ReadLine();
            }

            if(polinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed" +
                    $" {5 - polinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");
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


        // check if the new bee position is valid - exists on the matrix
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
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col + 1;
            }

            return col;
        }
    }
}
