using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Barista_Contest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var coffee = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            var milk = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            var queueCoffee = new Queue<int>(coffee);
            var stackMilk = new Stack<int>(milk);
 
            var beveragesMade = new Dictionary<string, int>()
            {
                {"Cortado", 0 },
                {"Espresso", 0 },
                {"Capuccino", 0 },
                {"Americano", 0 },
                {"Latte", 0 }
            };

            while (queueCoffee.Count > 0 && stackMilk.Count > 0)
            {
                var currentCoffee = queueCoffee.Peek();
                var currentMilk = stackMilk.Peek();
                var sum = currentCoffee + currentMilk;

                if(sum == 50)
                {
                    queueCoffee.Dequeue();
                    stackMilk.Pop();
                    beveragesMade["Cortado"]++;
                }
                else if (sum == 75)
                {
                    queueCoffee.Dequeue();
                    stackMilk.Pop();
                    beveragesMade["Espresso"]++;
                }
                else if (sum == 100)
                {
                    queueCoffee.Dequeue();
                    stackMilk.Pop();
                    beveragesMade["Capuccino"]++;
                }
                else if (sum == 150)
                {
                    queueCoffee.Dequeue();
                    stackMilk.Pop();
                    beveragesMade["Americano"]++;
                }
                else if (sum == 200)
                {
                    queueCoffee.Dequeue();
                    stackMilk.Pop();
                    beveragesMade["Latte"]++;
                }
                else
                {
                    queueCoffee.Dequeue();
                    var newMilk = currentMilk - 5;
                    stackMilk.Pop();
                    stackMilk.Push(newMilk);
                }
            }

            if(queueCoffee.Count == 0 && stackMilk.Count == 0)
            {
                Console.WriteLine($"Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine($"Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            var coffeeLeft = queueCoffee.Count == 0 ? "none" : String.Join(", ", queueCoffee);
            var milkLeft = stackMilk.Count == 0 ? "none" : String.Join(", ", stackMilk);

            Console.WriteLine($"Coffee left: {coffeeLeft}");
            Console.WriteLine($"Milk left: {milkLeft}");

            foreach (var kvp in beveragesMade.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                if(kvp.Value > 0)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
        }
    }
}
