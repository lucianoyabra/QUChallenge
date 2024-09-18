using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinder.Infrastructure.Interfaces.V1
{
    /// <summary>
    /// Interface for matrix validation.
    /// </summary>
    public interface IMatrixValidator
    {
        /// <summary>
        /// Checks if the matrix is valid (all rows have equal length and matrix size is <= 64x64).
        /// </summary>
        /// <returns><c>true</c> if the matrix is valid; otherwise, <c>false</c>.</returns>
        bool IsValidMatrix();
    }
}
