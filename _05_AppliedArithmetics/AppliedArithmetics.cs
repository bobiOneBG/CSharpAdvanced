namespace _05_AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static void Main()
        {
            IEnumerable<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse);

            Func<int, int> add = x => x + 1;
            Func<int, int> multiply = num => num * 2;
            Func<int, int> subtract = num => num - 1;
            Action<IEnumerable<int>> print = seq => Console.WriteLine(string.Join(" ", seq));

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(add).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(multiply).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(subtract).ToList();
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
            }
        }
    }
}