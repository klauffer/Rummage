using System;
using Microsoft.Extensions.Logging;

namespace Search.FuzzySearch
{
    internal static class FuzzySearchFactory<T>
    {
        public static IFuzzySearch<T> GetFuzzySearch(FuzzySearchType type, ILogger logger)
        {
            return type switch
            {
                FuzzySearchType.Levenshtein => new LevenshteinSearch<T>(logger),
                FuzzySearchType.DamerauLevenshtein => new DamerauLevenshteinSearch<T>(logger),
                _ => throw new ArgumentException($"FuzzySearchFactory does not know how to create {type}", type.GetType().Name),
            };
        }
    }
}
