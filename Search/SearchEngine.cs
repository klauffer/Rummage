using System.Linq;

namespace Search
{
    public sealed class SearchEngine
    {
        private readonly IGetData _getSearchData;

        public SearchEngine(IGetData getSearchData)
        {
            _getSearchData = getSearchData;
        }

        public SearchResult Search(string searchTerm)
        {
            var data = _getSearchData.GetIndexToSearch();
            var result = data.Single(x => x.Phrase == searchTerm);
            return new SearchResult(result.PhraseId, result.Phrase);
        }
    }
}
