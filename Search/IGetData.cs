using System.Collections.Generic;

namespace Search
{
    public interface IGetData
    {
        HashSet<KeyValuePair<string, string>> GetIndexToSearch();
    }
}