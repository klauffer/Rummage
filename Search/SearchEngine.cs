using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Search.FuzzySearch;

namespace Search
{
    public sealed class SearchEngine
    { 
        private readonly IFuzzySearch _fuzzySearch;
        private readonly ILogger _logger;

        public SearchEngine(FuzzySearchType searchType, ILogger logger)
        {
            _fuzzySearch = FuzzySearchFactory.GetFuzzySearch(searchType, logger);
            _logger = logger;
        }

        public Task<IEnumerable<SearchResult>> Search(string searchTerm, HashSet<IndexItem> dataToSearch, CancellationToken cancellationToken = default)
        {
            var searchResults = _fuzzySearch.Run(searchTerm, dataToSearch, cancellationToken);
            _logger.LogInformation("Search for {searchTerm} has retrieved {count} results", searchTerm, searchResults.Count());
            return Task.FromResult(searchResults);
        }
    }
}
