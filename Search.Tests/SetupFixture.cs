using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Search.FuzzySearch;
using Xunit.Abstractions;

namespace Search.Tests
{
    public abstract class SetupFixture
    {
        private ITestOutputHelper OutputHelper { get; }
        public SetupFixture(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
        }

        protected HashSet<IndexItem> Data = new HashSet<IndexItem>()
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

        protected SearchEngine SetUp(FuzzySearchType fuzzySearchType)
        {
            var logger = GetLogger();
            return new SearchEngine(fuzzySearchType, logger);
        }

        protected ILogger GetLogger() => TestLogger.CreateLogger<SearchEngine>(OutputHelper);
    }
}
