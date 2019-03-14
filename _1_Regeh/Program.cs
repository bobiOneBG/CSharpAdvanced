namespace Regeh
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class RegehStartUp
    {
        public static void Main()
        {
            string pattern = @"\[[A-Za-z]+<(\d+)REGEH(\d+)>[A-Za-z]+\]";

            var input = Console.ReadLine();

            var regex = new Regex(pattern);
            var list = new List<int>();
            foreach (Match match in regex.Matches(input))
            {
                list.Add(int.Parse(match.Groups[1].Value));
                list.Add(int.Parse(match.Groups[2].Value));
            }

            int crrnt = 0;
            foreach (var indx in list)
            {
                crrnt += indx;
                var charIndx = crrnt % (input.Length - 1);
                Console.Write(input[charIndx]);
            }
        }
    }
}