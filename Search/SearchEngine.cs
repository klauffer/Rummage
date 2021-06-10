using System.Linq;

namespace Search
{
    public class SearchEngine
    {
        private readonly IGetData _getSearchData;

        public SearchEngine(IGetData getSearchData)
        {
            _getSearchData = getSearchData;
        }

        public SearchResult Search(string searchTerm)
        {
            var data = _getSearchData.GetIndexToSearch();
            var result = data.Single(x => x.Value == searchTerm);
            return new SearchResult(result.Key, result.Value);
        }
    }
}
