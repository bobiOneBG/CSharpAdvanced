namespace _09_ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListOfPredicates
    {
        public static void Main()
        {
            int range = int.Parse(Console.ReadLine());

            int[] divisors = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int lsm = LSM(divisors);

            Predicate<int> divisible = x => x % lsm == 0;

            IEnumerable<int> divisibleNums = GetDivisibles(divisible, range, lsm);

            Action<IEnumerable<int>> print = seq =>
                Console.WriteLine(string.Join(' ', seq));

            print(divisibleNums);
        }

        private static IEnumerable<int> GetDivisibles(Predicate<int> divisible, int range, int lsm)
        {
            List<int> result = new List<int>();

            for (int i = lsm; i <= range; i += lsm)
            {
                if (divisible(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }

        public static int LSM(int[] element_array)
        {
            int lcm = 1;
            int divisor = 2;

            while (true)
            {

                int counter = 0;
                bool divisible = false;
                for (int i = 0; i < element_array.Length; i++)
                {
                    if (element_array[i] == 0)
                    {
                        return 0;
                    }
                    else if (element_array[i] < 0)
                    {
                        element_array[i] = element_array[i] * (-1);
                    }
                    if (element_array[i] == 1)
                    {
                        counter++;
                    }

                    if (element_array[i] % divisor == 0)
                    {
                        divisible = true;
                        element_array[i] = element_array[i] / divisor;
                    }
                }

                if (divisible)
                {
                    lcm = lcm * divisor;
                }
                else
                {
                    divisor++;
                }

                if (counter == element_array.Length)
                {
                    return lcm;
                }
            }
        }
    }
}
