namespace Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        public static void Main()
        {
            string inLine;
            string department;
            string doctor;
            string patient;

            var dprtmnt = new Dictionary<string, List<string>>();
            var dctrs = new Dictionary<string, List<string>>();

            while ((inLine = Console.ReadLine()) != "Output")
            {
                string[] line = inLine.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                department = line[0];
                doctor = line[1] + " " + line[2];
                patient = line[3];

                if (!dprtmnt.ContainsKey(department))
                {
                    dprtmnt[department] = new List<string>();
                }

                if (dprtmnt[department].Count <= 60)
                {
                    dprtmnt[department].Add(patient);
                }

                if (!dctrs.ContainsKey(doctor))
                {
                    dctrs[doctor] = new List<string>();
                }

                dctrs[doctor].Add(patient);
            }

            while ((inLine = Console.ReadLine()) != "End")
            {
                var line = inLine.Trim().Split(new[] { " " },
                    StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (line.Length > 1)
                {
                    bool isDepart = int.TryParse(line[1], out int r);
                    if (isDepart)
                    {
                        var depa = line[0];
                        var room = int.Parse(line[1]);
                        var rum = 3 * (room - 1);
                        var tpPrint = new SortedSet<string>();

                        for (int i = 0; i < 3; i++)
                        {
                            tpPrint.Add(dprtmnt[depa][rum + i]);
                        }

                        foreach (var p in tpPrint)
                        {
                            Console.WriteLine(p);
                        }
                    }
                    else if (isDepart == false)
                    {
                        var doki = line[0] + " " + line[1];
                        foreach (var p in dctrs[doki].OrderBy(x => x))
                        {
                            Console.WriteLine(p);
                        }
                    }
                }

                else if (dprtmnt.ContainsKey(line[0]))
                {
                    var depo = line[0];
                    foreach (var p in dprtmnt[depo])
                    {
                        Console.WriteLine(p);
                    }
                }
            }
        }
    }
}