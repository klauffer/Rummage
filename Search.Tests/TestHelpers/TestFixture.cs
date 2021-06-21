using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Search.FuzzySearch;
using Xunit.Abstractions;

namespace Search.Tests.TestHelpers
{
    public abstract class TestFixture
    {
        private ITestOutputHelper OutputHelper { get; }
        protected readonly SearchEngine _searchEngine;
        public TestFixture(ITestOutputHelper outputHelper, FuzzySearchType fuzzySearchType)
        {
            OutputHelper = outputHelper;
            _searchEngine = SetUp(fuzzySearchType);
            ExternalData = DictionaryData.GetData(@"TestHelpers/Dictionary.txt");
        }

        protected HashSet<IndexItem> LocalData = new HashSet<IndexItem>()
        {
            new IndexItem("1", "Homer Simpson"),
            new IndexItem("2", "Marge Simpson"),
            new IndexItem("3", "Bart Simpson"),
            new IndexItem("4", "Lisa Simpson"),
            new IndexItem("5", "Maggie Simpson"),
            new IndexItem("6", "Abraham Jebediah Simpson"),
            new IndexItem("7", "Ned Flanders"),
            new IndexItem("8", "Moe Szyslak"),
            new IndexItem("9", "Milhouse Van Houten")
        };

        protected HashSet<IndexItem> ExternalData;

        protected SearchEngine SetUp(FuzzySearchType fuzzySearchType)
        {
            var logger = GetLogger();
            return new SearchEngine(fuzzySearchType, logger);
        }

        protected ILogger GetLogger() => TestLogger.CreateLogger<SearchEngine>(OutputHelper);
    }
}
