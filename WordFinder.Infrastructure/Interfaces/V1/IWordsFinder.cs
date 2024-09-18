using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinder.Infrastructure.Interfaces.V1
{
    /// <summary>
    /// Interface for finding words in a character matrix.
    /// </summary>
    public interface IWordsFinder
    {
        /// <summary>
        /// Searches for words from the provided word stream in the character matrix.
        /// </summary>
        /// <param name="wordstream">An IEnumerable of words to search for.</param>
        /// <returns>A collection of found words, with at most the top 10 most repeated words if applicable.</returns>
        IEnumerable<string> Find(IEnumerable<string> wordstream);
    }
}
