using UnityEngine;

namespace Code.Player
{
    namespace Player
    {
        public sealed class PlayerBall : Player
        {
            public void GoToPoint(Transform position)
            {
                gameObject.transform.position = position.position;
            }
        }
    }
}

