namespace PartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PartyReservation
    {
        public static void Main()
        {
            List<string> invitations = Console.ReadLine().Split().ToList();

            Dictionary<string, Func<string, string, bool>> predicates = new Dictionary<string, Func<string, string, bool>>
            {
                { "Starts with", (name, substr) => name.StartsWith(substr) },
                { "Ends with", (name, substr) => name.EndsWith(substr) },
                { "Length",(name, length)=>name.Length==int.Parse(length) },
                {"Contains", (name, substr) =>name.Contains(substr)}
            };

            var filteredNames = new List<string>();

            string input;
            while ((input=Console.ReadLine())!= "Print")
            {
                var args = input.Split(';');

                var command = args[0];
                var filter = args[1];
                var param = args[2];

                foreach (var name in invitations)
                {
                    if (command == "Add filter")
                    {
                        if (predicates[filter](name, param))
                        {
                            filteredNames.Add(name);

                        }
                    }

                    else if (command == "Remove filter")
                    {
                        if (predicates[filter](name, param))
                        {
                            filteredNames.Remove(name);
                        }
                    }
                }
            }

            foreach (var name in filteredNames)
            {
                invitations.Remove(name);
            }

            Console.WriteLine(string.Join(" ", invitations));
        }
    }
}
