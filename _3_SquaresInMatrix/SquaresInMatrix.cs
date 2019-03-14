namespace _3_SquaresInMatrix
{
    using System;
    using System.Linq;

    public class SquaresInMatrix
    {
        public static void Main()
        {
            var rows = Console.ReadLine()
                .Trim()
                .Split()
                .Select(int.Parse)
                .ToArray()[0];

            var matrix = new char[rows][];
            for (var row = 0; row < rows; row++)
                matrix[row] = Console.ReadLine()
                    .Trim()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

            var crrnt = 0;
            for (var row = 0; row < rows - 1; row++)
                for (var col = 0; col < matrix[0].Length - 1; col++)
                    if (matrix[row][col] == matrix[row][col + 1] &&
                        matrix[row][col] == matrix[row + 1][col] &&
                        matrix[row][col] == matrix[row + 1][col + 1])
                        crrnt++;

            Console.WriteLine(crrnt);
        }
    }
}