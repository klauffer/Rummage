namespace Search
{
    public class SearchResult
    {
        public SearchResult(int phraseId, string matchingPhrase)
        {
            PhraseId = phraseId;
            MatchingPhrase = matchingPhrase;
        }

        public int PhraseId { get; }
        public string MatchingPhrase { get; }
    }
}