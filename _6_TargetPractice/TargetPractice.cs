namespace Exrc_6_TargetPractice
{
    using System;
    using System.Linq;

    public class TargetPractice
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine().Split();

            var rows = int.Parse(dimensions[0]);
            var cols = int.Parse(dimensions[1]);

            var matrix = new string[rows][];

            var snake = Console.ReadLine();

            FillMatrix(snake, matrix, rows, cols);

            var paramtrs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var impactRow = paramtrs[0];
            var impactCol = paramtrs[1];
            var radius = paramtrs[2];

            ImpactElmns(matrix, impactRow, impactCol, radius);

            DropMatrix(matrix);

            PrintRslt(matrix);
        }

        private static void PrintRslt(string[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void DropMatrix(string[][] matrix)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                for (int row = matrix.Length - 1; row >= 1; row--)
                {
                    if (matrix[row][col] == " ")
                    {
                        for (int i = row - 1; i >= 0; i--)
                        {
                            if (matrix[i][col] != " ")
                            {
                                var temp = matrix[row][col];
                                matrix[row][col] = matrix[i][col];
                                matrix[i][col] = temp;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void ImpactElmns(string[][] matrix, int impactRow, int impactCol, int radius)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    int deltaRow = row - impactRow;
                    int deltaCol = col - impactCol;
                    bool isIn = deltaRow * deltaRow + deltaCol * deltaCol <= radius * radius;
                    if (isIn)
                    {
                        matrix[row][col] = " ";
                    }
                }
            }
        }

        private static void FillMatrix(string snake, string[][] matrix, int rows, int cols)
        {
            var indx = 0;
            var cntr = 0;
            for (int row = rows - 1; row >= 0; row--)
            {
                matrix[row] = new string[cols];
                for (int col = cols - 1; col >= 0; col--)
                {
                    matrix[row][col] = snake[indx % snake.Length].ToString();
                    indx++;
                }

                if (cntr % 2 == 1)
                {
                    Array.Reverse(matrix[row]);
                }

                cntr++;
            }
        }
    }
}