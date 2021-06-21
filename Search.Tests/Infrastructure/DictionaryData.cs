using System.Collections.Generic;
using System.IO;

namespace Search.Tests.Infrastructure
{
    public static class DictionaryData
    {
        public static HashSet<IndexItem> GetData(string filePath)
        {
            return new HashSet<IndexItem>(ReadFile(filePath));
        }

        private static IEnumerable<IndexItem> ReadFile(string file)
        {
            string line;
            var id = 1;
            using var reader = File.OpenText(file);
            while ((line = reader.ReadLine()) != null)
            {
                var newRecord = new IndexItem(id.ToString(), line);
                yield return newRecord;
                id++;
            }
        }
    }
}
