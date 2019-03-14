namespace NumberWars
{
    using System;
    using System.Collections.Generic;
    public class NumberWarsStartUp
    {
        public static void Main()
        {
            var frstPlr =
                new Queue<string>(Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            var scndPlr = new Queue<string>(Console.ReadLine().Split(new[] { " " },
                StringSplitOptions.RemoveEmptyEntries));
            var cntr = 0;
            while (frstPlr.Count > 0 && scndPlr.Count > 0)
            {
                var frstCrd = frstPlr.Dequeue();
                var frstCrdValue = int.Parse(frstCrd.Substring(0, frstCrd.Length - 1));

                var scndCrd = scndPlr.Dequeue();
                var scndCrdValue = int.Parse(scndCrd.Substring(0, scndCrd.Length - 1));

                if (frstCrdValue > scndCrdValue)
                {
                    cntr++;
                    frstPlr.Enqueue(frstCrd);
                    frstPlr.Enqueue(scndCrd);
                }
                else if (frstCrdValue < scndCrdValue)
                {
                    cntr++;
                    scndPlr.Enqueue(scndCrd);
                    scndPlr.Enqueue(frstCrd);
                }
                else
                {
                    Voina(frstPlr, scndPlr, cntr);
                    Environment.Exit(0);
                }
            }

            if (frstPlr.Count != 0)
            {
                Console.WriteLine($"First player wins after {cntr} turns");
            }

            if (scndPlr.Count != 0)
            {
                Console.WriteLine($"Second player wins after {cntr} turns");
            }

            if (cntr == 1000000)
            {
                if (frstPlr.Count > scndPlr.Count)
                {
                    Console.WriteLine($"First player wins after {cntr} turns");
                }
                else if (frstPlr.Count < scndPlr.Count)
                {
                    Console.WriteLine($"Second player wins after {cntr} turns");
                }
                else
                {
                    Console.WriteLine($"Draw after {cntr} turns");
                }
            }
        }

        private static void Voina(Queue<string> frstPlr, Queue<string> scndPlr, int cntr)
        {
            var sumFrst = 0;
            var sumScnd = 0;

            var frstFrst = frstPlr.Dequeue();
            var frstScnd = frstPlr.Dequeue();
            var frstThrd = frstPlr.Dequeue();
            var scndFrst = scndPlr.Dequeue();
            var scndScnd = scndPlr.Dequeue();
            var scndThrd = scndPlr.Dequeue();

            for (int i = 0; i < 3; i++)
            {
                sumFrst += frstFrst[frstFrst.Length - 1];
                sumFrst += frstScnd[frstScnd.Length - 1];
                sumFrst += frstThrd[frstThrd.Length - 1];
                sumScnd += scndFrst[scndFrst.Length - 1];
                sumScnd += scndScnd[scndScnd.Length - 1];
                sumScnd += scndThrd[scndThrd.Length - 1];
            }

            if (sumFrst > sumScnd)
            {
                frstPlr.Enqueue(frstFrst);
                frstPlr.Enqueue(frstScnd);
                frstPlr.Enqueue(frstThrd);
                frstPlr.Enqueue(scndFrst);
                frstPlr.Enqueue(scndScnd);
                frstPlr.Enqueue(scndThrd);
                cntr++;
                Console.WriteLine($"First player wins after {cntr} turns");
            }
            else if (sumFrst < sumScnd)
            {
                scndPlr.Enqueue(scndFrst);
                scndPlr.Enqueue(scndScnd);
                scndPlr.Enqueue(scndThrd);
                scndPlr.Enqueue(frstFrst);
                scndPlr.Enqueue(frstScnd);
                scndPlr.Enqueue(frstThrd);
                cntr++;
                Console.WriteLine($"Second player wins after {cntr} turns");
            }
            else
            {
                if (frstPlr.Count == 0)
                {
                    cntr++;
                    Console.WriteLine($"Draw after {cntr} turns");
                    Environment.Exit(0);
                }

                Voina(frstPlr, scndPlr, cntr);
            }

        }
    }
}