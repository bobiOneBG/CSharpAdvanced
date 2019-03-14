namespace CountUppercaseWords
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Where(n => n[0] == n.ToUpper()[0])
                .ToList()
                .ForEach(Console.WriteLine);

        }
    }
}
