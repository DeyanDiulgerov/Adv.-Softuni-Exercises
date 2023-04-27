using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Truffle_Hunter
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int blackTruffles = 0;
            int summerTruffles = 0;
            int whiteTruffles = 0;
            int boarTruffles = 0;

            var commnad = Console.ReadLine();

            while (commnad != "Stop the hunt")
            {
                var splitted = commnad.Split();
                var movement = splitted[0];
                var newRow = int.Parse(splitted[1]);
                var newCol = int.Parse(splitted[2]);

                var boarRow = 0;
                var boarCol = 0;

                if (movement == "Collect")
                {
                    if (matrix[newRow, newCol] == 'B')
                    {
                        blackTruffles++;
                        matrix[newRow, newCol] = '-';
                    }
                    else if(matrix[newRow, newCol] == 'S')
                    {
                        summerTruffles++;
                        matrix[newRow, newCol] = '-';
                    }
                    else if(matrix[newRow, newCol] == 'W')
                    {
                        whiteTruffles++;
                        matrix[newRow, newCol] = '-';
                    }
                }
                else if(movement == "Wild_Boar")
                {
                    var direction = splitted[3];

                    switch (direction)
                    {
                        case "up":
                            // fixed i >= 0, i -= 2
                            // fixed matrix[ROW, boarCol] = '-';
                            // fixed boarRow = row;
                            for (int row = newRow; row >= 0; row -= 2)
                            {
                                if (matrix[row, newCol] == 'B' || matrix[row, newCol] == 'S' || matrix[row, newCol] == 'W')
                                {
                                    boarTruffles++;
                                    matrix[row, newCol] = '-';

                                    boarRow = row;
                                    boarCol = newCol;
                                }
                            }
                            break;
                        case "down":
                            // fixed i < matrix.GetLength, i += 2
                            // fixed matrix[ROW, boarCol] = '-';
                            // fixed boarRow = row;
                            for (int row = newRow; row < matrix.GetLength(0); row += 2)
                            {
                                if (matrix[row, newCol] == 'B' || matrix[row, newCol] == 'S' || matrix[row, newCol] == 'W')
                                {
                                    boarTruffles++;
                                    matrix[row, newCol] = '-';

                                    boarRow = row;
                                    boarCol = newCol;
                                }
                            }
                            break;
                        case "left":
                            // fixed i >= 0, i -= 2
                            // fixed matrix[newRow, COL] = '-';
                            // fixed boarCol = col;
                            for (int col = newCol; col >= 0; col -= 2)
                            {
                                if (matrix[newRow, col] == 'B' || matrix[newRow, col] == 'S' || matrix[newRow, col] == 'W')
                                {
                                    boarTruffles++;
                                    matrix[newRow, col] = '-';

                                    boarRow = newRow;
                                    boarCol = col;
                                }
                            }
                            break;
                        case "right":
                            // fixed i < matrix.GetLength, i += 2
                            // fixed matrix[newRow, COL] = '-';
                            // fixed boarCol = col;
                            for (int col = newCol; col < matrix.GetLength(1); col += 2)
                            {
                                if (matrix[newRow, col] == 'B' || matrix[newRow, col] == 'S' || matrix[newRow, col] == 'W')
                                {
                                    boarTruffles++;
                                    matrix[newRow, col] = '-';

                                    boarRow = newRow;
                                    boarCol = col;
                                }
                            }
                            break;
                    }
                }

                commnad = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffles} black," +
                $" {summerTruffles} summer, and {whiteTruffles} white truffles.");

            Console.WriteLine($"The wild boar has eaten {boarTruffles} truffles.");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    // fixed C.W(matrix + " ")
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
