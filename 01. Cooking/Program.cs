using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Cooking
{
    public class Program
    {
        static void Main(string[] args)
        {
            var liquids = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var ingredients = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queueLiquid = new Queue<int>(liquids);
            var sstackIngredients = new Stack<int>(ingredients);

            var breadCounter = 0;
            var cakeCounter = 0;
            var pastryCounter = 0;
            var pieCounter = 0;


            var foods = new Dictionary<string, int>()
            {
                {"Bread", 0},
                {"Cake", 0},
                {"Pastry", 0},
                {"Fruit Pie", 0},
            };

            while (queueLiquid.Count > 0 && sstackIngredients.Count > 0)
            {
                var currentLiquid = queueLiquid.Peek();
                var currentIngredient = sstackIngredients.Peek();
                var sum = currentIngredient + currentLiquid;

                if (sum == 25)
                {
                    foods["Bread"]++;
                    breadCounter++;
                    queueLiquid.Dequeue();
                    sstackIngredients.Pop();
                }
                else if (sum == 50)
                {
                    foods["Cake"]++;
                    cakeCounter++;
                    queueLiquid.Dequeue();
                    sstackIngredients.Pop();
                }
                else if (sum == 75)
                {
                    foods["Pastry"]++;
                    pastryCounter++;
                    queueLiquid.Dequeue();
                    sstackIngredients.Pop();
                }
                else if (sum == 100)
                {
                    foods["Fruit Pie"]++;
                    pieCounter++;
                    queueLiquid.Dequeue();
                    sstackIngredients.Pop();
                }
                else
                {
                    queueLiquid.Dequeue();
                    var newIngredient = currentIngredient + 3;
                    sstackIngredients.Pop();
                    sstackIngredients.Push(newIngredient);
                }
            }

            if (breadCounter > 0 && cakeCounter > 0 && pastryCounter > 0 && pieCounter > 0)
            {
                Console.WriteLine($"Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine($"Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            var liquidsLeft = queueLiquid.Count == 0 ? "none" : String.Join(", ", queueLiquid);
            var ingredientsLeft = sstackIngredients.Count == 0 ? "none" : String.Join(", ", sstackIngredients);


            Console.WriteLine($"Liquids left: {liquidsLeft}");
            Console.WriteLine($"Ingredients left: {ingredientsLeft}");

            foreach (var food in foods.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}
