using System;
using System.Collections.Generic;
using System.Linq;

namespace Rummage.Infrastructure
{
    /// <summary>
    /// A ValueObject is a object that its uniqueness is determined by its parts(or values)
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        /// Equal Operator Implementation
        /// </summary>
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }
            return left is null || left.Equals(right);
        }

        /// <summary>
        /// Not Equal Operator Implementation
        /// </summary>
        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        /// <summary>
        /// Gets Equality Components to base quality operations off of
        /// </summary>
        protected abstract IEnumerable<object> GetEqualityComponents();

        /// <summary>
        /// Equals Implementation
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }


        /// <summary>
        /// equality implementation
        /// </summary>
        public static bool operator ==(ValueObject lhs, ValueObject rhs)
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
        public static bool operator !=(ValueObject lhs, ValueObject rhs) => !(lhs == rhs);

        /// <summary>
        /// HashCode Implementation
        /// </summary>
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
