using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code
{
    public class FlagInterection : MonoBehaviour
    {
        public bool InterectedWithPl = false;
        public Action Intercted;

        private void Start()
        {
            Intercted = DidInterect;
        }

        private void DidInterect()
        {
            InterectedWithPl = true;
            Debug.Log("Flag - true");
        }
    }
}
