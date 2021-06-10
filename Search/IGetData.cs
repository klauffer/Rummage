using System.Collections.Generic;

namespace Search
{
    public interface IGetData
    {
        HashSet<KeyValuePair<int, string>> GetIndexToSearch();
    }
}