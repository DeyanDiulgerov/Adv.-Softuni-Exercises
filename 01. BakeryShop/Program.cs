using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var water = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
            var flour = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

            var dictionary = new Dictionary<string, int>
            {
                {"Croissant", 0},
                {"Muffin", 0},
                {"Baguette", 0},
                {"Bagel", 0}
            };

            //water == queue
            //flour == stack
            var waterQueue = new Queue<double>(water);
            var flourStack = new Stack<double>(flour);

            while (waterQueue.Any() && flourStack.Any())
            {
                var currentWater = waterQueue.Peek();
                var currentFlour = flourStack.Peek();

                var combined = currentWater + currentFlour;
                var waterPercentage = (currentWater * 100) / combined;
                var flourPercentage = 100 - waterPercentage;

                if (waterPercentage == 40 && flourPercentage == 60)
                {
                    dictionary["Muffin"]++;
                    waterQueue.Dequeue();
                    flourStack.Pop();
                }
                if (waterPercentage == 50 && flourPercentage == 50)
                {
                    dictionary["Croissant"]++;
                    waterQueue.Dequeue();
                    flourStack.Pop();
                }
                if (waterPercentage == 30 && flourPercentage == 70)
                {
                    dictionary["Baguette"]++;
                    waterQueue.Dequeue();
                    flourStack.Pop();
                }
                if (waterPercentage == 20 && flourPercentage == 80)
                {
                    dictionary["Bagel"]++;
                    waterQueue.Dequeue();
                    flourStack.Pop();
                }
            }

            foreach (var item in dictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if(item.Value > 0)
                {
                    Console.WriteLine($"{item.Value}: {item.Key}");
                }
            }

            var waterLeft = waterQueue.Count == 0 ? "None" : String.Join(", ", waterQueue);
            var flourLeft = flourStack.Count == 0 ? "None" : String.Join(", ", flourStack);

            Console.WriteLine($"Water Left: {waterLeft}");
            Console.WriteLine($"Flour Left: {flourLeft}");

        }
    }
}
