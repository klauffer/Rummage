using System.Collections.Generic;

namespace Search.FuzzySearch
{
    public interface IFuzzySearch
    {
        IEnumerable<SearchResult> Run(string searchTerm, HashSet<IndexItem> index);
    }
}