using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Search.FuzzySearch
{
    internal abstract class DistanceSearches<T>
    {
        private ILogger Logger { get; }

        public DistanceSearches(ILogger logger)
        {
            Logger = logger;
        }

        public Task<IEnumerable<SearchResult<T>>> Run(string searchTerm, HashSet<IndexItem<T>> index, CancellationToken cancellationToken)
        {
            Logger.LogDebug("Distance algorithm for {searchTerm} is beginning", searchTerm);
            var searchStrengths = new List<KeyValuePair<int, SearchResult<T>>>();
            foreach (var indexItem in index)
            {
                var distance = CalculateDistance(searchTerm, indexItem.Phrase);
                if (distance <= indexItem.Phrase.Length)
                {
                    var searchStrength = new KeyValuePair<int, SearchResult<T>>(distance, new SearchResult<T>(indexItem.PhraseId, indexItem.Phrase));
                    searchStrengths.Add(searchStrength);
                }
                cancellationToken.ThrowIfCancellationRequested();
            }
            return Task.FromResult(searchStrengths.OrderBy(x => x.Key)
                                  .Select(x => x.Value));
        }

        protected abstract int CalculateDistance(string searchTerm, string indexedPhrase);
    }
}
