using System.Collections.Generic;

namespace Search
{
    public interface IGetData
    {
        HashSet<IndexItem> GetIndexToSearch();
    }
}