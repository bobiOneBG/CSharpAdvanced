namespace TreasureMap
{
    using System;
    using System.Text.RegularExpressions;
    public class TreasureMap
    {
       public static void Main()
        {
            // ***********  good variant for #!-!#
            // var pattern = @"((?<hash>#)|!)[^#!]*?(?<![a-zA-Z0-9])(?<strName>[a-zA-Z]{4})(?![a-zA-Z0-9])[^#!]*(?<!\d)((?<strNmbr>\d{3})-(?<pssWrd>\d{4}|\d{6}))(?!\d)[^#!]*?(?(hash)!|#)";
            //***********

            var pattrn =
                @"(#|!)[^#!]*?(?<![a-zA-Z0-9])(?<strName>[a-zA-Z]{4})(?![a-zA-Z0-9])[^#!]*(?<!\d)((?<strNmbr>\d{3})-(?<pssWrd>\d{4}|\d{6}))(?!\d)[^#!]*?(#|!)";
            //var regex = new Regex(pattrn);

            var n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var matches = Regex.Matches(Console.ReadLine(), pattrn);

                var neededMatch = matches[matches.Count / 2];

                var street = neededMatch.Groups["strName"].Value;
                var nmbr = neededMatch.Groups["strNmbr"].Value;
                var passwrd = neededMatch.Groups["pssWrd"].Value;

                Console.WriteLine($"Go to str. {street} {nmbr}. Secret pass: {passwrd}.");
            }
        }
    }
}