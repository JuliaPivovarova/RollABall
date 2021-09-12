using Code.BonusCode;
using UnityEngine;

namespace Code.Controllers
{
    public class BonusController
    {
        public void DeleteFromList(Transform bonus)
        {
            for (int i = 0; i < BonusSpawn._bonusList.Count; i++)
            {
                if (BonusSpawn.Length[i] != 0 && BonusSpawn._bonusList[i].Position.position == bonus.position)
                {
                    BonusSpawn._bonusList[i].ComplitBonus.SetActive(false);
                    BonusSpawn._bonusList[i].Interecteble = false;
                    BonusSpawn._bonusList.Remove(i);
                    BonusSpawn.Length[i] = 0;
                }
            }
        }
        
        
    }
}