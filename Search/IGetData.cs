using System.Collections.Generic;
using System.Threading.Tasks;

namespace Search
{
    public interface IGetData
    {
        Task<HashSet<IndexItem>> GetIndexToSearch();
    }
}