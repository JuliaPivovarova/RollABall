﻿using System;
using Code.Interface;
using RollaBall.Player;
using UnityEngine;

namespace Code.Player
{
    public sealed class PlayerInputController: IExecute
    {
        private readonly PlayerBall _player;
        private float _speed;
        private bool _invicible;
        private bool _isPlayerDead;

        public PlayerInputController(PlayerBall player, float speed)
        {
            _player = player;
            _speed = speed;
            _invicible = false;
            _isPlayerDead = false;
        }
        
        public void Execute()
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
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