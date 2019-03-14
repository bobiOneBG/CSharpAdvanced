namespace KnightGame
{
    using System;
    using System.Collections.Generic;

    public class KnightGameStartUp
    {
        private static int _toRmve;
        private static int _minCnt;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new char[n][];

            FillMatrix(n, matrix);
            var kCases = new Queue<int[]>();

            ChessField(matrix, kCases);

            Console.WriteLine(_minCnt);
        }

        private static void ChessField(char[][] matrix, Queue<int[]> kCases)
        {
            var row = 0;
            var col = 0;

            for (row = 0; row < matrix.Length; row++)
            {
                for (col = 0; col < matrix.Length; col++)
                {
                    if (matrix[row][col] == 'K')
                    {
                        int[] crrnt = { row, col };
                        kCases.Enqueue(crrnt);
                    }
                }
            }


            for (int i = 0; i < kCases.Count; i++)
            {
                var kn = kCases.Dequeue();
                CheckForKnght(matrix, kCases, out _minCnt, kn);
                kCases.Enqueue(kn);
            }

            // CheckForKnght(matrix, kCases, _minCnt);
        }

        private static void CheckForKnght(char[][] matrix, Queue<int[]> kCases, out int _minCnt, int[] kn)
        {
            var removeta = new List<int>();
            _minCnt = Int32.MaxValue;
            foreach (var v in kCases)
            {
                int[] twoROneCRightU = { v[0] + 2, v[1] + 1 };
                int[] twoROneCLeftU = { v[0] - 2, v[1] + 1 };
                int[] twoROneCRightD = { v[0] + 2, v[1] - 1 };
                int[] twoROneCLeftD = { v[0] - 2, v[1] - 1 };
                int[] oneRTwoCRightU = { v[0] + 1, v[1] + 2 };
                int[] oneRTwoCRightD = { v[0] + 1, v[1] - 2 };
                int[] oneRTwoCLeftU = { v[0] - 1, v[1] + 2 };
                int[] oneRTwoCLeftD = { v[0] - 1, v[1] - 2 };

                var points = new HashSet<int[]>();

                points.Add(twoROneCRightU);
                points.Add(twoROneCLeftU);
                points.Add(twoROneCRightD);
                points.Add(twoROneCLeftD);
                points.Add(oneRTwoCRightU);
                points.Add(oneRTwoCRightD);
                points.Add(oneRTwoCLeftU);
                points.Add(oneRTwoCLeftD);
                var l = matrix.Length;

                foreach (var point in points)
                {
                    if (IsValid(point, l))
                    {
                        if (matrix[point[0]][point[1]] == 'K' && matrix[v[0]][v[1]] == 'K')
                        {
                            matrix[point[0]][point[1]] = 'O';
                            _toRmve++;
                        }
                    }
                }
            }


            if (_toRmve < _minCnt)
            {
                removeta.Add(_toRmve);
                _toRmve = 0;
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix.Length; col++)
                    {
                        if (matrix[row][col] == 'O')
                        {
                            matrix[row][col] = 'K';
                        }
                    }
                }
            }

        }

        private static bool IsValid(int[] point, int l)
        {
            return point[0] > 0 && point[0] < l && point[1] > 0 && point[1] < l;
        }

        private static void FillMatrix(int n, char[][] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                var inLine = Console.ReadLine().Trim().ToCharArray();
                matrix[row] = inLine;
            }
        }
    }
}