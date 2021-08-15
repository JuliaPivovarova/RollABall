using System;
using System.Collections;
using UnityEngine;

namespace RollaBall
{
    namespace Player
    {
        public sealed class PlayerBall : Player
        {
            private Behaviour halo;
            private RenderSettings _halo;

            private Player _player;
            private void Awake()
            {
                _player = FindObjectOfType<Player>();
                _player._bonusesEventInvic += Halo;
            }

            private void OnDestroy()
            {
                _player._bonusesEventInvic -= Halo;
            }

            private void Update()
            {
                Move();
            }

            private void Halo(Collider other)
            {
                _halo = gameObject.GetComponent<RenderSettings>();
                Debug.Log("Halo try");
                halo = (Behaviour)gameObject.GetComponent("Halo");
                StartCoroutine(ActivateHalo());
            }

            private IEnumerator ActivateHalo()
            {
                halo.enabled = true;
                yield return new WaitForSeconds(4f);
                halo.enabled = false;
            }
        }
    }
}

