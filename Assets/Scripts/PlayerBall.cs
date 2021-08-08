using UnityEngine;

namespace RollaBall
{
    namespace Player
    {
        public sealed class PlayerBall : Player
        {
            private void FixedUpdate()
            {
                Move();
            }
        }
    }
}

