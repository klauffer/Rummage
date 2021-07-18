using System.Linq;

namespace Rummage.FuzzySearch
{
    internal sealed class HammingSearch<T> : DistanceSearches<T>
    {
        protected override double CalculateDistance(string searchTerm, string indexedPhrase)
        {

            if (searchTerm.Length > indexedPhrase.Length)
            {
                indexedPhrase = indexedPhrase.PadRight(searchTerm.Length - indexedPhrase.Length);
            }
            else if (searchTerm.Length < indexedPhrase.Length)
            {
                searchTerm = searchTerm.PadRight(indexedPhrase.Length - searchTerm.Length);
            }
            var searchTermArray = searchTerm.ToCharArray();
            var indexedPhraseArray = indexedPhrase.ToCharArray();
            int distance = searchTermArray
                .Zip(indexedPhraseArray, (searchTermCharacter, indexedPhraseCharacter) => new { searchTermCharacter, indexedPhraseCharacter })
                .Count(m => m.searchTermCharacter != m.indexedPhraseCharacter);

            return distance;
        }
    }
}
