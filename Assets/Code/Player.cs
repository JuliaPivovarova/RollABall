using System;
using Code;
using UnityEngine;

namespace RollaBall
{
    namespace Player
    {
        public class Player: MonoBehaviour
        {
            [SerializeField] private float speed = 3.0f;
            private Rigidbody _rigidbody;
            //private AudioSource _audioSource;
            
            private float _moveHorizontal;
            private float _moveVertical;
            private bool _isWalking;
            private global::Code.Bonuses deleg;
            private FlagInterection flag;

            public Action<float> DelegChangeSpeed;
            public event Action<Collider> _bonusesEventAddSp;
            public event Action<Collider> _bonusesEventLowerSp;
            public event Action<Collider> _bonusesEventInvic;
            public event Action<Collider> _bonusesEventDeath;

            private void Start()
            {
                deleg = FindObjectOfType<global::Code.Bonuses>();
                bool _isRigidBody = TryGetComponent<Rigidbody>(out _rigidbody);
                if (!_isRigidBody)
                {
                    throw new Exception("There is no Rigidbody");
                }
                //_audioSource = GetComponent<AudioSource>();

                DelegChangeSpeed = SpeedChange;
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
                if (other.TryGetComponent<MarkerAddSpeed>(out var a) || other.gameObject.activeInHierarchy)
                {
                    _bonusesEventAddSp?.Invoke(other);
                }

                if (other.TryGetComponent<MarkerLowerSpeed>(out var l) || other.gameObject.activeInHierarchy)
                {
                    _bonusesEventLowerSp?.Invoke(other);
                }

                if (other.TryGetComponent<MarkerInvicibility>(out var inv) || other.gameObject.activeInHierarchy)
                {
                    _bonusesEventInvic?.Invoke(other);
                }

                if (other.TryGetComponent<MarkerDeathTrap>(out var d) || other.gameObject.activeInHierarchy)
                {
                    _bonusesEventDeath?.Invoke(other);
                }
            }

            private void CollisionAddSpeed(Collider other)
            {
                bool testComponent = other.TryGetComponent<FlagInterection>(out flag);
                Debug.Log("Add speed");
                deleg.DelegAddSp?.Invoke();
                Debug.Log(speed);
                if (testComponent)
                {
                    flag.Intercted?.Invoke();
                }
            }

            private void CollisionLoerSpeed(Collider other)
            {
                bool testComponent = other.TryGetComponent<FlagInterection>(out flag);
                Debug.Log("Lower speed");
                deleg.DelegLowerSp?.Invoke();
                Debug.Log(speed);
                if (testComponent)
                {
                    flag.Intercted?.Invoke();
                }
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

