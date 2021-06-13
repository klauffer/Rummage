using System.Collections.Generic;
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

        public async Task<IEnumerable<SearchResult>> Search(string searchTerm)
        {
            var data = await _getSearchData.GetIndexToSearch();
            return _fuzzySearch.Run(searchTerm, data);
        }
    }
}
