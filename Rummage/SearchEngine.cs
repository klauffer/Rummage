using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rummage.FuzzySearch;
using Rummage.Infrastructure;

namespace Rummage
{

    /// <summary>
    /// Given a set of parameters and settings will perform searches on the given data set to find the closest match to the given search term
    /// </summary>
    public sealed class SearchEngine<T>
    { 
        private readonly IFuzzySearch<T> _fuzzySearch;

        /// <summary>
        /// Setup a search engine with default behavior and a selection of algorithm 
        /// </summary>
        /// <param name="searchType">The algorithm that is to be performed when searching</param>
        public SearchEngine(FuzzySearchType searchType)
        {
            _fuzzySearch = FuzzySearchFactory<T>.GetFuzzySearch(searchType);
        }

        /// <summary>
        /// Searches the given set for the given SearchTerm returns a list of results
        /// </summary>
        /// <param name="searchTerm">The phrase that is being searched for</param>
        /// <param name="dataToSearch">The data set to search against</param>
        /// <param name="cancellationToken">Cancellation token that will abandon a search</param>
        /// <returns>An ordered collection of results starting with the strongest</returns>
        public async Task<IEnumerable<SearchResult<T>>> Search(string searchTerm, HashSet<IndexItem<T>> dataToSearch, CancellationToken cancellationToken = default)
        {
                searchTerm.ThrowOnNullOrEmpty("searchTerm");
                dataToSearch.ThrowOnNullOrEmpty("dataToSearch");
                var searchResults = await _fuzzySearch.Run(searchTerm, dataToSearch, cancellationToken);
                return searchResults;
        }
    }
}
