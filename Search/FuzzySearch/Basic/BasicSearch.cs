using System.Collections.Generic;
using System.Linq;

namespace Search.FuzzySearch.Basic
{
    internal sealed class BasicSearch : IFuzzySearch
    {
        public IEnumerable<SearchResult> Run(string searchTerm, HashSet<IndexItem> index)
        {
            var result = index.Single(x => x.Phrase == searchTerm);
            return new List<SearchResult>() { new SearchResult(result.PhraseId, result.Phrase) };
        }
    }
}
