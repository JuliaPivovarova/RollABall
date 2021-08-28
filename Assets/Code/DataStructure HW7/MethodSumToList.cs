using System.Collections.Generic;
using System.Linq;

namespace Code.DataStructure_HW7
{
    public static class MethodSumToList
    {
        public static Dictionary<T, int> SumEachElements<T>(this List<T> list)
        {
            Dictionary<T, int> elem = new Dictionary<T, int>();
            foreach (var value in list)
            {
                if (!elem.Any(e => e.Key.Equals(value)))
                    elem.Add(value, 1);
                else
                {
                    elem[value]++;
                }
            }
            return elem;
        }
    }
}