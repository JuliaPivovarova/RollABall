using UnityEngine;

namespace Code.DataStructure_HW7
{
    public class SimbolsInString : MonoBehaviour
    {
        private readonly string[] _massStr = { "I", "World", "system" };

        private void Start()
        {
            Debug.Log("Length of strings" + _massStr[0].StringLength() + "; " + _massStr[1].StringLength() + "; " + _massStr[2].StringLength() + ";");
        }
    }
    
    
}
