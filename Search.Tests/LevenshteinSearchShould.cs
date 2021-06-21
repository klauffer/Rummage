using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Search.FuzzySearch;
using Search.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Search.Tests
{
    public sealed class LevenshteinSearchShould : TestFixture
    {
        public LevenshteinSearchShould(ITestOutputHelper outputHelper) : base(outputHelper, FuzzySearchType.Levenshtein)
        {
        }

        [Fact]
        public async Task FindExactMatch()
        {
            var searchResult = await _searchEngine.Search("Homer Simpson", LocalData);
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == "1");
            Assert.Equal("1", actual.PhraseId);
            Assert.Equal("Homer Simpson", actual.MatchingPhrase);
        }

        [Fact]
        public async Task FindSubsetMatch()
        {
            var searchResult = await _searchEngine.Search("omer", LocalData);
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == "1");
            Assert.Equal("1", actual.PhraseId);
            Assert.Equal("Homer Simpson", actual.MatchingPhrase);
        }

        [Fact]
        public async Task FindMisspelledWord()
        {
            var searchResult = await _searchEngine.Search("Flenders", LocalData);
            var actual = searchResult.FirstOrDefault();
            Assert.Equal("Ned Flanders", actual.MatchingPhrase);
        }

        [Fact]
        public async Task NotFindMatch()
        {
            var searchResult = await _searchEngine.Search("qwerty", LocalData);
            Assert.DoesNotContain(searchResult, x => x.MatchingPhrase == "qwerty");
        }

        [RunnableInDebugOnly]
        public async Task FindMatchWithinTimeFrame()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var searchResult = await _searchEngine.Search("idempotent", ExternalData);
            stopWatch.Stop();
            var actual = searchResult.FirstOrDefault();
            Assert.Equal("idempotent", actual.MatchingPhrase);
            Assert.InRange(stopWatch.ElapsedMilliseconds, 0, 3000);
        }

    }
}
