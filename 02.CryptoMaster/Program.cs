namespace CryptoMaster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CryptoMasterStartUp
    {
        public static void Main()
        {
            var sequence = new List<int>(Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var Maxcntr = 1;
            for (int i = 0; i < sequence.Count; i++)
            {
                var crrntCntr = 1;
                var ert = i;
                for (int j = 1; j < sequence.Count; j++)
                {
                    for (int k = 0; k < sequence.Count; k++)
                    {
                        var seeYou = (i + j) % sequence.Count;
                        if (sequence[i] < sequence[seeYou])
                        {
                            i = (i + j) % sequence.Count;
                            crrntCntr++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    i = ert;
                    if (crrntCntr > Maxcntr)
                    {
                        Maxcntr = crrntCntr;
                    }

                    crrntCntr = 1;
                }
            }

            Console.WriteLine(Maxcntr);
        }
    }
}