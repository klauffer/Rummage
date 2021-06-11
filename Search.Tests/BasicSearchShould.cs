using System.Collections.Generic;
using System.Linq;
using Search.FuzzySearch;
using Xunit;

namespace Search.Tests
{
    public class BasicSearchShould
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

        [Fact]
        public void FindSubsetMatch()
        {
            var searchEngine = SetUp();
            var searchResult = searchEngine.Search("ome");
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == "1");
            Assert.Equal("1", actual.PhraseId);
            Assert.Equal("Homer", actual.MatchingPhrase);
        }

        [Fact]
        public void NotFindMatch()
        {
            var searchEngine = SetUp();
            var searchResult = searchEngine.Search("qwerty");
            Assert.Empty(searchResult);
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
