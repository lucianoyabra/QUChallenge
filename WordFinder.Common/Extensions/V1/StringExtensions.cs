using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinder.Common.Extensions.V1
{
    /// <summary>
    /// Provides extension methods for working with strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Reverses the characters in a string.
        /// </summary>
        /// <param name="input">The input string to reverse.</param>
        /// <returns>A new string with the characters reversed.</returns>
        public static string Reverse(this string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Determines whether the specified row contains a word.
        /// </summary>
        /// <param name="row">The row to search within.</param>
        /// <param name="word">The word to search for.</param>
        /// <returns><c>true</c> if the row contains the word; otherwise, <c>false</c>.</returns>
        public static bool ContainsWord(this string row, string word)
        {
            return row.Contains(word);
        }
    }
}
