using System.Collections.Generic;
using System.Linq;

namespace Search.FuzzySearch.Basic
{
    internal sealed class BasicSearch : IFuzzySearch
    {
        public IEnumerable<SearchResult> Run(string searchTerm, HashSet<IndexItem> index)
        {
            var result = index.Where(x => x.Phrase.Contains(searchTerm))
                              .Select(x => new SearchResult(x.PhraseId, x.Phrase));
            return result;
        }
    }
}
