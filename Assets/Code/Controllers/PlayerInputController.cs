using System;
using Code.Interfaces_and_Markers;
using Code.Player.Player;
using UnityEngine;

namespace Code.Controllers
{
    public sealed class PlayerInputController: IExecute
    {
        private readonly PlayerBall _player;
        private static float _speed;
        private static bool _invicible = false;
        private static bool _isPlayerDead = false;

        public PlayerInputController(){}
        public PlayerInputController(PlayerBall player, float speed)
        {
            _player = player;
            _speed = speed;
        }
        
        public void Execute()
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal") , 0f, Input.GetAxis("Vertical"));
            if (_player.TryGetComponent<Rigidbody>(out var _rigidbody))
            {
                _rigidbody.AddForce(_speed * movement);
            }
            else
            {
                throw new Exception("There is no Rigidbody");
            }
        }

        public void ChangeSpeed(float addSpeed)
        {
            _speed += addSpeed;
        }

        public void Invicibility(bool invicible)
        {
            _invicible = invicible;
        }

        public bool IsInvicible()
        {
            return _invicible;
        }

        public void PlayerDead(bool playerDead)
        {
            _isPlayerDead = playerDead;
        }
        
        public bool IsPlayerDead()
        {
            return _isPlayerDead;
        }
    }
}