using System;
using System.Linq;
using System.Threading;
using Search.FuzzySearch;
using Xunit;
using Xunit.Abstractions;

namespace Search.Tests
{
    public class DamerauLevenshteinSearchShould : SetupFixture
    {
        private readonly SearchEngine _searchEngine;

        public DamerauLevenshteinSearchShould(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            _searchEngine = SetUp(FuzzySearchType.DamerauLevenshtein);
        }

        [Fact]
        public async void FindExactMatch()
        {
            var searchResult = await _searchEngine.Search("Homer Simpson", Data);
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == "1");
            Assert.Equal("1", actual.PhraseId);
            Assert.Equal("Homer Simpson", actual.MatchingPhrase);
        }

        [Fact]
        public async void FindSubsetMatch()
        {
            var searchResult = await _searchEngine.Search("omer", Data);
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == "1");
            Assert.Equal("1", actual.PhraseId);
            Assert.Equal("Homer Simpson", actual.MatchingPhrase);
        }

        [Fact]
        public async void NotFindMatch()
        {
            var searchResult = await _searchEngine.Search("qwerty", Data);
            Assert.DoesNotContain(searchResult, x => x.MatchingPhrase == "qwerty");
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
