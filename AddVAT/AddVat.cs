namespace AddVAT
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.None)
                .Select(double.Parse)
                .Select(x => x * 1.2)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:f2}"));

        }
    }
}
