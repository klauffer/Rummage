using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Rummage.FuzzySearch;

namespace Rummage.BenchMarks
{
    [MarkdownExporterAttribute.GitHub]
    public class SearchBenchmarks
    {
        private  readonly HashSet<IndexItem<int>> ExternalData = DictionaryData.GetData(@"Dictionary.txt");

        [Benchmark]
        public async Task<List<SearchResult<int>>> HammingSearch()
        {
            var searchEngine = new SearchEngine<int>(FuzzySearchType.Hamming);
            var result = await searchEngine.Search("idempotent", ExternalData);
            return result.ToList();
        }

        [Benchmark]
        public async Task<List<SearchResult<int>>> LevenshteinSearch()
        {
            var searchEngine = new SearchEngine<int>(FuzzySearchType.Levenshtein); 
            var result = await searchEngine.Search("idempotent", ExternalData);
            return result.ToList();
        }

        [Benchmark]
        public async Task<List<SearchResult<int>>> DamerauLevenshteinSearch()
        {
            var searchEngine = new SearchEngine<int>(FuzzySearchType.DamerauLevenshtein);
            var result = await searchEngine.Search("idempotent", ExternalData);
            return result.ToList();
        }

        [Benchmark]
        public async Task<List<SearchResult<int>>> JaroSearch()
        {
            var searchEngine = new SearchEngine<int>(FuzzySearchType.Jaro);
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
