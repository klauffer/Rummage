namespace Search
{
    public sealed class SearchResult
    {
        public SearchResult(string phraseId, string matchingPhrase)
        {
            PhraseId = phraseId;
            MatchingPhrase = matchingPhrase;
        }

        public string PhraseId { get; }
        public string MatchingPhrase { get; }
    }
}