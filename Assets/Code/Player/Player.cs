using System.Collections;
using Code.BonusCode;
using Code.Controllers;
using Code.Interfaces_and_Markers;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Code.Player
{
    namespace Player
    {
        public class Player: MonoBehaviour
        {
            [SerializeField] private float changeSp = 1.8f;
            [SerializeField] private PostProcessVolume ppvFastSpeed;
            [SerializeField] private PostProcessVolume ppvLowSpeed;

            private PlayerInputController _playerInputController = new PlayerInputController();
            private BonusController _bonusController = new BonusController();
            private Bonuses _bonuses = new Bonuses();
            private GameObject bonusToDestroy;
            private Behaviour halo;

            
            private void Start()
            {
                halo = (Behaviour)gameObject.GetComponent("Halo");
            }

            private void OnTriggerEnter(Collider other)
            {
                if (other.TryGetComponent<MarkerAddSpeed>(out _) && !_playerInputController.IsInvicible())
                {
                    bonusToDestroy = other.gameObject;
                    StartCoroutine(_bonuses.ChangeSpeed(changeSp, ppvFastSpeed));
                    _bonusController.DeleteFromList(other.transform);
                    Destroy(bonusToDestroy);
                }

                if (other.TryGetComponent<MarkerLowerSpeed>(out _) && !_playerInputController.IsInvicible())
                {
                    StartCoroutine(_bonuses.ChangeSpeed(-changeSp, ppvLowSpeed));
                    bonusToDestroy = other.gameObject;
                    _bonusController.DeleteFromList(other.transform);
                    Destroy(bonusToDestroy);
                }

                if (other.TryGetComponent<MarkerInvicibility>(out _) && !_playerInputController.IsInvicible())
                {
                    StartCoroutine(_bonuses.Invic());
                    StartCoroutine(ActivateHalo());
                    bonusToDestroy = other.gameObject;
                    _bonusController.DeleteFromList(other.transform);
                    Destroy(bonusToDestroy);
                }

                if (other.TryGetComponent<MarkerDeathTrap>(out _) && !_playerInputController.IsInvicible())
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
