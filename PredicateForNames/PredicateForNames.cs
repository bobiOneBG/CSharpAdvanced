namespace _07_PredicateForNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateForNames
    {
        public static void Main()
        {
            int nameLength = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            Predicate<string> validName = x => x.Length <= nameLength;

            var validNames = GetValidNames(validName, names);

            Action<IEnumerable<string>> print = seq =>
                Console.WriteLine(string.Join(Environment.NewLine, seq));

            print(validNames);
        }

        private static IEnumerable<string> GetValidNames(Predicate<string> validName, string[] names)
        {
            List<string> validNames = new List<string>();

            for (int i = 0; i < names.Length; i++)
            {
                if (validName(names[i]))
                {
                    validNames.Add(names[i]);
                }
            }

            return validNames;
        }
    }
}