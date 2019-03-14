namespace _01_ActionPrint
{
    using System;
    using System.Linq;
    public class ActionPrint
    {
        public static void Main()
        {
            var inLine = Console.ReadLine().Split(' ');

            Action<string[]> printActionDel = ConsolePrint;
            printActionDel(inLine);
        }

        static void ConsolePrint(string[] inLine)
        {
            inLine.ToList().ForEach(Console.WriteLine);
        }
    }
}