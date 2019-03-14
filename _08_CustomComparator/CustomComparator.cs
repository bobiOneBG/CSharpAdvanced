namespace _08_CustomComparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomComparator
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Predicate<int> evenNums = x => x % 2 == 0;

            var result = GetEvenOdd(evenNums, numbers);

            Action<IEnumerable<int>> print = seq =>
                Console.WriteLine(string.Join(' ', seq));
            print(result);
        }

        private static IEnumerable<int> GetEvenOdd(Predicate<int> evenNums, int[] numbers)
        {
            var evens = new List<int>();
            var odds = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (evenNums(numbers[i]))
                {
                    evens.Add(numbers[i]);
                }

                else
                {
                    odds.Add(numbers[i]);
                }
            }

            evens.Sort();
            odds.Sort();

            return evens.Concat(odds);
        }
    }
}
