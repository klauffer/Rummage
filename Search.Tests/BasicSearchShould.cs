using System;
using System.Linq;
using System.Threading;
using Search.FuzzySearch;
using Xunit;
using Xunit.Abstractions;

namespace Search.Tests
{
    public class BasicSearchShould : TestFixture
    {
        public BasicSearchShould(ITestOutputHelper outputHelper) : base(outputHelper, FuzzySearchType.Basic)
        {
        }

        [Fact]
        public async void FindExactMatch()
        {
            var searchResult = await _searchEngine.Search("Homer", Data);
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == "1");
            Assert.Equal("1", actual.PhraseId);
            Assert.Equal("Homer Simpson", actual.MatchingPhrase);
        }

        [Fact]
        public async void FindSubsetMatch()
        {
            var searchResult = await _searchEngine.Search("ome", Data);
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == "1");
            Assert.Equal("1", actual.PhraseId);
            Assert.Equal("Homer Simpson", actual.MatchingPhrase);
        }

        [Fact]
        public async void NotFindMatch()
        {
            var searchResult = await _searchEngine.Search("qwerty", Data);
            Assert.Empty(searchResult);
        }

        [Fact]
        public async void CancelSearch()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            tokenSource.Cancel();
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await _searchEngine.Search("qqq", Data, token));
        }
    }
}
