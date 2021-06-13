using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Search.FuzzySearch.Basic
{
    internal sealed class BasicSearch : IFuzzySearch
    {
        public IEnumerable<SearchResult> Run(string searchTerm, HashSet<IndexItem> index, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = index.Where(x => x.Phrase.Contains(searchTerm))
                              .Select(x => new SearchResult(x.PhraseId, x.Phrase));
            return result;
        }
    }
}
