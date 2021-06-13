using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Search.FuzzySearch.Basic
{
    internal sealed class BasicSearch : IFuzzySearch
    {
        private readonly ILogger _logger;

        public BasicSearch(ILogger logger)
        {
            _logger = logger;
        }

        public IEnumerable<SearchResult> Run(string searchTerm, HashSet<IndexItem> index, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Basic algorithm for {searchTerm} is beginning", searchTerm);
            cancellationToken.ThrowIfCancellationRequested();
            var result = index.Where(x => x.Phrase.Contains(searchTerm))
                              .Select(x => new SearchResult(x.PhraseId, x.Phrase));
            return result;
        }
    }
}
