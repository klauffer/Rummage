using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Search.FuzzySearch;

namespace Search
{
    public sealed class SearchEngine : ISearchEngine
    {
        private readonly IGetData _getSearchData;
        private readonly IFuzzySearch _fuzzySearch;
        private readonly ILogger _logger;

        public SearchEngine(IGetData getSearchData, FuzzySearchType searchType, ILogger logger)
        {
            _getSearchData = getSearchData;
            _fuzzySearch = FuzzySearchFactory.GetFuzzySearch(searchType, logger);
            _logger = logger;
        }

        public async Task<IEnumerable<SearchResult>> Search(string searchTerm, CancellationToken cancellationToken = default(CancellationToken))
        {
            _logger.LogInformation("Search for {searchTerm} is beginning", searchTerm);
            var data = await _getSearchData.GetIndexedDataToSearch(cancellationToken);
            _logger.LogInformation("Search for {searchTerm} has retrieved the indexed data", searchTerm);
            var searchResults = _fuzzySearch.Run(searchTerm, data, cancellationToken);
            _logger.LogInformation("Search for {searchTerm} has retrieved {count} results", searchTerm, searchResults.Count());
            return searchResults;
        }
    }
}
