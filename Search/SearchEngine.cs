using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Search.FuzzySearch;

namespace Search
{

    /// <summary>
    /// Given a set of parameters and settings will perform searches on the given data set to find the closest match to the given search term
    /// </summary>
    public sealed class SearchEngine
    { 
        private readonly IFuzzySearch _fuzzySearch;
        private readonly ILogger _logger;

        /// <summary>
        /// setup a search engine with default behavior and a selection of algorithm 
        /// </summary>
        /// <param name="searchType">the algorithm that is to be performed when searching</param>
        /// <param name="logger">a logger to provide feedback to an implementation</param>
        public SearchEngine(FuzzySearchType searchType, ILogger logger)
        {
            _fuzzySearch = FuzzySearchFactory.GetFuzzySearch(searchType, logger);
            _logger = logger;
        }

        /// <summary>
        /// Searches the given set for the given SearchTerm returns a list of results
        /// </summary>
        /// <param name="searchTerm">The phrase that is being searched for</param>
        /// <param name="dataToSearch">the data set to search against</param>
        /// <param name="cancellationToken">cancellation token that will abandon a search</param>
        /// <returns>an ordered collection of results starting with the strongest</returns>
        public Task<IEnumerable<SearchResult>> Search(string searchTerm, HashSet<IndexItem> dataToSearch, CancellationToken cancellationToken = default)
        {
            var searchResults = _fuzzySearch.Run(searchTerm, dataToSearch, cancellationToken);
            _logger.LogInformation("Search for {searchTerm} has retrieved {count} results", searchTerm, searchResults.Count());
            return Task.FromResult(searchResults);
        }
    }
}
