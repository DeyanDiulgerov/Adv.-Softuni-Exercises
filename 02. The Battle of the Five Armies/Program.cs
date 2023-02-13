using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.The_Battle_of_the_Five_Armies
{
    public class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            for (int row = 0; row < n; row++)
            {
                var chars = Console.ReadLine().ToCharArray();
                matrix[row] = chars;

            }

            int armyRow = 0;
            int armyCol = 0;


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (true)
            {
                var splitted = command.Split();
                var movement = splitted[0];
                var orcRow = int.Parse(splitted[1]);
                var orcCol = int.Parse(splitted[2]);

                matrix[orcRow][orcCol] = 'O';
                matrix[armyRow][armyCol] = '-';

                if (ValidPosition(armyRow, armyCol, n, matrix[armyRow].Length) == false)
                {
                    armor -= 1;
                    if (armor <= 0)
                    {
                        matrix[armyRow][armyCol] = 'X';
                        break;
                    }


                    matrix[armyRow][armyCol] = 'A';

                    command = Console.ReadLine();
                }
                else
                {
                    armyRow = MoveRow(armyRow, movement);
                    armyCol = MoveCol(armyCol, movement);

                    if (matrix[armyRow][armyCol] == 'O')
                    {
                        armor -= 2;
                        if(armor <= 0)
                        {
                            matrix[armyRow][armyCol] = 'X';
                            break;
                        }
                    }

                    if (matrix[armyRow][armyCol] == 'M')
                    {
                        armor -= 1;
                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                        matrix[armyRow][armyCol] = '-';
                        break;
                    }
                }

                armor -= 1;
                if (armor <= 0)
                {
                    matrix[armyRow][armyCol] = 'X';
                    break;
                }


                matrix[armyRow][armyCol] = 'A';

                command = Console.ReadLine();
            }


            if(armor <= 0)
            {
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }


            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
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
            else if(movement == "down")
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
            else if(movement == "right")
            {
                return col + 1;
            }

            return col;
        }
    }
}
