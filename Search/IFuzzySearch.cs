using System.Collections.Generic;

namespace Search
{
    public interface IFuzzySearch
    {
        IEnumerable<SearchResult> Run(string searchTerm);
    }
}