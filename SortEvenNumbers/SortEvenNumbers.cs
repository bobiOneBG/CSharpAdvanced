namespace SortEvenNumbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var inLine = Console.ReadLine()
                .Split(new[] { ',', ' ' },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(n=>n);

            Console.WriteLine(string.Join(", ", inLine));
        }
    }
}
