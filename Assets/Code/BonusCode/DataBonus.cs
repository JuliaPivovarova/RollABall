using System.Collections.Generic;
using UnityEngine;

namespace Code.BonusCode
{
    
    public class DataBonus
    {
        private static Transform[] _spawnPointsGood;
        private static Transform[] _spawnPointsBad;
        private static BonusSingleClass[] _bonusesGood;
        private static BonusSingleClass[] _bonusesBad;
        private static Dictionary<int, BonusSingleClass> bonuses = null;

        public DataBonus() {}
        public DataBonus(Transform[] spawnPointsGood, Transform[] spawnPointsBad, BonusSingleClass[] bonusesGood,
            BonusSingleClass[] bonusesBad)
        {
            _spawnPointsGood = spawnPointsGood;
            _spawnPointsBad = spawnPointsBad;
            _bonusesGood = bonusesGood;
            _bonusesBad = bonusesBad;
        }

        private Dictionary<int, BonusSingleClass> GetDictionary(BonusSingleClass[] bon)
        {
            
            for (int i = 0; i < bon.Length; i++)
            {
                bonuses.Add(i, bon[i]);
                Debug.Log(bon[i].Material);
            }
            return bonuses;
        }
        
        public Transform[] SpawnPointsB()
        {
            return _spawnPointsBad;
        }

        public Transform[] SpawnPointsG()
        {
            return _spawnPointsGood;
        } 
        public BonusSingleClass[] BonG => _bonusesGood;
        public BonusSingleClass[] BonB => _bonusesBad;

        public int SpawnBonusSum => _spawnPointsBad.Length + _spawnPointsGood.Length;
        public Dictionary<int, BonusSingleClass> BonusGoodDic => GetDictionary(_bonusesGood);
        public Dictionary<int, BonusSingleClass> BonusBadDic => GetDictionary(_bonusesBad);
    }
}
