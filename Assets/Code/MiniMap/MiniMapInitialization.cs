using UnityEngine;

namespace Code.MiniMap
{
    public sealed class MiniMapInitialization
    {
        private readonly Transform _player;
        private readonly Transform _camera;

        public MiniMapInitialization(){}
        public MiniMapInitialization(Transform player, Transform camera)
        {
            _player = player;
            _camera = camera;
        }

        public void Initialize()
        {
            var main = Camera.main;
            _camera.parent = null;
            _camera.rotation = Quaternion.Euler(90.0f, 0, 0);
            _camera.position = _player.position + new Vector3(0, 5.0f, 0);
            
            var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");
            
            var component = _camera.GetComponent<Camera>();
            component.targetTexture = rt;
            component.depth = --main.depth;
        }
    }
}