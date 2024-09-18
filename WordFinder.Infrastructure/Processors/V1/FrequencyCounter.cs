using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordFinder.Models.Models.V1;

namespace WordFinder.Infrastructure.Processors.V1
{
    /// <summary>
    /// Counts the frequency of words found in the matrix and returns the top 10 most frequent.
    /// </summary>
    public class FrequencyCounter
    {
        /// <summary>
        /// Counts the frequency of words and returns the top 10 most frequent words.
        /// </summary>
        /// <param name="words">The list of words to count.</param>
        /// <returns>A list of <see cref="WordResult"/> representing the top 10 words and their frequencies.</returns>
        public IEnumerable<WordResult> CountFrequencies(IEnumerable<string> words)
        {
            return words.GroupBy(w => w)
                        .Select(g => new WordResult(g.Key, g.Count()))
                        .OrderByDescending(wr => wr.Frequency)
                        .Take(10)
                        .ToList();
        }
    }
}
