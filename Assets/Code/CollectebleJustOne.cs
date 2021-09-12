using Code.Player.Player;
using Code.UI;
using UnityEngine;

namespace Code
{
    public class CollectebleJustOne : MonoBehaviour
    {
        private UICollecteblesSlider _uiCollecteblesSlider;
        
        private void Start()
        {
            gameObject.SetActive(true);
            _uiCollecteblesSlider = new UICollecteblesSlider();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerBall>(out _) && gameObject.activeInHierarchy)
            {
                _uiCollecteblesSlider.AddCollecteble();
                gameObject.SetActive(false);
            }
        }
    }
}
