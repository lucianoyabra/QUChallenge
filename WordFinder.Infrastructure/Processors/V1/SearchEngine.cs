using System.Collections.Generic;
using global::WordFinder.Common.Extensions.V1;

namespace WordFinder.Infrastructure.Processors.V1
{
    namespace WordFinder.Infrastructure
    {
        /// <summary>
        /// Provides functionality for searching words horizontally and vertically in a matrix.
        /// </summary>
        public class SearchEngine
        {
            private readonly IEnumerable<string> _matrix;

            /// <summary>
            /// Initializes a new instance of the <see cref="SearchEngine"/> class.
            /// </summary>
            /// <param name="matrix">The matrix to search through.</param>
            public SearchEngine(IEnumerable<string> matrix)
            {
                _matrix = matrix;
            }

            /// <summary>
            /// Searches for words in the matrix.
            /// </summary>
            /// <param name="wordStream">The word stream to search for in the matrix.</param>
            /// <returns>A set of words found in the matrix.</returns>
            public IEnumerable<string> FindWords(IEnumerable<string> wordStream)
            {
                var foundWords = new HashSet<string>();

                // Search horizontally and vertically
                foreach (var word in wordStream)
                {
                    if (SearchHorizontally(word) || SearchVertically(word))
                    {
                        foundWords.Add(word);
                    }
                }

                return foundWords;
            }

            /// <summary>
            /// Searches for a word in each row (horizontally).
            /// </summary>
            /// <param name="word">The word to search for.</param>
            /// <returns><c>true</c> if the word is found horizontally; otherwise, <c>false</c>.</returns>
            private bool SearchHorizontally(string word)
            {
                foreach (var row in _matrix)
                {
                    if (row.ContainsWord(word))
                    {
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// Searches for a word in each column (vertically).
            /// </summary>
            /// <param name="word">The word to search for.</param>
            /// <returns><c>true</c> if the word is found vertically; otherwise, <c>false</c>.</returns>
            private bool SearchVertically(string word)
            {
                var rowList = new List<string>(_matrix);
                int columnCount = rowList[0].Length;

                for (int col = 0; col < columnCount; col++)
                {
                    string column = string.Empty;

                    for (int row = 0; row < rowList.Count; row++)
                    {
                        column += rowList[row][col];
                    }

                    if (column.ContainsWord(word))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }

}
