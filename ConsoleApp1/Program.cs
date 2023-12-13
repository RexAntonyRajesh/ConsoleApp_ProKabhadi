using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main2(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("S Gandola");
            list.Add("S Gulia");
            list.Add("N Kumar");
            list.Add("Sumit");
            list.Add("S Kumar");
            GetCombination(list);
            Console.Read();
        }

        static void GetCombination(List<string> list)
        {
            double count = Math.Pow(2, list.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        Console.Write(list[j] + " - ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
