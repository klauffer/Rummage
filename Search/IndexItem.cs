using System;

namespace Search
{
    public sealed class IndexItem : IEquatable<IndexItem>
    {
        public IndexItem(string phraseId, string phrase)
        {
            PhraseId = phraseId;
            Phrase = phrase;
        }

        public string PhraseId { get; }
        public string Phrase { get; set; }

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

        public override int GetHashCode()
        {
            return PhraseId.GetHashCode();
        }


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

        public static bool operator !=(IndexItem lhs, IndexItem rhs) => !(lhs == rhs);
    }
}
