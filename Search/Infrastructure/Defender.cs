using System;
using System.Collections.Generic;
using System.Linq;

namespace Rummage.Infrastructure
{
    internal static class Defender
    {
        public static void ThrowOnNullOrEmpty(this string argumentValue, string argumentName)
        {
            if (string.IsNullOrEmpty(argumentValue))
                throw new ArgumentNullException(argumentName + " can't be null");
        }

        public static void ThrowOnNullOrEmpty<T>(this IEnumerable<T> argumentValue, string argumentName)
        {
            if (argumentValue == null || !argumentValue.Any())
                throw new ArgumentNullException(argumentName + " can't be null");
        }
    }
}
