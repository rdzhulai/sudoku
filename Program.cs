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
        public char[,] LoadSudoku(string problem)
        {
            char[,] grid = new char[ROWS, COLS];

            for (int curRow = 0; curRow < ROWS; ++curRow)
            {
                for (int curCol = 0; curCol < COLS; ++curCol)
                {
                    grid[curRow, curCol] = problem[curRow * ROWS + curCol];
                    if (grid[curRow, curCol] == '0')
                        grid[curRow, curCol] = '.';
                }
            }

            return grid;
        }

        public void PrintSudoku(char[,] grid)
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

                    Console.Write(' ' + grid[curRow, curCol]);
                }

                Console.WriteLine('|');
            }

            Console.WriteLine(new string('-', COLS * 2 + 4));
        }

        public bool IsValid(char[,] grid, int row, int col, char value)
        {
            if (grid[row, col] != 0)
                return false;

            for (int curRow = 0; curRow < row; ++curRow)
            {
                if (grid[curRow, col] == value)
                    return false;
            }

            for (int curCol = 0; curCol < col; ++col)
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

        public bool SolveSudoku(char[,] grid)
        {


            return false;
        }

        public void FillSure(char[,] grid)
        {

        }

        public void Main(string[] args)
        {
            string example1 = "632005400004001300000000567000273005021406080000510000060030900048050002100029800";

            char[,] grid = LoadSudoku(example1);
            PrintSudoku(grid);

            Console.WriteLine("\n\n\n");

            //SolveSudoku(grid);
            PrintSudoku(grid);
        }
    }
}