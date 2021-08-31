using System;
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
            
            [SerializeField] private float speed = 3.0f;
            [SerializeField] private float changeSp = 2.0f;
            [SerializeField] private PostProcessVolume _ppvFastSpeed;
            [SerializeField] private PostProcessVolume _ppvLowSpeed;
            private Rigidbody _rigidbody;
            //private AudioSource _audioSource;
            
            private float _moveHorizontal;
            private float _moveVertical;
            private bool _isWalking;
            private global::Code.Bonuses deleg;
            private FlagInterection flag;
            private BonusController _bonusController;
            private PlayerInputController _playerInputController;
            private Code.Bonuses _bonuses;

            //public Action<float> DelegChangeSpeed;
            public event Action<Collider> _bonusesEventAddSp;
            public event Action<Collider> _bonusesEventLowerSp;
            public event Action<Collider> _bonusesEventInvic;
            public event Action<Collider> _bonusesEventDeath;

            private void Start()
            {
                deleg = _bonuses;
                bool _isRigidBody = TryGetComponent<Rigidbody>(out _rigidbody);
                if (!_isRigidBody)
                {
                    throw new Exception("There is no Rigidbody");
                }
                //_audioSource = GetComponent<AudioSource>();

                //DelegChangeSpeed = SpeedChange;
                _bonusesEventAddSp = CollisionAddSpeed;
                _bonusesEventLowerSp = CollisionLoerSpeed;
                _bonusesEventInvic = CollisionInvicib;
                _bonusesEventDeath = CollisionDeath;
            }

            protected void Move()
            {
                _moveHorizontal = Input.GetAxis("Horizontal");
                _moveVertical = Input.GetAxis("Vertical");
               

                Vector3 movement = new Vector3(_moveHorizontal, 0f, _moveVertical);

                _isWalking = !Mathf.Approximately(_moveHorizontal, 0f) || !Mathf.Approximately(_moveVertical, 0f);
                
                _rigidbody.AddForce(speed * movement);
                
                //if (_isWalking)
                //{
                //    if (!_audioSource.isPlaying)
                //    {
                //        _audioSource.Play();
                //    }
                //}
                //else
                //{
                //    _audioSource.Stop();
                //}
            }

            private void SpeedChange(float speedChange)
            {
                
                speed += speedChange;
                
            }

            private void OnTriggerEnter(Collider other)
            {
                if (other.TryGetComponent<MarkerAddSpeed>(out var a) && !_playerInputController.IsInvicible())
                {
                    _bonusesEventAddSp?.Invoke(other);
                    _bonusController.DeleteFromList(other.transform);
                }

                if (other.TryGetComponent<MarkerLowerSpeed>(out var l) && !_playerInputController.IsInvicible())
                {
                    _bonusesEventLowerSp?.Invoke(other);
                    _bonusController.DeleteFromList(other.transform);
                }

                if (other.TryGetComponent<MarkerInvicibility>(out var inv) && !_playerInputController.IsInvicible())
                {
                    _bonusesEventInvic?.Invoke(other);
                    _bonusController.DeleteFromList(other.transform);
                }

                if (other.TryGetComponent<MarkerDeathTrap>(out var d) && !_playerInputController.IsInvicible())
                {
                    _bonusesEventDeath?.Invoke(other);
                    _bonusController.DeleteFromList(other.transform);
                }
            }

            private void CollisionAddSpeed(Collider other)
            {
                StartCoroutine(_bonuses.ChangeSpeed(changeSp, _ppvFastSpeed));

                //bool testComponent = other.TryGetComponent<FlagInterection>(out flag);
                //Debug.Log("Add speed");
                //deleg.DelegAddSp?.Invoke();
                //Debug.Log(speed);
                //if (testComponent)
                //{
                //    flag.Intercted?.Invoke();
                //}
            }

            private void CollisionLoerSpeed(Collider other)
            {
                StartCoroutine(_bonuses.ChangeSpeed(changeSp, _ppvLowSpeed));
                
                //bool testComponent = other.TryGetComponent<FlagInterection>(out flag);
                //Debug.Log("Lower speed");
                //deleg.DelegLowerSp?.Invoke();
                //Debug.Log(speed);
                //if (testComponent)
                //{
                //    flag.Intercted?.Invoke();
                //}
            }

            private void CollisionInvicib(Collider other)
            {
                bool testComponent = other.TryGetComponent<FlagInterection>(out flag);
                Debug.Log("Invicibile");
                deleg.DelegInvic?.Invoke();
                if (testComponent)
                {
                    flag.Intercted?.Invoke();
                }
            }

            private void CollisionDeath(Collider other)
            {
                bool testComponent = other.TryGetComponent<FlagInterection>(out flag);
                Debug.Log("Death");
                deleg.DelegDeath?.Invoke();
                if (testComponent)
                {
                    flag.Intercted?.Invoke();
                }
            }
        }
    }
}

