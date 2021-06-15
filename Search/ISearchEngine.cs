using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Search
{
    public interface ISearchEngine
    {
        Task<IEnumerable<SearchResult>> Search(string searchTerm, CancellationToken cancellationToken = default);
    }
}