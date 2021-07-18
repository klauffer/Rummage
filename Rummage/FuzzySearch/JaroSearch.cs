using System;

namespace Rummage.FuzzySearch
{
    internal class JaroSearch<T> : DistanceSearches<T>
    {
        protected override double CalculateDistance(string searchTerm, string indexedPhrase)
        {
            // If the Strings are equal
            if (searchTerm == indexedPhrase)
                return 1.0;

            // Length of two Strings
            int len1 = searchTerm.Length;
            int len2 = indexedPhrase.Length;

            // Maximum distance upto which matching
            // is allowed
            int max_dist = (int)(Math.Floor((double)(
                            (Math.Max(len1, len2) / 2) - 1)));

            // Count of matches
            int match = 0;

            // Hash for matches
            int[] hash_searchTerm = new int[searchTerm.Length];
            int[] hash_indexedPhrase = new int[indexedPhrase.Length];

            // Traverse through the first String
            for (int i = 0; i < len1; i++)
            {

                // Check if there is any matches
                for (int j = Math.Max(0, i - max_dist);
                    j < Math.Min(len2, i + max_dist + 1); j++)

                    // If there is a match
                    if (searchTerm[i] == indexedPhrase[j] && hash_indexedPhrase[j] == 0)
                    {
                        hash_searchTerm[i] = 1;
                        hash_indexedPhrase[j] = 1;
                        match++;
                        break;
                    }
            }

            // If there is no match
            if (match == 0)
                return 0.0;

            // Number of transpositions
            double t = 0;

            int point = 0;

            // Count number of occurrences
            // where two characters match but
            // there is a third matched character
            // in between the indices
            for (int i = 0; i < len1; i++)
                if (hash_searchTerm[i] == 1)
                {

                    // Find the next matched character
                    // in second String
                    while (hash_indexedPhrase[point] == 0)
                        point++;

                    if (searchTerm[i] != indexedPhrase[point++])
                        t++;
                }

            t /= 2;
             
            // Return the Jaro Similarity
            var similarity = (((double)match) / ((double)len1)
                    + ((double)match) / ((double)len2)
                    + ((double)match - t) / ((double)match))
                / 3.0;

            return 1.0 - similarity;// return distance by inverting similarity
        }
    }
}
