using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinder.Models.Models.V1
{
    /// <summary>
    /// Represents a word and its frequency of occurrence.
    /// </summary>
    public class WordResult
    {
        /// <summary>
        /// Gets or sets the word.
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// Gets or sets the frequency of the word in the matrix.
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordResult"/> class.
        /// </summary>
        /// <param name="word">The word found in the matrix.</param>
        /// <param name="frequency">The frequency of the word.</param>
        public WordResult(string word, int frequency)
        {
            Word = word;
            Frequency = frequency;
        }
    }
}
