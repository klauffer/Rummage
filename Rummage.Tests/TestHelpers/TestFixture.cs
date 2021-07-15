using System.Collections.Generic;
using Rummage.FuzzySearch;
using Xunit.Abstractions;

namespace Rummage.Tests.TestHelpers
{
    public abstract class TestFixture
    {
        protected readonly SearchEngine<int> _searchEngine;
        public TestFixture(FuzzySearchType fuzzySearchType)
        {
            _searchEngine = SetUp(fuzzySearchType);
        }

        protected HashSet<IndexItem<int>> LocalData = new HashSet<IndexItem<int>>()
        {
            IndexItem<int>.From(PhraseId<int>.From(1), "Homer Simpson"),
            IndexItem<int>.From(PhraseId<int>.From(2), "Marge Simpson"),
            IndexItem<int>.From(PhraseId<int>.From(3), "Bart Simpson"),
            IndexItem<int>.From(PhraseId<int>.From(4), "Lisa Simpson"),
            IndexItem<int>.From(PhraseId<int>.From(5), "Maggie Simpson"),
            IndexItem<int>.From(PhraseId<int>.From(6), "Abraham Jebediah Simpson"),
            IndexItem<int>.From(PhraseId<int>.From(7), "Ned Flanders"),
            IndexItem<int>.From(PhraseId<int>.From(8), "Moe Szyslak"),
            IndexItem<int>.From(PhraseId<int>.From(9), "Milhouse Van Houten")
        };

        protected static SearchEngine<int> SetUp(FuzzySearchType fuzzySearchType)
        {
            return new SearchEngine<int>(fuzzySearchType);
        }
    }
}
