using System;
using System.Linq;


namespace BattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            var armor = int.Parse(Console.ReadLine());
            var rows = int.Parse(Console.ReadLine());

            // Input - create Matrix - masiv ot masivi/nazuben masiv
            char[][] field = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                var chars = Console.ReadLine().ToCharArray();
                field[i] = chars;
            }

            //Find Hero
            var heroRow = 0;
            var heroCol = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 'A')
                    {
                        heroRow = i;
                        heroCol = j;
                    }
                }
            }

            //Start receiving commands about movement and the game
            while (true)
            {
                var commands = Console.ReadLine();
                var splitted = commands.Split(" ");
                var move = splitted[0];
                var orcRow = int.Parse(splitted[1]);
                var orcCol = int.Parse(splitted[2]);


                // Moving
                armor--;
                field[orcRow][orcCol] = 'O';
                field[heroRow][heroCol] = '-';


                if (move == "up" && heroRow - 1 >= 0)
                {
                    heroRow--;
                }
                else if(move == "down" && heroRow + 1 < rows)
                {
                    heroRow++;
                }
                else if (move == "left" && heroCol - 1 >= 0)
                {
                    heroCol--;
                }
                else if (move == "right" && heroCol + 1 < field[heroRow].Length)
                {
                    heroCol++;
                }

                
                // Already Moved - actions after movement
                if (field[heroRow][heroCol] == 'O')
                {
                    armor -= 2;
                }

                if(field[heroRow][heroCol] == 'M')
                {
                    field[heroRow][heroCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }

                if (armor <= 0)
                {
                    field[heroRow][heroCol] = 'X';
                    Console.WriteLine($"The army was defeated at {heroRow};{heroCol}.");
                    break;
                }

                field[heroRow][heroCol] = 'A';
            }

            //printing final state of the matrix
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(new string(field[i]));
            }

            //2nd option for printing final state for our matrix
            /*for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    Console.Write(field[i][j]);
                }
                Console.WriteLine();
            }*/

        }
    }
}
