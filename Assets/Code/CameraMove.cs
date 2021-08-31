using Code.Interface;
using UnityEngine;

namespace Code
{
    public class CameraMove : IExecute
    {
        private Transform _camera;
        private Transform _player;
        private Vector3 _offset;

        public CameraMove(Transform player, Transform camera)
        {
            _player = player;
            _camera = camera;
        
            _camera.LookAt(_player);
            _offset = _camera.position - _player.position;
        }

        public void Execute()
        {
            _camera.position = _player.position + _offset;
        }
    }
}
