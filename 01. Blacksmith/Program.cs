using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Blacksmith
{
    public class Program
    {
        static void Main(string[] args)
        {
            var steel = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var carbon = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queueSteel = new Queue<int>(steel);
            var stackCarbon = new Stack<int>(carbon);

            int craftedSwords = 0;

            var swordsCollection = new Dictionary<string, int>()
            {
                {"Gladius", 0},
                {"Shamshir", 0},
                {"Katana", 0},
                {"Sabre", 0},
                {"Broadsword", 0 }
            };

            while (queueSteel.Count > 0 && stackCarbon.Count > 0)
            {
                var currentSteel = queueSteel.Peek();
                var currentCarbon = stackCarbon.Peek();
                var sum = currentSteel + currentCarbon;

                if(sum == 70)
                {
                    swordsCollection["Gladius"]++;
                    craftedSwords++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 80)
                {
                    swordsCollection["Shamshir"]++;
                    craftedSwords++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 90)
                {
                    swordsCollection["Katana"]++;
                    craftedSwords++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 110)
                {
                    swordsCollection["Sabre"]++;
                    craftedSwords++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else if (sum == 150)
                {
                    swordsCollection["Broadsword"]++;
                    craftedSwords++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                }
                else
                {
                    queueSteel.Dequeue();
                    var newCarbon = currentCarbon + 5;
                    stackCarbon.Pop();
                    stackCarbon.Push(newCarbon);
                }
            }

            if(craftedSwords > 0)
            {
                Console.WriteLine($"You have forged {craftedSwords} swords.");
            }
            else
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
            }

            var steelLeft = queueSteel.Count == 0 ? "none" : String.Join(", ", queueSteel);
            var carbonLeft = stackCarbon.Count == 0 ? "none" : String.Join(", ", stackCarbon);

            Console.WriteLine($"Steel left: {steelLeft}");
            Console.WriteLine($"Carbon left: {carbonLeft}");

            foreach (var kvp in swordsCollection.OrderBy(x => x.Key))
            {
                if(kvp.Value > 0)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
        }
    }
}
