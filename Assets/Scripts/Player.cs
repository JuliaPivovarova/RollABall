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

            private void Start()
            {
                _rigidbody = GetComponent<Rigidbody>();
                //_audioSource = GetComponent<AudioSource>();
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

            public void SpeedChange(float speedChange)
            {
                
                speed += speedChange;
                
            }
        }
    }
}

