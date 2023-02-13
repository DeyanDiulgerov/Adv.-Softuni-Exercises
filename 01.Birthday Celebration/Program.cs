using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Birthday_Celebration
{
    public class Program
    {
        static void Main(string[] args)
        {
            var guestsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var platedOfFood = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queueGuests = new Queue<int>(guestsCapacity);
            var stackPlates = new Stack<int>(platedOfFood);

            var wastedFood = 0;

            while (queueGuests.Count > 0 && stackPlates.Count > 0)
            {
                var currentGuest = queueGuests.Peek();
                var currentPlate = stackPlates.Peek();
                
                if(currentPlate >= currentGuest)
                {
                    wastedFood += currentPlate - currentGuest;
                    queueGuests.Dequeue();
                    stackPlates.Pop();
                }
                else if(currentPlate < currentGuest)
                {
                    while (currentGuest > 0)
                    {
                        var newPlate = stackPlates.Peek();
                        if(newPlate > currentGuest)
                        {
                            wastedFood += newPlate - currentGuest;
                        }
                        currentGuest -= newPlate;
                        stackPlates.Pop();
                        //var newPlate = stackPlates.Peek();
                    }

                    queueGuests.Dequeue();
                }
            }

            if(queueGuests.Count > 0)
            {
                Console.WriteLine($"Guests: {String.Join(" ", queueGuests)}");
            }
            else if(stackPlates.Count > 0)
            {
                Console.WriteLine($"Plates: {String.Join(" ", stackPlates)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
