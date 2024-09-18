using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordFinder.Infrastructure.Processors.V1
{
    /// <summary>
    /// Processes the word stream by removing duplicates and preparing it for searching.
    /// </summary>
    public class WordsStreamProcessor
    {
        /// <summary>
        /// Processes the word stream, removing duplicates and returning a clean list of words.
        /// </summary>
        /// <param name="wordStream">The word stream to process.</param>
        /// <returns>A distinct list of words.</returns>
        public IEnumerable<string> ProcessWordStream(IEnumerable<string> wordStream)
        {
            return wordStream.Distinct().ToList();
        }
    }
}
