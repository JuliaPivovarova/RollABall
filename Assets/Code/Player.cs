using System;
using System.Collections;
using Code;
using Code.BonusCode;
using Code.Player;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace RollaBall
{
    namespace Player
    {
        public class Player: MonoBehaviour
        {
            [SerializeField] private float changeSp = 1.8f;
            [SerializeField] private PostProcessVolume _ppvFastSpeed;
            [SerializeField] private PostProcessVolume _ppvLowSpeed;
            //private AudioSource _audioSource;
            
            private PlayerInputController _playerInputController = new PlayerInputController();
            private BonusController _bonusController = new BonusController();
            private Code.Bonuses _bonuses = new Code.Bonuses();
            private GameObject bonusToDestroy;
            private PlayerBall _playerBall;
            private Behaviour halo;

            private void Start()
            {
                halo = (Behaviour)gameObject.GetComponent("Halo");
            }

            private void OnTriggerEnter(Collider other)
            {
                if (other.TryGetComponent<MarkerAddSpeed>(out var a) && !_playerInputController.IsInvicible())
                {
                    bonusToDestroy = other.gameObject;
                    StartCoroutine(_bonuses.ChangeSpeed(changeSp, _ppvFastSpeed));
                    _bonusController.DeleteFromList(other.transform);
                    Destroy(bonusToDestroy);
                }

                if (other.TryGetComponent<MarkerLowerSpeed>(out var l) && !_playerInputController.IsInvicible())
                {
                    StartCoroutine(_bonuses.ChangeSpeed(-changeSp, _ppvLowSpeed));
                    bonusToDestroy = other.gameObject;
                    _bonusController.DeleteFromList(other.transform);
                    Destroy(bonusToDestroy);
                }

                if (other.TryGetComponent<MarkerInvicibility>(out var inv) && !_playerInputController.IsInvicible())
                {
                    StartCoroutine(_bonuses.Invic());
                    StartCoroutine(ActivateHalo());
                    bonusToDestroy = other.gameObject;
                    _bonusController.DeleteFromList(other.transform);
                    Destroy(bonusToDestroy);
                }

                if (other.TryGetComponent<MarkerDeathTrap>(out var d) && !_playerInputController.IsInvicible())
                {
                    _playerInputController.PlayerDead(true);
                    bonusToDestroy = other.gameObject;
                    _bonusController.DeleteFromList(other.transform);
                    Destroy(bonusToDestroy);
                }
            }

            public IEnumerator ActivateHalo()
            {
                halo.enabled = true;
                yield return new WaitForSeconds(4f);
                halo.enabled = false;
            }
        }
    }
}

