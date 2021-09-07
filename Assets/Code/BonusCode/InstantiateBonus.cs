using UnityEngine;

namespace Code.BonusCode
{
    public class InstantiateBonus: MonoBehaviour
    {
        private static GameObject newOgj;
        public static GameObject InstBon(GameObject parentObj, Transform _position)
        {
            newOgj = GameObject.Instantiate(parentObj, _position.position, _position.rotation);
            return newOgj;
        }
    }
}