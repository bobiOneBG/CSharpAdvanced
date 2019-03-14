namespace GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class GreedyTimesStartUp
    {
        public static void Main()
        {
            var capacity = int.Parse(Console.ReadLine());

            var items = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var wealth = new Dictionary<string, Dictionary<string, int>>();

            var amount = 0;
            wealth["Gold"] = new Dictionary<string, int>();
            wealth["Cash"] = new Dictionary<string, int>();
            wealth["Gem"] = new Dictionary<string, int>();

            for (int i = 0; i < items.Length; i += 2)
            {
                var item = items[i];
                var quantty = int.Parse(items[i + 1]);


                //fill gold
                if (item.ToLower() == "gold")
                {

                    if (!wealth["Gold"].ContainsKey(item))
                    {
                        wealth["Gold"][item] = 0;
                    }

                    if (amount + quantty <= capacity)
                    {
                        wealth["Gold"][item] += quantty;
                        amount += quantty;
                    }
                }

                //fill money
                if (item.Length == 3)
                {
                    //The gem amount should always be more than or equal the cash amount at any time

                    bool moneyIsLess = wealth["Cash"].Values.Sum() + quantty <=
                                       wealth["Gem"].Values.Sum();
                    if (!wealth["Cash"].ContainsKey(item))
                    {
                        wealth["Cash"][item] = 0;
                    }

                    if (amount + quantty <= capacity && moneyIsLess)
                    {
                        wealth["Cash"][item] += quantty;
                        amount += quantty;
                    }
                }

                //fill gems
                if (item.Length > 3)
                {
                    var isGem = item.Substring(item.Length - 3);

                    if (isGem.ToLower() == "gem")
                    {
                        bool gemIsLess = wealth["Gem"].Values.Sum() + quantty <=
                                         wealth["Gold"].Values.Sum();
                        if (!wealth["Gem"].ContainsKey(item))
                        {
                            wealth["Gem"].Add(item, 0);
                        }

                        if (amount + quantty <= capacity && gemIsLess)
                        {
                            wealth["Gem"][item] += quantty;
                            amount += quantty;
                        }
                    }
                }
            }

            foreach (var pair in wealth
                .Where(x => x.Value.Values.Sum() > 0)
                .OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.Write($"<{pair.Key}> ${pair.Value.Values.Sum()}");
                Console.WriteLine();
                foreach (var innPair in pair.Value.Where(x => x.Value > 0).OrderByDescending(x => x.Key))
                {
                    Console.WriteLine($"##{innPair.Key} - {innPair.Value}");
                }
            }
        }
    }
}