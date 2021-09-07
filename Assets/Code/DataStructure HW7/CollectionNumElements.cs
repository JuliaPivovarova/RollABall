using System.Collections.Generic;
using UnityEngine;

namespace Code.DataStructure_HW7
{
    public class CollectionNumElements : MonoBehaviour
    {
        private List<int> _listInt = new List<int> {0, 2, 3, 3, 3, 5, 5, 8, 8 };
        private List<string> _listT = new List<string> { "pot", "cat", "Cat", "Doggy", "cat"};

        private void Start()
        {
            var sumInt = _listInt.SumEachElements();
            var sumStr = _listT.SumEachElements();

            Debug.Log("Sum of each element in list - ");
            foreach (var pair in sumInt)
            {
                Debug.Log(pair.Key + " - " + pair.Value);
            }

            Debug.Log("Sum of each element in list - ");
            foreach (var pair in sumStr)
            {
                Debug.Log(pair.Key + " - " + pair.Value);
            }
        }
    }
}
