namespace Rummage
{
    /// <summary>
    /// The a single result of a search
    /// </summary>
    public sealed class SearchResult<T>
    {
        /// <summary>
        /// forces instantiation of required fields to make immutable
        /// </summary>
        /// <param name="phraseId">a uniquely identifying value</param>
        /// <param name="matchingPhrase">the string that is being searched</param>
        public SearchResult(PhraseId<T> phraseId, string matchingPhrase)
        {
            PhraseId = phraseId;
            MatchingPhrase = matchingPhrase;
        }

        /// <summary>
        /// a uniquely identifying value
        /// </summary>
        public PhraseId<T> PhraseId { get; }

        /// <summary>
        /// the string that is being searched
        /// </summary>
        public string MatchingPhrase { get; }
    }
}