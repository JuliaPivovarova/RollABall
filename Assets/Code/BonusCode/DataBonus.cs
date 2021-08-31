using System.Collections.Generic;
using UnityEngine;

namespace Code.BonusCode
{
    public class DataBonus
    {
        private Transform[] _spawnPointsGood;
        private Transform[] _spawnPointsBad;
        private BonusSingleClass[] _bonusesGood;
        private BonusSingleClass[] _bonusesBad;

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
            Dictionary<int, BonusSingleClass> bonuses = null;
            for (int i = 0; i < bon.Length; i++)
            {
                bonuses.Add(i, bon[i]);
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
