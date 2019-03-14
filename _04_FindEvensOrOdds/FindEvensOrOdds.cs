namespace _04_FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindEvensOrOdds
    {
        public static void Main()
        {
            var range = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();


            var target = Console.ReadLine();

            Predicate<int> even = n => n % 2 == 0;

            var nmbrs = GetNmbrs(even, range, target);
            Console.WriteLine(string.Join(" ", nmbrs));
        }

        private static List<int> GetNmbrs(Predicate<int> even, int[] range, string target)
        {
            var nmbrs = new List<int>();
            for (int i = range[0]; i <= range[1]; i++)
            {
                if (even(i) && target == "even" || !even(i) && target == "odd")
                {
                    nmbrs.Add(i);
                }
            }

            return nmbrs;
        }
    }
}
