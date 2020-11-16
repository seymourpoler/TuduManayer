using System.Collections.Generic;
using System.Linq;

namespace TuduManayer.Domain
{
    public static class ListExtensions
    {
        public static bool IsNotEmpty<T>(this List<T> list) where T : class
        {
            return list.Any();
        }
    }
}