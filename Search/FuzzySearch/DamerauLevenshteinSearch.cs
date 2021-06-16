using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Search.FuzzySearch
{
    internal sealed class DamerauLevenshteinSearch : IFuzzySearch
    {
        private readonly ILogger _logger;

        public DamerauLevenshteinSearch(ILogger logger)
        {
            _logger = logger;
        }

        public IEnumerable<SearchResult> Run(string searchTerm, HashSet<IndexItem> index, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Levenshtein algorithm for {searchTerm} is beginning", searchTerm);
            var searchStrengths = new List<KeyValuePair<int, SearchResult>>();
            foreach (var indexItem in index)
            {
                var distance = CalculateDistance(searchTerm, indexItem.Phrase);
                if (distance <= indexItem.Phrase.Length)
                {
                    var searchStrength = new KeyValuePair<int, SearchResult>(distance, new SearchResult(indexItem.PhraseId, indexItem.Phrase));
                    searchStrengths.Add(searchStrength);
                }
                cancellationToken.ThrowIfCancellationRequested();
            }
            return searchStrengths.OrderBy(x => x.Key).Select(x => x.Value);
        }

        private int CalculateDistance(string searchTerm, string indexedPhrase)
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
            for (int i = 0; i <= searchTermLength; distance[i, 0] = i++)
            {
            }

            for (int j = 0; j <= indexedPhraseLength; distance[0, j] = j++)
            {
            }

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
                    if (i > 1 
                        && j > 1
                        && searchTerm[i - 1] == indexedPhrase[j - 2]
                        && searchTerm[i - 2] == indexedPhrase[j - 1])
                    {
                        distance[i, j] = Math.Min(distance[i, j],
                        distance[i - 2, j - 2] + cost); // permutation
                    }
                }
            }
            return distance[searchTermLength, indexedPhraseLength];
        }
    }
}

