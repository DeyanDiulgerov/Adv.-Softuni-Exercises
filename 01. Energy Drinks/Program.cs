using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Energy_Drinks
{
    public class Program
    {
        static void Main(string[] args)
        {
            var caffeine = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            var energyDrinks = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            var allowedCaffeine = 0;
            var maxCaffeine = 300;

            var stackCaffeine = new Stack<int>(caffeine);
            var queueEnergy = new Queue<int>(energyDrinks);

            while (stackCaffeine.Count > 0 && queueEnergy.Count > 0)
            {
                var currentCaffeine = stackCaffeine.Peek();
                var currentEnergy = queueEnergy.Peek();
                var sum = currentCaffeine * currentEnergy;
                if(sum <= maxCaffeine)
                {
                    allowedCaffeine += sum;
                    maxCaffeine -= sum;
                    stackCaffeine.Pop();
                    queueEnergy.Dequeue();
                }
                else if(sum > maxCaffeine)
                {
                    stackCaffeine.Pop();
                    var newEnergyDrink = queueEnergy.Peek();
                    queueEnergy.Dequeue();
                    queueEnergy.Enqueue(newEnergyDrink);
                    allowedCaffeine -= 30;
                    if(allowedCaffeine < 0)
                    {
                        allowedCaffeine = 0;
                    }
                    maxCaffeine += 30;
                    if(maxCaffeine > 300)
                    {
                        maxCaffeine = 300;
                    }
                }
            }

            if(queueEnergy.Count > 0)
            {
                Console.WriteLine($"Drinks left: {String.Join(", ", queueEnergy)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {allowedCaffeine} mg caffeine.");

        }
    }
}
