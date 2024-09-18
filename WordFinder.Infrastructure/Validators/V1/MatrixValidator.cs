using System;
using System.Collections.Generic;
using WordFinder.Infrastructure.Interfaces.V1;

namespace WordFinder.Infrastructure
{
    /// <summary>
    /// Validates the character matrix used for word searching.
    /// </summary>
    public class MatrixValidator : IMatrixValidator
    {
        private readonly IEnumerable<string> _matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixValidator"/> class.
        /// </summary>
        /// <param name="matrix">The matrix to validate.</param>
        public MatrixValidator(IEnumerable<string> matrix)
        {
            _matrix = matrix;
        }

        /// <summary>
        /// Checks if the matrix is valid (all rows have equal length and matrix size is <= 64x64).
        /// </summary>
        /// <returns><c>true</c> if the matrix is valid; otherwise, <c>false</c>.</returns>
        public bool IsValidMatrix()
        {
            int matrixSize = 64;
            int rowLength = -1;

            // Count the number of rows
            int rowCount = 0;

            foreach (var row in _matrix)
            {
                // Check the row length consistency
                if (rowLength == -1)
                {
                    rowLength = row.Length;
                }
                else if (row.Length != rowLength)
                {
                    Console.WriteLine($"Row length mismatch at row {rowCount + 1}. Expected: {rowLength}, Found: {row.Length}");
                    return false;
                }

                rowCount++;

                // Check if row count exceeds the matrix size
                if (rowCount > matrixSize)
                {
                    Console.WriteLine($"Matrix exceeds the allowed number of rows (64). Found: {rowCount}");
                    return false;
                }
            }

            // Check if row length exceeds the allowed size
            if (rowLength > matrixSize)
            {
                Console.WriteLine($"Row length exceeds the allowed number of columns (64). Found: {rowLength}");
                return false;
            }

            return true;
        }
    }
}
