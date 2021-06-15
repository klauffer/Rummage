using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Search.FuzzySearch;

namespace Search
{
    public static class DotNetDI
    {
        public static void AddSearch(this IServiceCollection service, FuzzySearchType fuzzySearchType)
        {
            service.AddTransient<ISearchEngine>(provider => 
                new SearchEngine(fuzzySearchType, provider.GetService<ILogger>()));
        }
    }
}
