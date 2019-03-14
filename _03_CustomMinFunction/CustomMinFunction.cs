namespace _03_CustomMinFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomMinFunction
    {
        public static void Main()
        {
            var nmbrs = Console.ReadLine().Split().Select(int.Parse);

            Func<IEnumerable<int>, int> minNmbr = x => nmbrs.Min();

            Console.WriteLine(minNmbr(nmbrs));
        }
    }
}