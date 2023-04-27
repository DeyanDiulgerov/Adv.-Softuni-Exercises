using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Meal_Plan
{
    public class Program
    {
        static void Main(string[] args)
        {
            var mealsCalories = Console.ReadLine().Split().ToArray();
            var caloriesAllowedPerDay = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queueMeals = new Queue<string>(mealsCalories);
            var stackCalories = new Stack<int>(caloriesAllowedPerDay);

            var numberOfMeals = 0;


            while (queueMeals.Count > 0 && stackCalories.Count > 0)
            {
                var mealCalories = 0;
                var currentMeal = queueMeals.Peek();          
                var currentAllowedCalories = stackCalories.Peek();

                if (currentMeal == "salad")
                {
                    mealCalories = 350;
                }
                else if (currentMeal == "soup")
                {
                    mealCalories = 490;
                }
                else if (currentMeal == "pasta")
                {
                    mealCalories = 680;
                }
                else if (currentMeal == "steak")
                {
                    mealCalories = 790;
                }               

                var newCalories = currentAllowedCalories - mealCalories;
                if(newCalories > 0)
                {
                    queueMeals.Dequeue();
                    stackCalories.Pop();
                    stackCalories.Push(newCalories);
                    numberOfMeals++;
                }
                else if (newCalories == 0)
                {
                    stackCalories.Pop();
                    continue;
                }
                else if (newCalories < 0)
                {
                    var leftOverFood = newCalories;
                    stackCalories.Pop();
                    queueMeals.Dequeue();
                    numberOfMeals++;
                    if (stackCalories.Count > 0)
                    {
                        var food = stackCalories.Peek();

                        var newDay = stackCalories.Peek() + leftOverFood;
                        /*queueMeals.Dequeue();
                        numberOfMeals++;*/
                        stackCalories.Pop();
                        stackCalories.Push(newDay);
                    }
                }
            }

            if(queueMeals.Count == 0)
            {
                Console.WriteLine($"John had {numberOfMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {String.Join(", ", stackCalories)} calories.");
            }
            else if(queueMeals.Count > 0)
            {
                Console.WriteLine($"John ate enough, he had {numberOfMeals} meals.");
                Console.WriteLine($"Meals left: {String.Join(", ", queueMeals)}.");
            }
        }
    }
}
