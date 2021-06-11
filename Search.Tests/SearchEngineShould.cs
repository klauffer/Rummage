using System.Collections.Generic;
using Xunit;

namespace Search.Tests
{
    public class SearchEngineShould
    {
        [Fact]
        public void FindExactMatch()
        {
            var getData = new GetData();
            getData.Set.Add(new IndexItem("1", "Homer"));
            var searchEngine = new SearchEngine(getData);
            var searchResult = searchEngine.Search("Homer");

            Assert.Equal("1", searchResult.PhraseId);
            Assert.Equal("Homer", searchResult.MatchingPhrase);
        }

        private class GetData : IGetData
        {
            public HashSet<IndexItem> Set = new HashSet<IndexItem>();

            public HashSet<IndexItem> GetIndexToSearch() => Set;
        }
    }
}
