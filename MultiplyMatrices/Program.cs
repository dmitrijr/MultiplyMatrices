using System;

namespace MultiplyMatrices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var row1 = ReadDimension("Enter first matrix row count: ");
            var col1Row2 = ReadDimension("Enter first matrix column and second matrix row count: ");
            var col2 = ReadDimension("Enter second matrix col count: ");

            Console.WriteLine("Enter first matrix values: ");
            var matrix1 = ReadMatrix(col1Row2, row1);
            Console.WriteLine("Enter second matrix values: ");
            var matrix2 = ReadMatrix(col2, col1Row2);

            var matrix = Multiply(matrix1, matrix2);

            if (matrix == null)
            {
                Console.WriteLine("Could not multiply matrices");
                return;
            }

            Console.WriteLine("Result: ");
            PrintMatrix(matrix);

            Console.WriteLine("Hello World!");
        }

        public static int ReadDimension(string title)
        {
            Console.Write(title);
            return int.Parse(Console.ReadLine());
        }

        public static int[,] ReadMatrix(int cols, int rows)
        {
            var matrix = new int[cols, rows];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[col, row] = ReadDimension($"Enter {col + 1} column and {row + 1} row value: ");
                }
            }

            return matrix;
        }

        public static int[,] Multiply(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1 == null || matrix2 == null)
                return null;

            var rows1 = matrix1.GetLength(1);
            var cols1Rows2 = matrix1.GetLength(0);
            var cols2 = matrix2.GetLength(0);

            if (cols1Rows2 != matrix2.GetLength(1))
                return null;

            var matrix = new int[cols2, rows1];

            for (int row1 = 0; row1 < rows1; row1++)
            {
                for (int col2 = 0; col2 < cols2; col2++)
                {
                    var result = 0;
                    for (int col1Row2 = 0; col1Row2 < cols1Rows2; col1Row2++)
                    {
                        var mult = matrix1[col1Row2, row1] * matrix2[col2, col1Row2];
                        result += mult;
                    }
                    matrix[col2, row1] = result;
                }
            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[col, row]} ");
                }

                Console.WriteLine();
            }
        }
    }
}