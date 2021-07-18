using System;

namespace Rummage.FuzzySearch
{
    internal static class FuzzySearchFactory<T>
    {
        public static IFuzzySearch<T> GetFuzzySearch(FuzzySearchType type)
        {
            return type switch
            {
                FuzzySearchType.Levenshtein => new LevenshteinSearch<T>(),
                FuzzySearchType.DamerauLevenshtein => new DamerauLevenshteinSearch<T>(),
                FuzzySearchType.Hamming => new HammingSearch<T>(),
                FuzzySearchType.Jaro => new JaroSearch<T>(),
                _ => throw new ArgumentException($"FuzzySearchFactory does not know how to create {type}", type.GetType().Name),
            };
        }
    }
}
