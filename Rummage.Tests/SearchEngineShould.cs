using System;
using System.Threading;
using System.Threading.Tasks;
using Rummage.FuzzySearch;
using Rummage.Tests.TestHelpers;
using Xunit;

namespace Rummage.Tests
{
    public class SearchEngineShould : TestFixture
    {
        public SearchEngineShould() : base(FuzzySearchType.Levenshtein)
        {
        }

        [Fact]
        public async Task CancelSearch()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            tokenSource.Cancel();
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await _searchEngine.Search("qqq", LocalData, token));
        }

        [Fact]
        public async Task NotAcceptNullSearchTerm()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            tokenSource.Cancel();
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _searchEngine.Search(null, LocalData, token));
        }

        [Fact]
        public async Task NotAcceptNullData()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            tokenSource.Cancel();
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _searchEngine.Search("qqq", null, token));
        }
    }
}
