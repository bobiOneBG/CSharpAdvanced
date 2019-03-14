namespace _4_MaximalSum
{
    using System;
    using System.Linq;

    public class MaximalSum
    {
        public static void Main()
        {
            var rows = Console.ReadLine()
                .Trim()
                .Split()
                .Select(int.Parse)
                .ToArray()[0];

            var matrix = new int[rows][];
            for (var row = 0; row < rows; row++)
                matrix[row] = Console.ReadLine()
                    .Trim()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            var maxSum = int.MinValue;
            var rowX = 0;
            var colX = 0;

            FindMaxSum(matrix, out maxSum, out rowX, out colX);

            PrintRslt(matrix, maxSum, rowX, colX);
        }

        private static void PrintRslt(int[][] matrix, int maxSum, int rowX, int colX)
        {
            Console.WriteLine($"Sum = {maxSum}");
            for (var i = 0; i < 3; i++)
                Console.WriteLine(
                    $"{matrix[rowX + i][colX]} {matrix[rowX + i][colX + 1]} {matrix[rowX + i][colX + 2]}");
        }

        private static void FindMaxSum(int[][] matrix, out int maxSum, out int rowX, out int colX)
        {
            maxSum = int.MinValue;
            rowX = 0;
            colX = 0;
            for (var row = 0; row < matrix.Length - 2; row++)
                for (var col = 0; col < matrix[0].Length - 2; col++)
                {
                    //find max sum 3x3 square
                    var crrntSum = 0;
                    for (var i = row; i < row + 3; i++)
                        for (var j = col; j < col + 3; j++)
                            crrntSum += matrix[i][j];

                    if (crrntSum > maxSum)
                    {
                        maxSum = crrntSum;
                        rowX = row;
                        colX = col;
                    }
                }
        }
    }
}