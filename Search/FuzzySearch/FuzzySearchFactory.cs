using System;
using Microsoft.Extensions.Logging;

namespace Search.FuzzySearch
{
    internal static class FuzzySearchFactory
    {
        public static IFuzzySearch GetFuzzySearch(FuzzySearchType type, ILogger logger)
        {
            switch (type)
            {
                case FuzzySearchType.Basic:
                    return new BasicSearch(logger);
                case FuzzySearchType.Levenshtein:
                    return new LevenshteinSearch(logger);
                default:
                    throw new ArgumentException($"FuzzySearchFactory does not know how to create {type}", type.GetType().Name);
            }
        }
    }
}
