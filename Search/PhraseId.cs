using System.Collections.Generic;
using Search.Infrastructure;

namespace Search
{
    public sealed class PhraseId<T> : ValueObject
    {
        private readonly T _id;

        private PhraseId(T id)
        {
            _id = id;
        }

        public static PhraseId<T> From(T id) => new PhraseId<T>(id);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _id;
        }
    }
}
