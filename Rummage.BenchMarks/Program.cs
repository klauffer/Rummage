using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Rummage.BenchMarks
{
    [MarkdownExporterAttribute.GitHub]
    public class SearchBenchmarks
    {
        private  readonly HashSet<IndexItem<int>> ExternalData = DictionaryData.GetData(@"Dictionary.txt");

        [Benchmark]
        public async Task<List<SearchResult<int>>> HammingSearch()
        {
            var searchEngine = new Rummage.SearchEngine<int>(FuzzySearch.FuzzySearchType.Hamming);
            var result = await searchEngine.Search("idempotent", ExternalData);
            return result.ToList();
        }

        [Benchmark]
        public async Task<List<SearchResult<int>>> LevenshteinSearch()
        {
            var searchEngine = new Rummage.SearchEngine<int>(FuzzySearch.FuzzySearchType.Levenshtein); 
            var result = await searchEngine.Search("idempotent", ExternalData);
            return result.ToList();
        }

        [Benchmark]
        public async Task<List<SearchResult<int>>> DamerauLevenshteinSearch()
        {
            var searchEngine = new Rummage.SearchEngine<int>(FuzzySearch.FuzzySearchType.DamerauLevenshtein);
            var result = await searchEngine.Search("idempotent", ExternalData);
            return result.ToList();
        }
    }

    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<SearchBenchmarks>();
        }
    }
}
