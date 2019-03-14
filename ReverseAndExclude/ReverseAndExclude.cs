namespace ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseAndExclude
    {
        public static void Main()
        {
            int[] collection = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int n = int.Parse(Console.ReadLine());

            Predicate<int> nonDivisible = x => x % n != 0;
            Action<IEnumerable<int>> print = seq => Console.WriteLine(string.Join(" ", seq));

            IEnumerable<int> nonDivisibleNums = GetNmbrs(nonDivisible, collection);
            nonDivisibleNums = reverce(nonDivisibleNums);
            print(nonDivisibleNums);
        }

        private static IEnumerable<int> reverce(IEnumerable<int> nonDivisibleNums)
        {
            nonDivisibleNums = nonDivisibleNums.Reverse();
            return nonDivisibleNums;
        }

        private static IEnumerable<int> GetNmbrs(Predicate<int> nonDivisible, int[] collection)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < collection.Length; i++)
            {
                if (nonDivisible(collection[i]))
                {
                    numbers.Add(collection[i]);
                }
            }

            return numbers;
        }
    }
}
