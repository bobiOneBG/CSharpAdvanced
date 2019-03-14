namespace DangerousFloor
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var matrix = new String[8][];
            FillMatrix(matrix);
            string cmmnd;
            while ((cmmnd = Console.ReadLine()) != "END")
            {
                var command = GetCommand(cmmnd);
                var piece = command[0].ToString();

                var rowStrt = int.Parse(command[1].ToString());
                var colStrt = int.Parse(command[2].ToString());
                var rowEnd = int.Parse(command[4].ToString());
                var colEnd = int.Parse(command[5].ToString());

                var strtPssn = true;
                var validMove = false;
                var inBoard = true;
                switch (piece)
                {
                    case "K":
                        if (matrix[rowStrt][colStrt] != "K")
                        {
                            strtPssn = false;
                            Console.WriteLine("There is no such a piece!");
                            break;
                        }

                        if (Math.Abs(rowStrt - rowEnd) <= 1 && Math.Abs(colStrt - colEnd) <= 1 && strtPssn == true)
                        {
                            validMove = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid move!");
                            break;
                        }

                        if (rowEnd < 0 || rowEnd >= 8 || colEnd < 0 || colEnd >= 8)
                        {
                            inBoard = false;
                            Console.WriteLine("Move go out of board!");
                        }

                        if (inBoard && validMove && strtPssn)
                        {
                            matrix[rowEnd][colEnd] = "K";
                            matrix[rowStrt][colStrt] = null;
                        }

                        break;
                    case "R":
                        if (matrix[rowStrt][colStrt] != "R")
                        {
                            strtPssn = false;
                            Console.WriteLine("There is no such a piece!");
                            break;
                        }

                        if ((rowStrt - rowEnd == 0 || colStrt - colEnd == 0) && strtPssn)
                        {
                            validMove = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid move!");
                            break;
                        }

                        if (rowEnd < 0 || rowEnd >= 8 || colEnd < 0 || colEnd >= 8)
                        {
                            inBoard = false;
                            Console.WriteLine("Move go out of board!");
                        }

                        if (inBoard && validMove && strtPssn)
                        {
                            matrix[rowEnd][colEnd] = "R";
                            matrix[rowStrt][colStrt] = null;
                        }

                        break;
                    case "B":
                        if (matrix[rowStrt][colStrt] != "B")
                        {
                            strtPssn = false;
                            Console.WriteLine("There is no such a piece!");
                            break;
                        }

                        if (Math.Abs(rowStrt - rowEnd) == Math.Abs(colStrt - colEnd) && strtPssn)
                        {
                            validMove = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid move!");
                            break;
                        }

                        if (rowEnd < 0 || rowEnd >= 8 || colEnd < 0 || colEnd >= 8)
                        {
                            inBoard = false;
                            Console.WriteLine("Move go out of board!");
                        }

                        if (inBoard && validMove && strtPssn)
                        {
                            matrix[rowEnd][colEnd] = "B";
                            matrix[rowStrt][colStrt] = null;
                        }

                        break;
                    case "Q":
                        if (matrix[rowStrt][colStrt] != "Q")
                        {
                            strtPssn = false;
                            Console.WriteLine("There is no such a piece!");
                            break;
                        }

                        if ((rowStrt - rowEnd == 0 || colStrt - colEnd == 0 ||
                             Math.Abs(rowStrt - rowEnd) == Math.Abs(colStrt - colEnd)) && strtPssn)
                        {
                            validMove = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid move!");
                            break;
                        }

                        if (rowEnd < 0 || rowEnd >= 8 || colEnd < 0 || colEnd >= 8)
                        {
                            inBoard = false;
                            Console.WriteLine("Move go out of board!");
                        }

                        if (inBoard && validMove && strtPssn)
                        {
                            matrix[rowEnd][colEnd] = "Q";
                            matrix[rowStrt][colStrt] = null;
                        }


                        break;
                    case "P":
                        if (matrix[rowStrt][colStrt] != "P")
                        {
                            strtPssn = false;
                            Console.WriteLine("There is no such a piece!");
                            break;
                        }

                        if (rowStrt - rowEnd == 1 && colStrt == colEnd && strtPssn)
                        {
                            validMove = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid move!");
                            break;
                        }


                        if (rowEnd < 0 || rowEnd >= 8 || colEnd < 0 || colEnd >= 8)
                        {
                            inBoard = false;
                            Console.WriteLine("Move go out of board!");
                        }

                        if (inBoard && validMove && strtPssn)
                        {
                            matrix[rowEnd][colEnd] = "P";
                            matrix[rowStrt][colStrt] = null;
                        }

                        break;
                }
            }
        }

        private static string GetCommand(String cmmnd)
        {
            if (cmmnd != "END")
            {
                var regex = new Regex(@"([A-Z])(\d)(\d)(-)(\d)(\d)");
                Match moves = regex.Match(cmmnd);
                var vvv = moves.ToString();
                return vvv;
            }
            else
                return "END";
        }

        private static void FillMatrix(string[][] matrix)
        {
            for (int row = 0; row < 8; row++)
            {
                matrix[row] = new string[8];
                var inLine = Console.ReadLine().Split(',');
                for (int col = 0; col < 8; col++)
                {
                    if (inLine[col] != "x")

                        matrix[row][col] = inLine[col];
                }
            }
        }
    }
}