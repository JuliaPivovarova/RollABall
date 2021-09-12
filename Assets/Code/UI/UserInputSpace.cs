using System;
using Code.Interfaces_and_Markers;
using UnityEngine;

namespace Code.UI
{
    public sealed class UserInputSpace : IUserKeyPress
    {
        public event Action<bool> UserKey = delegate(bool b) {  };
        public void GetKey()
        {
            UserKey?.Invoke(Input.GetKeyDown(KeyCode.Return));
        }
    }
}