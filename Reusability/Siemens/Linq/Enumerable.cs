using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reusability.Siemens.Linq
{
    public static class Enumerable
    {
        //[System.Runtime.CompilerServices.ExtensionAttribute()]
        public static List<T> SelectQuery<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();
            foreach (T item in source)
            {
                if (predicate.Invoke(item))
                {
                    result.Add(item);
                }
            }

            return result;

        }
    }
}
