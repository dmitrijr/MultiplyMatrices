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

            var matrix1 = ReadMatrix(col1Row2, row1);
            var matrix2 = ReadMatrix(col2, col1Row2);

            var matrix = Multiply(matrix1, matrix2, row1, col1Row2, col2);

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

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    matrix[col, row] = ReadDimension($"Enter {col + 1} column and {row + 1} row value: ");
                }
            }

            return matrix;
        }

        public static int[,] Multiply(int[,] matrix1, int[,] matrix2, int rows1, int cols1Rows2, int cols2)
        {
            var matrix = new int[cols2, rows1];

            for (int row1 = 0; row1 < rows1; row1++)
            {
                for (int col2 = 0; col2 < cols2; col2++)
                {
                    var mult = 0;
                    for (int col1Row2 = 0; col1Row2 < cols1Rows2; col1Row2++)
                    {
                        mult += matrix1[col1Row2, row1] * matrix2[col2, col1Row2];
                    }
                    matrix[col2, row1] = mult;
                }
            }

            return matrix;
        }
    }
}