using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Search.FuzzySearch
{
    internal interface IFuzzySearch<T>
    {
        Task<IEnumerable<SearchResult<T>>> Run(string searchTerm, HashSet<IndexItem<T>> index, CancellationToken cancellationToken);
    }
}