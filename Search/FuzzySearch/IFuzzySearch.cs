using System.Collections.Generic;
using System.Threading;

namespace Search.FuzzySearch
{
    public interface IFuzzySearch
    {
        IEnumerable<SearchResult> Run(string searchTerm, HashSet<IndexItem> index, CancellationToken cancellationToken);
    }
}