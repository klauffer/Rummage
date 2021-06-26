using System.Collections.Generic;
using Search.Infrastructure;

namespace Search
{
    /// <summary>
    /// Phrase Id is the unique Identifier for the Searched Index
    /// </summary>
    public sealed class PhraseId<T> : ValueObject
    {
        private readonly T _id;

        private PhraseId(T id)
        {
            _id = id;
        }

        /// <summary>
        /// Smart Constructor for instantiating a PhraseId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PhraseId<T> From(T id) => new PhraseId<T>(id);

        ///<inheritdoc/>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _id;
        }
    }
}
