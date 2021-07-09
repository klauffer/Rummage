using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Logging;
using Moq;

namespace Rummage.BenchMarks
{
    //[JsonExporterAttribute.Brief]
    //[JsonExporterAttribute.Full]
    //[JsonExporterAttribute.BriefCompressed]
    //[JsonExporter("-custom", indentJson: true, excludeMeasurements: true)]
    [MarkdownExporterAttribute.GitHub]
    public class SearchBenchmarks
    {
        private ILogger Logger => Mock.Of<ILogger>();
        private readonly HashSet<IndexItem<int>> ExternalData = DictionaryData.GetData(@"Dictionary.txt");

        [Benchmark]
        public async Task<List<SearchResult<int>>> LevenshteinSearch()
        {
            var searchEngine = new Rummage.SearchEngine<int>(FuzzySearch.FuzzySearchType.Levenshtein, Logger); 
            var result = await searchEngine.Search("idempotent", ExternalData);
            return result.ToList();
        }

        [Benchmark]
        public async Task<List<SearchResult<int>>> DamerauLevenshteinSearch()
        {
            var searchEngine = new Rummage.SearchEngine<int>(FuzzySearch.FuzzySearchType.DamerauLevenshtein, Logger);
            var result = await searchEngine.Search("idempotent", ExternalData);
            return result.ToList();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SearchBenchmarks>();
        }
    }
}
