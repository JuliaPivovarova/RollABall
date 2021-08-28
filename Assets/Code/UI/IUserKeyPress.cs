using System;

namespace Code.UI
{
    public interface IUserKeyPress
    {
         event Action <bool> UserKey;
         public void GetKey ();
    }
}