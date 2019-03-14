namespace _4_PascalTriangle
{
    using System;

    public class PascalTriangle
    {
        public static void Main()
        {
            long rows = long.Parse(Console.ReadLine());

            long[][] pascal = new long[rows][];

            for (long row = 0; row < rows; row++)
            {
                pascal[row] = new long[row + 1];
                pascal[row][0] = 1;
                pascal[row][row] = 1;

                for (long col = 1; col < row; col++)
                {
                    pascal[row][col] = pascal[row - 1][col - 1] + pascal[row - 1][col];
                }
            }

            foreach (var row in pascal)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}