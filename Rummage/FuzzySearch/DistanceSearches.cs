using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rummage.FuzzySearch
{
    internal abstract class DistanceSearches<T> : IFuzzySearch<T>
    {
        public Task<IEnumerable<SearchResult<T>>> Run(string searchTerm, HashSet<IndexItem<T>> index, CancellationToken cancellationToken)
        {
            var parallelOptions = new ParallelOptions
            {
                CancellationToken = cancellationToken
            };
            var searchStrengths = new ConcurrentBag<KeyValuePair<double, SearchResult<T>>>();
            Parallel.ForEach(index, parallelOptions, indexItem =>
            {
                var distance = CalculateDistance(searchTerm, indexItem.Phrase);
                if (distance <= indexItem.Phrase.Length)
                {
                    var searchStrength = new KeyValuePair<double, SearchResult<T>>(distance, new SearchResult<T>(indexItem.PhraseId, indexItem.Phrase));
                    searchStrengths.Add(searchStrength);
                }
                parallelOptions.CancellationToken.ThrowIfCancellationRequested();
            });

            // Order by distance(
            return Task.FromResult(searchStrengths.OrderBy(x => x.Key)
                                  .Select(x => x.Value));
        }

        protected abstract double CalculateDistance(string searchTerm, string indexedPhrase);
    }
}
