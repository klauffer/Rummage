using System;

namespace Search
{
    /// <summary>
    /// Represents a single record that is being searched for
    /// </summary>
    public sealed class IndexItem : IEquatable<IndexItem>
    {
        /// <summary>
        /// Instantiates an IdexItem with the required fields to make this object immutable
        /// </summary>
        /// <param name="phraseId">a uniquely identifying value</param>
        /// <param name="phrase">the string that is being searched</param>
        public IndexItem(string phraseId, string phrase)
        {
            PhraseId = phraseId;
            Phrase = phrase;
        }

        /// <summary>
        /// a uniquely identifying value
        /// </summary>
        public string PhraseId { get; }

        /// <summary>
        /// the string that is being searched
        /// </summary>
        public string Phrase { get; set; }

        /// <summary>
        /// equality implementation for IndexItem
        /// </summary>
        /// <param name="other">the other Index Item that is being compared against</param>
        /// <returns>True or false based on match</returns>
        public bool Equals(IndexItem other)
        {
            if (other == null)
            {
                return false;
            }

            if (PhraseId == other.PhraseId)
            { 
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// equality implementation for a Object
        /// </summary>
        /// <param name="obj">the other object that is being compared against</param>
        /// <returns>True or false based on match</returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            IndexItem indexItem = obj as IndexItem;
            if (indexItem == null)
                return false;
            else
                return Equals(indexItem);
        }

        /// <summary>
        /// gets the HashCode for this object
        /// </summary>
        public override int GetHashCode()
        {
            return PhraseId.GetHashCode();
        }

        /// <summary>
        /// equality implementation
        /// </summary>
        public static bool operator ==(IndexItem lhs, IndexItem rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// inequality implementation
        /// </summary>
        public static bool operator !=(IndexItem lhs, IndexItem rhs) => !(lhs == rhs);
    }
}
