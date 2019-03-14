namespace FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class FilterByAge
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());

            var peoples = new Dictionary<string, int>();

            for (int i = 0; i < count; i++)
            {
                var peopleData = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                peoples.Add(peopleData[0], int.Parse(peopleData[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            var filter = CreateCondtn(condition, age);
            var printer = CreatePrint(format);

            peoples.Where(filter).ToList().ForEach(printer);
        }

        static Func<KeyValuePair<string, int>, bool> CreateCondtn(string condition, int age)
        {
            if (condition == "younger")
                return x => x.Value < age;
            else
                return x => x.Value >= age;
        }

        static Action<KeyValuePair<string, int>> CreatePrint(string format)
        {
            switch (format)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                default:
                    throw new NotImplementedException();
            }
        }
    }
}