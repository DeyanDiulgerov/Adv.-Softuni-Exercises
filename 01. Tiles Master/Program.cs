using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Tiles_Master
{
    public class Program
    {
        static void Main(string[] args)
        {
            var whiteTiles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var greyTiles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var kitchen = new Dictionary<string, int>()
            {
                {"Countertop", 0},
                {"Floor", 0},
                {"Oven", 0},
                {"Sink", 0},
                {"Wall", 0}
            };

            var stackWhite = new Stack<int>(whiteTiles);
            var queueGrey = new Queue<int>(greyTiles);

            while (stackWhite.Count > 0 && queueGrey.Count > 0)
            {
                var currentWhite = stackWhite.Peek();
                var currentGrey = queueGrey.Peek();
                var sum = currentGrey + currentWhite;

                if(currentGrey == currentWhite)
                {
                    if (sum == 40)
                    {
                        queueGrey.Dequeue();
                        stackWhite.Pop();
                        kitchen["Sink"]++;
                    }
                    else if (sum == 50)
                    {
                        queueGrey.Dequeue();
                        stackWhite.Pop();
                        kitchen["Oven"]++;
                    }
                    else if (sum == 60)
                    {
                        queueGrey.Dequeue();
                        stackWhite.Pop();
                        kitchen["Countertop"]++;
                    }
                    else if (sum == 70)
                    {
                        queueGrey.Dequeue();
                        stackWhite.Pop();
                        kitchen["Wall"]++;
                    }
                    else
                    {
                        queueGrey.Dequeue();
                        stackWhite.Pop();
                        kitchen["Floor"]++;
                    }
                }
                else if(currentWhite != currentGrey)
                {
                    var newWhiteTile = currentWhite / 2;
                    stackWhite.Pop();
                    stackWhite.Push(newWhiteTile);
                    var newCurrentGrey = queueGrey.Peek();
                    queueGrey.Dequeue();
                    queueGrey.Enqueue(newCurrentGrey);
                }
            }

            var whiteTilesLeft = stackWhite.Count == 0 ? "none" : String.Join(", ", stackWhite);
            var greyTilesLeft = queueGrey.Count == 0 ? "none" : String.Join(", ", queueGrey);

            Console.WriteLine($"White tiles left: {whiteTilesLeft}");
            Console.WriteLine($"Grey tiles left: {greyTilesLeft}");

            foreach (var kvp in kitchen.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if(kvp.Value > 0)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
        }
    }
}
