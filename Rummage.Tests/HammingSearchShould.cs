using System.Linq;
using System.Threading.Tasks;
using Rummage.FuzzySearch;
using Rummage.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Rummage.Tests
{
    public class HammingSearchShould : TestFixture
    {
        public HammingSearchShould(ITestOutputHelper outputHelper) : base(outputHelper, FuzzySearchType.Hamming)
        {
        }

        [Fact]
        public async Task FindExactMatch()
        {
            var searchResult = await _searchEngine.Search("Homer Simpson", LocalData);
            var expectedPhraseId = PhraseId<int>.From(1);
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == expectedPhraseId);
            Assert.Equal("Homer Simpson", actual.MatchingPhrase);
        }

        [Fact]
        public async Task FindSubsetMatch()
        {
            var searchResult = await _searchEngine.Search("omer", LocalData);
            var expectedPhraseId = PhraseId<int>.From(1);
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == expectedPhraseId);
            Assert.Equal("Homer Simpson", actual.MatchingPhrase);
        }

        [Fact]
        public async Task NotFindMatch()
        {
            var searchResult = await _searchEngine.Search("qwerty", LocalData);
            Assert.DoesNotContain(searchResult, x => x.MatchingPhrase == "qwerty");
        }
    }
}
