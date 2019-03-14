namespace _5_RubiksMatrix
{
    using System;
    using System.Linq;

    public class RubiksMatrix
    {
        public static void Main()
        {
            var inLine = Console.ReadLine()
                .Trim()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = inLine[0];
            var cols = inLine[1];

            int[][] matrix = new int[rows][];

            FillMatrix(rows, cols, matrix);

            var n = int.Parse(Console.ReadLine());

            MoveInMatrix(n, matrix);

            RearrangeMatrix(matrix);
        }

        private static void RearrangeMatrix(int[][] matrix)
        {
            int crrnt = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    crrnt++;
                    if (matrix[row][col] == crrnt)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < matrix.Length; r++)
                        {
                            for (int c = 0; c < matrix[0].Length; c++)
                            {
                                if (matrix[r][c] == crrnt)
                                {
                                    var temp = matrix[row][col];
                                    matrix[row][col] = matrix[r][c];
                                    matrix[r][c] = temp;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void MoveInMatrix(int n, int[][] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine()
                    .Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var rowCol = int.Parse(commands[0]);
                var direction = commands[1];
                var moves = int.Parse(commands[2]);

                switch (direction)
                {
                    case "up":
                        MoveUpDown(matrix, moves, rowCol, direction);
                        break;
                    case "down":
                        MoveUpDown(matrix, matrix.Length - moves % matrix.Length, rowCol, direction);
                        break;
                    case "left":
                        MoveLeftRifgt(matrix, moves, rowCol, direction);
                        break;
                    case "right":
                        MoveLeftRifgt(matrix, matrix[0].Length - moves % matrix[0].Length, rowCol, direction);
                        break;
                }
            }
        }

        private static void MoveLeftRifgt(int[][] matrix, int moves, int rowCol, string direction)
        {
            int[] crrnt = new int[matrix[0].Length];
            for (int c = 0; c < matrix[0].Length; c++)
            {
                crrnt[c] = matrix[rowCol][(c + moves) % matrix[0].Length];
            }

            matrix[rowCol] = crrnt;
        }

        private static void MoveUpDown(int[][] matrix, int moves, int rowCol, string direction)
        {
            int[] crrnt = new int[matrix.Length];

            for (int r = 0; r < matrix.Length; r++)
            {
                crrnt[r] = matrix[(r + moves) % matrix.Length][rowCol];
            }

            for (int r = 0; r < matrix.Length; r++)
            {
                matrix[r][rowCol] = crrnt[r];
            }
        }

        private static void FillMatrix(int rows, int cols, int[][] matrix)
        {
            var fillNmbr = 1;
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = fillNmbr;
                    fillNmbr++;
                }
            }
        }
    }
}