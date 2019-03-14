namespace _1_SumMatrixElements
{
    using System;
    using System.Linq;

    public class SumMatrixElements
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            // .ToArray();

            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);

            int[][] matrix = new int[rows][];
            var sum = 0;
            //fill matrix and sum
            for (int row = 0; row < rows; row++)
            {
                int[] crrnt = new int[cols];
                crrnt = Console.ReadLine().Trim()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                sum += crrnt.Sum();
                matrix[row] = crrnt;
            }

            //Print result
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}