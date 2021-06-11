using System.Collections.Generic;
using System.Linq;
using Search.FuzzySearch;
using Xunit;

namespace Search.Tests
{
    public class SearchEngineShould
    {
        [Fact]
        public void FindExactMatch()
        {
            var searchEngine = SetUp();
            var searchResult = searchEngine.Search("Homer");
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == "1");
            Assert.Equal("1", actual.PhraseId);
            Assert.Equal("Homer", actual.MatchingPhrase);
        }

        private SearchEngine SetUp()
        {
            var getData = new GetData();
            getData.Set.Add(new IndexItem("1", "Homer"));
            return new SearchEngine(getData, FuzzySearchType.Basic);
        }

        private class GetData : IGetData
        {
            public HashSet<IndexItem> Set = new HashSet<IndexItem>();

            public HashSet<IndexItem> GetIndexToSearch() => Set;
        }
    }
}
