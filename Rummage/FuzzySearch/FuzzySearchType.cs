namespace Rummage.FuzzySearch
{
    /// <summary>
    /// types of supported algorithms 
    /// </summary>
    public enum FuzzySearchType
    {
        /// <summary>
        /// Measure the distance between words with single character edits(insertions, deletions or substitutions)
        /// </summary>
        Levenshtein,
        /// <summary>
        /// Measure the distance between words consisting of insertions, deletions or substitutions of a single character, or transposition of two adjacent characters
        /// </summary>
        DamerauLevenshtein,
        /// <summary>
        /// Measures the distance between words by forcing the searchterm and the terms its searching against to be the same length and then comparing equality of characters
        /// </summary>
        /// <remarks>This is an inaccurate search</remarks>
        Hamming,
        /// <summary>
        /// Measures the distance between words by finding the similar characters based on proximity and transpositions
        /// </summary>
        Jaro
    }
}
