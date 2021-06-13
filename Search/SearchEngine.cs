using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Search.FuzzySearch;

namespace Search
{
    public sealed class SearchEngine
    {
        private readonly IGetData _getSearchData;
        private readonly IFuzzySearch _fuzzySearch;

        public SearchEngine(IGetData getSearchData, FuzzySearchType searchType)
        {
            _getSearchData = getSearchData;
            _fuzzySearch = FuzzySearchFactory.GetFuzzySearch(searchType);
        }

        public async Task<IEnumerable<SearchResult>> Search(string searchTerm, CancellationToken cancellationToken = default(CancellationToken))
        {
            var data = await _getSearchData.GetIndexToSearch(cancellationToken);
            return _fuzzySearch.Run(searchTerm, data, cancellationToken);
        }
    }
}
