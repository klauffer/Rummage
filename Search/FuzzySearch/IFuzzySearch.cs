using System.Collections.Generic;
using System.Threading;

namespace Search.FuzzySearch
{
    internal interface IFuzzySearch<T>
    {
        IEnumerable<SearchResult<T>> Run(string searchTerm, HashSet<IndexItem<T>> index, CancellationToken cancellationToken);
    }
}