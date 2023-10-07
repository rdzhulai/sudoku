using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Lab02
{
    internal class Program
    {

        private const int ROWS = 9;
        private const int COLS = 9;
        private const int SUBROWS = 3;
        private const int SUBCOLS = 3;
        private const char GAP = '.';
        static char[,] LoadSudoku(string problem)
        {
            char[,] grid = new char[ROWS, COLS];

            for (int curRow = 0; curRow < ROWS; ++curRow)
            {
                for (int curCol = 0; curCol < COLS; ++curCol)
                {
                    grid[curRow, curCol] = problem[curRow * ROWS + curCol];
                    if (grid[curRow, curCol] == '0')
                        grid[curRow, curCol] = GAP;
                }
            }

            return grid;
        }

        static void PrintSudoku(char[,] grid)
        {
            for (int curRow = 0; curRow < ROWS; curRow++)
            {
                if (curRow % SUBROWS == 0)
                {
                    Console.WriteLine(new string('-', COLS * 2 + 4));
                }

                for (int curCol = 0; curCol < COLS; curCol++)
                {
                    if (curCol % SUBCOLS == 0)
                    {
                        Console.Write('|');
                    }

                    Console.Write(" " + grid[curRow, curCol]);
                }

                Console.WriteLine('|');
            }

            Console.WriteLine(new string('-', COLS * 2 + 4));
        }
        static bool IsValid(char[,] grid, int row, int col, char value)
        {
            if (grid[row, col] != '.')
                return false;

            for (int curRow = 0; curRow < row; ++curRow)
            {
                if (grid[curRow, col] == value)
                    return false;
            }

            for (int curCol = 0; curCol < col; ++curCol)
            {
                if (grid[row, curCol] == value)
                    return false;
            }

            for (int curRow = row - row % SUBROWS, endRow = curRow + SUBROWS; curRow < endRow; ++curRow)
            {
                for (int curCol = col - col % SUBCOLS, endCol = curCol + SUBCOLS; curCol < endCol; ++curCol)
                {
                    if (grid[curRow, curCol] == value)
                        return false;
                }
            }

            return true;
        }

        static bool SolveSudoku(char[,] grid)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i, j] == '.')
                    {
                        // foreach (char ps in GetPossibleSolutions(grid, i, j))
                        // {
                        //     grid[i, j] = ps;
                        //     if (SolveSudoku(grid))
                        //     {
                        //         return true;
                        //     }
                        //     grid[i, j] = '.';
                        // }
                        for (char k = '1'; k <= '9'; k++)
                        {
                            if (IsValid(grid, i, j, k))
                            {
                                grid[i, j] = k;
                                if (SolveSudoku(grid))
                                {
                                    return true;
                                }
                                grid[i, j] = '.';
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
        private static List<char> GetPossibleSolutions(
            char[,] grid, int row, int col)
        {
            var solutions = "123456789".ToList();

            //  Exclude vertical numbers from solutions.
            for (int curRow = 0; curRow < ROWS; ++curRow)
            {
                if (curRow == row)
                    continue;
                char c = grid[curRow, col];
                if (c != GAP)
                    solutions.Remove(c);
            }

            //  Exclude horizontal numbers from solutions.
            for (int curCol = 0; curCol < COLS; ++curCol)
            {
                if (curCol == col)
                    continue;
                char c = grid[row, curCol];
                if (c != GAP)
                    solutions.Remove(c);
            }

            int subareaStartRowIndex = row / SUBROWS * SUBROWS,
                subareaStartColIndex = col / SUBCOLS * SUBCOLS;

            // Exclude numbers form the subarea.
            for (int curRow = subareaStartRowIndex;
                curRow < subareaStartRowIndex + SUBROWS; ++curRow)
            {
                for (int curCol = subareaStartColIndex;
                    curCol < subareaStartColIndex + SUBCOLS; ++curCol)
                {
                    if (curRow == row && curRow == col)
                        continue;
                    char c = grid[curRow, curCol];
                    if (c != GAP)
                        solutions.Remove(c);
                }
            }

            return solutions;
        }
        static void FillSure(char[,] grid)
        {

            bool continueMainLoop;
            do
            {
                continueMainLoop = false;
                for (int curRow = 0; curRow < ROWS; ++curRow)
                {
                    for (int curCol = 0; curCol < COLS; ++curCol)
                    {
                        if (grid[curRow, curCol] == GAP)
                        {
                            var solutions = GetPossibleSolutions(
                                grid, curRow, curCol);
                            if (solutions.Count() == 1)
                            {
                                grid[curRow, curCol] = solutions.First();
                                continueMainLoop = true;
                            }
                        }
                    }
                }
            } while (continueMainLoop);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Unoptimized SolveSudoku");
            foreach (string example in args)
            {
                string example1 = "632005400004001300000000567000273005021406080000510000060030900048050002100029800";

                char[,] grid = LoadSudoku(example1);
                // PrintSudoku(grid);
                // Console.WriteLine("\n");

                // FillSure(grid);
                SolveSudoku(grid);

                PrintSudoku(grid);
                Console.WriteLine("\n\n\n");
            }
        }
    }
}
