namespace _3_GroupNumbersArr
{
    using System;
    using System.Linq;

    public class GroupNumbersArray
    {
        public static void Main()
        {
            var nmbrs = Console.ReadLine()
                .Trim()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var zero = nmbrs.Where(n => Math.Abs(n) % 3 == 0).ToArray();
            var one = nmbrs.Where(n => Math.Abs(n) % 3 == 1).ToArray();
            var two = nmbrs.Where(n => Math.Abs(n) % 3 == 2).ToArray();

            var matrix = new int[3][];

            matrix[0] = zero;
            matrix[1] = one;
            matrix[2] = two;

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}