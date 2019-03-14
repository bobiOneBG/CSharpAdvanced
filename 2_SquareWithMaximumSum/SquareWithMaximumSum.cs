namespace _2_SquareWithMaximumSum
{
    using System;
    using System.Linq;


    public class SquareWithMaximumSum
    {
        public static void Main()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var inLine = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var rows = int.Parse(inLine[0]);
            var cols = int.Parse(inLine[1]);

            int[][] matrix = new int[rows][];
            int[][] rslt = new int[2][];

            FillMatrix(rows, cols, matrix);

            var start = CheckMaxSquareSum(matrix);

            PrintRslt(matrix, start);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }

        private static void PrintRslt(int[][] matrix, int[] start)
        {
            var row = start[0];
            var col = start[1];
            var sum = start[2];
            Console.WriteLine($"{matrix[row][col]} {matrix[row][col + 1]}");
            Console.WriteLine($"{matrix[row + 1][col]} {matrix[row + 1][col + 1]}");
            Console.WriteLine(sum);
        }

        //find maxSum square,return start index for maxSum square
        private static int[] CheckMaxSquareSum(int[][] matrix)
        {
            var indxMax = new int[3];
            var mxSum = int.MinValue;
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[0].Length - 1; col++)
                {
                    var crrntSum = matrix[row][col] + matrix[row][col + 1] +
                                   matrix[row + 1][col] + matrix[row + 1][col + 1];
                    if (crrntSum > mxSum)
                    {
                        mxSum = crrntSum;
                        indxMax[0] = row;
                        indxMax[1] = col;
                        indxMax[2] = mxSum;
                    }
                }
            }

            return indxMax;
        }

        private static void FillMatrix(int rows, int cols, int[][] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                int[] crrntRow = new int[cols];

                crrntRow = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                matrix[row] = crrntRow;
            }
        }
    }
}