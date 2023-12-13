using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class CombinationsCheck
    {
        static void Main_1(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("Saha");
            list.Add("Gill");
            list.Add("Salt");
            list.Add("Warner");
            //list.Add("Jaiswal");
            //list.Add("Surya");
            int rownum = 0;
            foreach (var sequence in list.Combinations())
            {
                if (sequence.Count() == 2)
                {
                    Console.WriteLine(++rownum + ". " + $"({string.Join(",", sequence)})");
                    if (rownum != 0 && rownum % 5 == 0)
                        Console.WriteLine();
                    //Console.WriteLine($"{string.Join(" ", sequence)}");
                }
            }
            Console.ReadLine();
        }

        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> items)
        {
            if (!items.Any())
                yield return items;
            else
            {
                var head = items.First();
                var tail = items.Skip(1);
                foreach (var sequence in tail.Combinations())
                {
                    yield return sequence; // Without first
                    yield return sequence.Prepend(head);
                }
            }
        }
    }
}
