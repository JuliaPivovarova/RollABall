using UnityEngine;

namespace Code.BonusCode
{
    public class InstantiateBonus
    {
        private static GameObject _newOgj;
        public static GameObject InstBon(GameObject parentObj, Transform position)
        {
            _newOgj = GameObject.Instantiate(parentObj, position.position, position.rotation);
            return _newOgj;
        }
    }
}