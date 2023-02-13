using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var lillies = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            var roses = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            var stackLillies = new Stack<int>(lillies);
            var queueRoses = new Queue<int>(roses);

            var wreaths = 0;
            var storedFlowers = 0;

            while (stackLillies.Count() > 0 && queueRoses.Count() > 0)
            {
                var currentLillie = stackLillies.Peek();
                var currentRose = queueRoses.Peek();

                var sum = currentLillie + currentRose;

                if(sum == 15)
                {
                    wreaths++;
                    stackLillies.Pop();
                    queueRoses.Dequeue();
                }
                else if(sum > 15)
                {
                    currentLillie = stackLillies.Peek() - 2;
                    stackLillies.Pop();
                    stackLillies.Push(currentLillie);
                }
                else if(sum < 15)
                {
                    storedFlowers += sum;
                    stackLillies.Pop();
                    queueRoses.Dequeue();
                }
            }

            wreaths += storedFlowers / 15;


            if(wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else if(wreaths < 5)
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }

        }
    }
}
