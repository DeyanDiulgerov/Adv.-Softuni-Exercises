namespace MasterChef
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredients = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var freshness = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var dishes = new Dictionary<string, int>()
            {
                {"Dipping sauce", 0},
                {"Green salad", 0},
                {"Chocolate cake", 0},
                {"Lobster", 0}
            };

            int sauceCounter = 0, saladCounter = 0, cakeCounter = 0, lobsterCounter = 0;

            var ingredientQueue = new Queue<int>(ingredients);
            var freshnessStack = new Stack<int>(freshness);

            while (ingredientQueue.Any() && freshnessStack.Any())
            {
                var currentIngredient = ingredientQueue.Peek();
                var currentFreshness = freshnessStack.Peek();
                var totalFreshnessLvl = currentFreshness * currentIngredient;

                if(currentIngredient == 0)
                {
                    ingredientQueue.Dequeue();
                }

                if(totalFreshnessLvl == 150)
                {
                    dishes["Dipping sauce"]++;
                    sauceCounter++;
                    ingredientQueue.Dequeue();
                    freshnessStack.Pop();
                }
                else if (totalFreshnessLvl == 250)
                {
                    dishes["Green salad"]++;
                    saladCounter++;
                    ingredientQueue.Dequeue();
                    freshnessStack.Pop();
                }
                else if (totalFreshnessLvl == 300)
                {
                    dishes["Chocolate cake"]++;
                    cakeCounter++;
                    ingredientQueue.Dequeue();
                    freshnessStack.Pop();
                }
                else if (totalFreshnessLvl == 400)
                {
                    dishes["Lobster"]++;
                    lobsterCounter++;
                    ingredientQueue.Dequeue();
                    freshnessStack.Pop();
                }
                else
                {
                    freshnessStack.Pop();
                    var newIngredient = currentIngredient + 5;
                    ingredientQueue.Dequeue();
                    ingredientQueue.Enqueue(newIngredient);
                }
            }

            if(sauceCounter >= 1 && saladCounter >= 1 && cakeCounter >= 1 && lobsterCounter >= 1)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if(ingredientQueue.Sum() > 0)
            {
                Console.WriteLine($" Ingredients left: {ingredientQueue.Sum()}");
            }

            foreach (var dish in dishes.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }

        }
    }
}
