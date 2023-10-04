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

        private static T[,] Make2DArray<T>(T[] input, int height, int width)
        {
            T[,] output = new T[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    output[i, j] = input[i * width + j];
                }
            }
            return output;
        }

        static char[,] LoadSudoku(string problem)
        {
            return Make2DArray(problem.ToCharArray(), ROWS, COLS);
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

                    int n = grid[curRow, curCol] - '0';
                    if (n == 0)
                        Console.Write(" .");
                    else
                        Console.Write($" {n}");
                }

                Console.WriteLine('|');
            }

            Console.WriteLine(new string('-', COLS * 2 + 4));
        }

        static bool IsValid(char[,] grid, int row, int col, char value)
        {
            return false;
        }

        static bool SolveSudoku(char[,] grid)
        {
            return false;
        }

        static void FillSure(char[,] grid)
        {

        }

        static void Main(string[] args)
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