using System.Collections.Generic;
using Rummage.Infrastructure;

namespace Rummage
{
    /// <summary>
    /// Represents a single record that is being searched for
    /// </summary>
    public sealed class IndexItem<T> : ValueObject
    {
        
        private IndexItem(PhraseId<T> phraseId, string phrase)
        {
            PhraseId = phraseId;
            Phrase = phrase;
        }

        /// <summary>
        /// Instantiates an IndexItem with the required fields to make this object immutable
        /// </summary>
        /// <param name="phraseId">a uniquely identifying value</param>
        /// <param name="phrase">the string that is being searched</param>
        public static IndexItem<T> From(PhraseId<T> phraseId, string phrase) => new IndexItem<T>(phraseId, phrase);

        /// <summary>
        /// a uniquely identifying value
        /// </summary>
        public PhraseId<T> PhraseId { get; }

        /// <summary>
        /// the string that is being searched
        /// </summary>
        public string Phrase { get; set; }

        ///<inheritdoc/>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PhraseId;
        }
    }
}
