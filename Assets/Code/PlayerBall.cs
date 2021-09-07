using System;
using System.Collections;
using Code;
using UnityEngine;

namespace RollaBall
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

