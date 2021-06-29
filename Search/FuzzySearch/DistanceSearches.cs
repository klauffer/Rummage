using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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
            var parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cancellationToken;
            var searchStrengths = new ConcurrentBag<KeyValuePair<int, SearchResult<T>>>();
            Parallel.ForEach(index, parallelOptions, indexItem =>
            {
                var distance = CalculateDistance(searchTerm, indexItem.Phrase);
                if (distance <= indexItem.Phrase.Length)
                {
                    var searchStrength = new KeyValuePair<int, SearchResult<T>>(distance, new SearchResult<T>(indexItem.PhraseId, indexItem.Phrase));
                    searchStrengths.Add(searchStrength);
                }
                parallelOptions.CancellationToken.ThrowIfCancellationRequested();
            });

            return Task.FromResult(searchStrengths.OrderBy(x => x.Key)
                                  .Select(x => x.Value));
        }

        protected abstract int CalculateDistance(string searchTerm, string indexedPhrase);
    }
}
