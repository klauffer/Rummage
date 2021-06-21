using System;
using System.Collections.Generic;
using System.Linq;

namespace Search.Infrastructure
{
    internal static class Defender
    {
        public static void ThrowOnNullOrEmpty(this string arguementValue, string arguementName)
        {
            if (string.IsNullOrEmpty(arguementValue))
                throw new ArgumentNullException(arguementName + " can't be null");
        }

        public static void ThrowOnNullOrEmpty<T>(this IEnumerable<T> arguementValue, string arguementName)
        {
            if (arguementValue == null || !arguementValue.Any())
                throw new ArgumentNullException(arguementName + " can't be null");
        }
    }
}
