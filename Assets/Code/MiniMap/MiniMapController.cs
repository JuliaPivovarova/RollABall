using Code.Interface;
using UnityEngine;

namespace Code.MiniMap
{
    public sealed class MiniMapController: ILateExecute
    {
        private readonly Transform _player;
        private readonly Transform _camera;

        public MiniMapController(Transform player, Transform camera)
        {
            _player = player;
            _camera = camera;
        }
        
        public void LateExecute()
        {
            var newPosition = _player.position;
            newPosition.y = _camera.position.y;
            _camera.position = newPosition;
            _camera.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
        }
    }
}