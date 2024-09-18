using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordFinder.Infrastructure.Interfaces.V1;

namespace WordFinder.Infrastructure.Processors.V1
{
    /// <summary>
    /// Implementation of IWordFinder to search for words in a character matrix.
    /// </summary>
    public class WordsFinder : IWordsFinder
    {
        private readonly IEnumerable<string> _matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordFinder"/> class.
        /// </summary>
        /// <param name="matrix">The matrix of characters where words will be searched.</param>
        public WordsFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
        }

        /// <summary>
        /// Searches for words from the provided word stream in the character matrix.
        /// </summary>
        /// <param name="wordstream">An IEnumerable of words to search for.</param>
        /// <returns>A collection of found words, with at most the top 10 most repeated words if applicable.</returns>
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var foundWords = new HashSet<string>();

            foreach (var word in wordstream.Distinct())
            {
                if (ContainsWord(word))
                {
                    foundWords.Add(word);
                }
            }

            // Return the top 10 most repeated words (in this case, we are returning all found words as a sample)
            return foundWords.Take(10);
        }

        private bool ContainsWord(string word)
        {
            var matrixList = _matrix.ToList();
            int rows = matrixList.Count;
            int cols = matrixList.First().Length;

            // Check horizontal and vertical
            for (int r = 0; r < rows; r++)
            {
                if (matrixList[r].Contains(word)) return true;
            }

            for (int c = 0; c < cols; c++)
            {
                string column = new string(Enumerable.Range(0, rows).Select(row => matrixList[row][c]).ToArray());
                if (column.Contains(word)) return true;
            }

            return false;
        }
    }
}
