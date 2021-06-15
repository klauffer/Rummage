using System;
using System.Linq;
using System.Threading;
using Search.FuzzySearch;
using Xunit;
using Xunit.Abstractions;

namespace Search.Tests
{
    public class LevenshteinSearchShould : SetupFixture
    {
        public LevenshteinSearchShould(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async void FindExactMatch()
        {
            var searchEngine = SetUp(FuzzySearchType.Levenshtein);
            var searchResult = await searchEngine.Search("Homer Simpson");
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == "1");
            Assert.Equal("1", actual.PhraseId);
            Assert.Equal("Homer Simpson", actual.MatchingPhrase);
        }

        [Fact]
        public async void FindSubsetMatch()
        {
            var searchEngine = SetUp(FuzzySearchType.Levenshtein);
            var searchResult = await searchEngine.Search("omer");
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == "1");
            Assert.Equal("1", actual.PhraseId);
            Assert.Equal("Homer Simpson", actual.MatchingPhrase);
        }

        [Fact]
        public async void NotFindMatch()
        {
            var searchEngine = SetUp(FuzzySearchType.Levenshtein);
            var searchResult = await searchEngine.Search("qwerty");
            Assert.DoesNotContain(searchResult, x => x.MatchingPhrase == "qwerty");
        }

        [Fact]
        public async void CancelSearch()
        {
            var searchEngine = SetUp(FuzzySearchType.Levenshtein);
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            tokenSource.Cancel();
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await searchEngine.Search("qqq", token));
        }


        
    }
}
