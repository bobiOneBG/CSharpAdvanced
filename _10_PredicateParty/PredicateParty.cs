namespace _10_PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateParty
    {
        public static void Main()
        {
            List<string> names = Console.ReadLine().Split().ToList();

            Dictionary<string, Func<string, string, bool>> predicates = new Dictionary<string, Func<string, string, bool>>
            {
                { "StartsWith", (name, substr) => name.StartsWith(substr) },
                { "EndsWith", (name, substr) => name.EndsWith(substr) },
                { "Length",(name, length)=>name.Length==int.Parse(length) }
            };

            List<string> filteredNames = new List<string>();

            string line;
            while ((line = Console.ReadLine()) != "Party!")
            {
                string[] args = line.Split();

                string action = args[0];
                string condition = args[1];
                string param = args[2];


                for (int i = 0; i < names.Count; i++)
                {
                    if (predicates[condition](names[i], param))
                    {
                        if (action == "Double")
                        {
                            names.Insert(i, names[i]);
                            i++;
                        }

                        else if (action == "Remove")
                        {
                            names.Remove(names[i]);
                            i--;
                        }                        
                    }
                }
            }

            if (names.Count != 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }

            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
