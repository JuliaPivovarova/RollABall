using UnityEngine;

namespace Code.BonusCode
{
    public class BonusController
    {
        private BonusSpawn _dic;

        public void DeleteFromList(Transform bonus)
        {
            for (int i = 0; i < _dic._bonusList.Count; i++)
            {
                if (_dic._bonusList[i].Position == bonus)
                {
                    _dic._bonusList.Remove(i);
                }
            }
        }
        
        
    }
}