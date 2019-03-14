using System;
using System.Linq;

namespace Exrc_02_KnightsOfHonor
{
    public class KnightsOfHonor
    {
        public static void Main()
        {
            var inline = Console.ReadLine().Split();
            Action<string[]> addSir = ToPrint;
            addSir(inline);
        }

        private static void ToPrint(string[] inLine)
        {
            inLine.ToList().ForEach(x => Console.WriteLine($"Sir {x}"));
        }
    }
}