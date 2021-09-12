using System;

namespace Code.Interfaces_and_Markers
{
    public interface IUserKeyPress
    {
         event Action <bool> UserKey;
         public void GetKey ();
    }
}