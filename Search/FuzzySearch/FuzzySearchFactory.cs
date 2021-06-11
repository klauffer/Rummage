using System;
using Search.FuzzySearch.Basic;

namespace Search.FuzzySearch
{
    internal static class FuzzySearchFactory
    {
        public static IFuzzySearch GetFuzzySearch(FuzzySearchType type)
        {
            switch (type)
            {
                case FuzzySearchType.Basic:
                    return new BasicSearch();
                default:
                    throw new ArgumentException($"FuzzySearchFactory does not know how to create {type}", type.GetType().Name);
            }
        }
    }
}
