namespace MultiplyMatrices
{
    public class MatrixMutiplier
    {
        public int[,] Multiply(int[,] matrix1, int[,] matrix2)
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
                    matrix[col2, row1] = GetValue(matrix1, matrix2, row1, col2, cols1Rows2);
                }
            }

            return matrix;
        }

        private int GetValue(int[,] matrix1, int[,] matrix2, int row1, int col2, int cols1Rows2)
        {
            var result = 0;
            for (int col1Row2 = 0; col1Row2 < cols1Rows2; col1Row2++)
            {
                var mult = matrix1[col1Row2, row1] * matrix2[col2, col1Row2];
                result += mult;
            }
            return result;
        }
    }
}