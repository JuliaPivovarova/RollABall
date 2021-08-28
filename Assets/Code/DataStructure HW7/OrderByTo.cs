using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.DataStructure_HW7
{
    public class OrderByTo: MonoBehaviour
    {
        public static Dictionary<string, int> dict = new Dictionary<string, int>()
        {
            {"four", 4},
            {"two", 2},
            {"one", 1},
            {"three", 3},
        };
        

        private void Start()
        {
            
        
            var d = dict.OrderBy(delegate(KeyValuePair<string,int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
            
            var dic = dict.OrderBy(pa => pa.Value);

            foreach (var pair in dic)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }

            var di = from p in dict
                orderby p.Value descending
                select p;

            foreach (var pair in di)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
        }

        

    }
}
