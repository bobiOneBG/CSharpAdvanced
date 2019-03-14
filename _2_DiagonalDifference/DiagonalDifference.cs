namespace _2_DiagonalDifference
{
    using System;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine().Trim());

            int[][] matrix = new int[rows][];

            var leftSum = 0;
            var rightSum = 0;

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
                leftSum += matrix[row][row];
                rightSum += matrix[row][rows - 1 - row];
            }

            Console.WriteLine(Math.Abs(leftSum - rightSum));
        }
    }
}