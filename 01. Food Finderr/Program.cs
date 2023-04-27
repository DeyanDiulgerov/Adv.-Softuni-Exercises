using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01.Food_Finderr
{
    public class Program
    {
        static void Main(string[] args)
        {
            var vowels = Console.ReadLine().Split().Select(char.Parse).ToArray();
            var consonants = Console.ReadLine().Split().Select(char.Parse).ToArray();


            var queueVowels = new Queue<char>(vowels);
            var stackConsonants = new Stack<char>(consonants);

            var foodFinder = new Dictionary<string, int>()
            {
                {"pear", 0},
                {"flour", 0},
                {"pork", 0},
                {"olive", 0}
            };

            var pear = "pear".ToCharArray().ToList();
            var flour = "flour".ToCharArray().ToList();
            var pork = "pork".ToCharArray().ToList();
            var olive = "olive".ToCharArray().ToList();



            while (queueVowels.Count > 0 && stackConsonants.Count > 0)
            {
                var currentVowel = queueVowels.Dequeue();
                queueVowels.Enqueue(currentVowel);
                var currentConsonant = stackConsonants.Pop();


                if (pear.Contains(currentVowel))
                {
                    pear.Remove(currentVowel);
                }
                if(pear.Contains(currentConsonant))
                {
                    pear.Remove(currentConsonant);
                }
                if (flour.Contains(currentVowel))
                {
                    flour.Remove(currentVowel);
                }
                if (flour.Contains(currentConsonant))
                {
                    flour.Remove(currentConsonant);
                }
                if (pork.Contains(currentVowel))
                {
                    pork.Remove(currentVowel);
                }
                if (pork.Contains(currentConsonant))
                {
                    pork.Remove(currentConsonant);
                }
                if (olive.Contains(currentVowel))
                {
                    olive.Remove(currentVowel);
                }
                if (olive.Contains(currentConsonant))
                {
                    olive.Remove(currentConsonant);
                }

                if(pear.Count == 0)
                {
                    foodFinder["pear"]++;
                    pear = "pear".ToCharArray().ToList();
                }
                if (flour.Count == 0)
                {
                    foodFinder["flour"]++;
                    flour = "flour".ToCharArray().ToList();
                }
                if (pork.Count == 0)
                {
                    foodFinder["pork"]++;
                    pork = "pork".ToCharArray().ToList();
                }
                if (olive.Count == 0)
                {
                    foodFinder["olive"]++;
                    olive = "olive".ToCharArray().ToList();
                }
            }
            Console.WriteLine($"Words found: {foodFinder.Sum(x => x.Value)}");

            foreach (var kvp in foodFinder.Where(x => x.Value > 0).ToDictionary(x => x.Key, x => x.Value))
             {
                 if (kvp.Value > 0)
                 {
                     Console.WriteLine($"{kvp.Key}");
                 }                  
             }

        }
    }
}
