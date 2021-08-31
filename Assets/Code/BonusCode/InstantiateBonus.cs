using UnityEngine;

namespace Code.BonusCode
{
    public class InstantiateBonus: MonoBehaviour
    {
        public GameObject InstBon(GameObject parentObj, Transform position)
        {
            return Instantiate(parentObj, position.position, position.rotation);
        }
    }
}