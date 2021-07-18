using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rummage.FuzzySearch;
using Rummage.Tests.TestHelpers;
using Xunit;

namespace Rummage.Tests
{
    public sealed class JaroSearchShould : TestFixture
    {
        public JaroSearchShould() : base(FuzzySearchType.Jaro)
        {
        }


        /// <summary>
        /// https://en.wikipedia.org/wiki/Jaro%E2%80%93Winkler_distance
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task FindExampleMatch()
        {
            var exampleData = new HashSet<IndexItem<int>>()
            { 
                IndexItem<int>.From(PhraseId<int>.From(1), "TRACE"),
            };
            var searchResult = await _searchEngine.Search("CRATE", exampleData);
            var expectedPhraseId = PhraseId<int>.From(1);
            var actual = searchResult.FirstOrDefault(x => x.PhraseId == expectedPhraseId);
            Assert.Equal("TRACE", actual.MatchingPhrase);
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
    }
}
