using System;
namespace Practice
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            var rslt = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(rslt.Count);
            Console.WriteLine(rslt.Sum());
        }
    }
}