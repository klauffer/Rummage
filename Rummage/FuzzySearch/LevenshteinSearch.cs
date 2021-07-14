using System;
using Microsoft.Extensions.Logging;

namespace Rummage.FuzzySearch
{
    internal sealed class LevenshteinSearch<T> : DistanceSearches<T>
    {
        public LevenshteinSearch(ILogger logger) : base(logger) { }

        protected override int CalculateDistance(string searchTerm, string indexedPhrase)
        {
            var searchTermLength = searchTerm.Length;
            var indexedPhraseLength = indexedPhrase.Length;
            var distance = new int[searchTermLength + 1, indexedPhraseLength + 1];

            // Verify arguments.
            if (string.IsNullOrEmpty(searchTerm))
            {
                return indexedPhraseLength;
            }

            if (string.IsNullOrEmpty(indexedPhrase))
            {
                return searchTermLength;
            }

            // Initialize arrays.
            for (int i = 0; i <= searchTermLength; distance[i, 0] = i++){}
            for (int j = 0; j <= indexedPhraseLength; distance[0, j] = j++){}

            // compare each letter of one word to each letter of the other 
            // word and determine that letters distance to every letter on the other word
            for (int i = 1; i <= searchTermLength; i++)
            {
                for (int j = 1; j <= indexedPhraseLength; j++)
                {
                    // are the two characters the same?
                    int cost = (indexedPhrase[j - 1] == searchTerm[i - 1]) ? 0 : 1;
                    distance[i, j] = Math.Min(
                                     Math.Min(distance[i - 1, j] + 1,
                                              distance[i, j - 1] + 1),
                                     distance[i - 1, j - 1] + cost);
                }
            }
            return distance[searchTermLength, indexedPhraseLength];
        }
    }
}
