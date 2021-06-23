using System;
using Microsoft.Extensions.Logging;

namespace Search.FuzzySearch
{
    internal static class FuzzySearchFactory
    {
        public static IFuzzySearch GetFuzzySearch(FuzzySearchType type, ILogger logger)
        {
            return type switch
            {
                FuzzySearchType.Levenshtein => new LevenshteinSearch(logger),
                FuzzySearchType.DamerauLevenshtein => new DamerauLevenshteinSearch(logger),
                _ => throw new ArgumentException($"FuzzySearchFactory does not know how to create {type}", type.GetType().Name),
            };
        }
    }
}
