using System.Collections.Generic;
using System.IO;

namespace Rummage.BenchMarks
{
    public static class DictionaryData
    {
        public static HashSet<IndexItem<int>> GetData(string filePath)
        {
            return new HashSet<IndexItem<int>>(ReadFile(filePath));
        }

        private static IEnumerable<IndexItem<int>> ReadFile(string file)
        {
            string line;
            var id = 1;
            using var reader = File.OpenText(file);
            while ((line = reader.ReadLine()) != null)
            {
                var newRecord = IndexItem<int>.From(PhraseId<int>.From(id), line);
                yield return newRecord;
                id++;
            }
        }
    }
}
