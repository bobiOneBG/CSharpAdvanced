namespace _1_MatrixOfPalindromes
{
    using System;
    using System.Linq;

    public class MatrixOfPalindromes
    {
       public static void Main()
        {
            int[] inLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var rows = inLine[0];
            var cols = inLine[1];

            string[][] matrix = new String[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new string[cols];

                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = (char)(row + 97) +
                                       ((char)(97 + row + col)).ToString() +
                                       (char)(row + 97);
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}