﻿using System.Collections.Generic;

namespace TuduManayer.Domain.Test.Todo
{
    public static class IReadOnlyListExtensions
    {
        public static T Second<T>(this IReadOnlyList<T> list) where T : class
        {
            return list[1];
        }
    }
}