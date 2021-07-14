using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rummage.FuzzySearch
{
    internal interface IFuzzySearch<T>
    {
        Task<IEnumerable<SearchResult<T>>> Run(string searchTerm, HashSet<IndexItem<T>> index, CancellationToken cancellationToken);
    }
}